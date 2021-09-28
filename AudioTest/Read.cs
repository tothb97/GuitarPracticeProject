using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using System.Linq;
using NAudio.Wave;
using NAudio.Dsp;
using NAudioSampleAggregator;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;





namespace AudioTest
{
    public class Read : IRead
    {
        private WaveIn sourceStream = null;        
        private WaveOut waveOut = null;
        private SampleAggregator aggregator = null;
        private BufferedWaveProvider waveBuffer;

        private readonly FretBoard form;
        private double power;
        public static List<double> lastFrequencyPeakList = new List<double>();
        int sampleRate = 44100;
        int eventCount = 0;
        int validDataEvent = 0;
        bool Calculated;
        bool live = false;

        public Read(FretBoard form)
        {
           this.form = form;
            GenerateChord();
        }


        public void GenerateChord()
        {
            Random rnd = new Random();
            string practiceChord = CalculateValues.PracticeChordGenerator(rnd.Next(0, 6), rnd.Next(0, 4));
            form.labelChordPractice.Text = practiceChord;
        }

        public void StartReceivingData()
        {
            waveOut = new WaveOut();
            sourceStream = new WaveIn();
            int deviceNumber = 2;

            ClearFretboard();
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate,1);

            sourceStream.StartRecording();
            waveBuffer = new BufferedWaveProvider(sourceStream.WaveFormat);

            sourceStream.DataAvailable += (s, a) =>
            {
                waveBuffer.AddSamples(a.Buffer, 0, a.BytesRecorded);
                var sample = waveBuffer.ToSampleProvider();
                aggregator = new SampleAggregator(sample, 8192);              
                aggregator.PerformFFT = true;
                aggregator.FftCalculated += new EventHandler<FftEventArgs>(OnFftCalculated);
                
                if (!live)
                {                    
                    waveOut.Init(aggregator);
                    waveOut.Play();
                    live = true;
                }
            };

            sourceStream.RecordingStopped += (s, a) =>
            {
                live = false;
                waveOut.Stop();
                aggregator.PerformFFT = false;
                aggregator.Reset();
                aggregator = null;


                sourceStream.Dispose();
                waveOut.Dispose();
                sourceStream = null;
                waveOut = null;
                ClearFretboard();
            };






        }


        public void StartReceivingDataOld()
        {
            waveOut = new WaveOut();
            sourceStream = new WaveIn();
            int deviceNumber = 2;
            
            ClearFretboard();
            

            //itt történt változás
            sourceStream.DeviceNumber = deviceNumber;

            //eredeti
            sourceStream.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1/*WaveIn.GetCapabilities(deviceNumber).Channels*/);
            

            WaveInProvider waveIn = new WaveInProvider(sourceStream);
            
            sourceStream.StartRecording();
            var waveBuffer = new BufferedWaveProvider(sourceStream.WaveFormat);
           

            sourceStream.DataAvailable += (s, a) =>
            {
               
                var sample = waveIn.ToSampleProvider();
                aggregator = new SampleAggregator(sample, 8192);
                aggregator.PerformFFT = true;
                aggregator.FftCalculated += new EventHandler<FftEventArgs>(OnFftCalculated);
                waveOut.Init(aggregator);
                waveOut.Play();
                

            };



            sourceStream.RecordingStopped += (s, a) =>
            {
   
                    waveOut.Stop();
                    aggregator.PerformFFT = false;
                    aggregator.Reset();
                    aggregator = null;
                    
                
                    sourceStream.Dispose();
                    waveOut.Dispose();
                    sourceStream = null;
                    waveOut = null;
                    ClearFretboard();                
                
            };





            
        }

        public void StopReceivingData()
        {
            sourceStream.StopRecording();                       
        }
        public double CalculatePower(Complex c)
        {
            double intensityDB = 10 * Math.Log10(Math.Sqrt(c.X * c.X + c.Y * c.Y));
            return intensityDB;
        }

        
        public void OnFftCalculated(Object sender, FftEventArgs e)
        {
            Complex[] complexArray = e.Result;
            List<double> listPowerValue = new List<double>();
            List<double> listFrequencyValue = new List<double>();
            List<double> listPowerValuePeaks = new List<double>();
            CalculateValues.chordNotesList.Clear();

            


            int count = 0;
            double minPower = -40;
            double frequency;


            Console.WriteLine("Lista eleje--------------");
            foreach (var item in complexArray)
            {
                //65 536
                power = CalculatePower(item);
                frequency = count * sampleRate / complexArray.Length;
                listPowerValue.Add(power);
                listFrequencyValue.Add(frequency);


                Console.WriteLine("db: " + power + ", frekvencia: " + frequency);

                if (frequency > 450)
                {
                    break;
                }
                count++;
            }

            Console.WriteLine("Lista vége--------------");

            if (minPower < listPowerValue.Max() && form.radioButtonSingleNotes.Checked == false)
            {
                minPower = listPowerValue.Max() - 10;
            }
            

            for (int i = 1; i < listPowerValue.Count-1; i++)
            {
                if (listPowerValue[i] > listPowerValue[i-1] && listPowerValue[i] > listPowerValue[i+1] && listPowerValue[i] > minPower && listFrequencyValue[i] > 78 )
                {                   
                    listPowerValuePeaks.Add(listPowerValue.ElementAt(i));
                                
                }
            }

            if (listPowerValuePeaks.Any())
            {
                eventCount++;
                Console.WriteLine("---------------------------------Csúcsértékek: "+ eventCount);
                for (int i = 0; i < listPowerValuePeaks.Count; i++)
                {
                    
                    Console.WriteLine("db: " + listPowerValuePeaks.ElementAt(i) + ", frekvencia: " + listFrequencyValue.ElementAt(listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i))));
                   
                }
            }
            else
            {
                eventCount = 0;
                validDataEvent = 0;
                Calculated = false;
                ClearFretboard();
                Console.WriteLine("----------torles----------------");
            }

           



            if (listPowerValue.Any() && listPowerValuePeaks.Any() && form.radioButtonSingleNotes.Checked == true)
            {
                if (eventCount > 4 && eventCount < 11)
                {
                form.tableLayoutFretBoard.GetControlFromPosition(CalculateValues.ColumnIndex, CalculateValues.RowIndex).ForeColor = Color.White;

                // alaphang
               
                int index = listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(0));

                double keyfrequency = listFrequencyValue.ElementAt(index);

         
                // beállítja a label oszlop és sor indexeit
                CalculateValues.CalculateFretBoardKey(keyfrequency);
                var cell = form.tableLayoutFretBoard.GetControlFromPosition(CalculateValues.ColumnIndex, CalculateValues.RowIndex);
                cell.ForeColor = Color.Yellow;
                }             
            }
            else if (listPowerValuePeaks.Any() && listPowerValuePeaks.Any() && form.radioButtonChord.Checked == true)
            {
        
                
                   
                
                
                CalculateValues.CalculateFretBoardKey(listFrequencyValue.ElementAt(listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(0))));
                int harmonics = CalculateValues.RowIndex;

                if (lastFrequencyPeakList.Any() && harmonics < listPowerValuePeaks.Count && harmonics < lastFrequencyPeakList.Count)
                {
                    for (int i = 0; i < harmonics + 1; i++)
                    {
                     int index = listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i));                   
                     double currentfrequency = listFrequencyValue.ElementAt(index);
                     double lastfrequency = lastFrequencyPeakList.ElementAt(i);
                     CalculateValues.CheckPeakData(currentfrequency,lastfrequency);
                     
                    }
                    
                }

                if (CalculateValues.isDataValid && Calculated == false)
                {
                    validDataEvent++;
                }
                else
                {
                    validDataEvent = 0;
                }


                if (harmonics + 1 < listPowerValuePeaks.Count && eventCount < 12 && CalculateValues.isDataValid && validDataEvent == 3)
                {
                    Console.WriteLine("NA EZ!!");
                    validDataEvent = 0;
                    Calculated = true;

                    for (int i = 0; i < harmonics + 1; i++)
                    {                      
                     int index = listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i));
                     double keyfrequency = listFrequencyValue.ElementAt(index);

                     CalculateValues.CalculateFretBoardKey(keyfrequency);
                     var cell = form.tableLayoutFretBoard.GetControlFromPosition(CalculateValues.ColumnIndex, CalculateValues.RowIndex);
                    
                     cell.ForeColor = Color.Yellow;

                        CalculateValues.CalculateChord(keyfrequency);
                        form.labelChord.Text = CalculateValues.Chord;
                        form.labelChordRoot.Text = CalculateValues.Root;
                        form.labelChordThird.Text = CalculateValues.Third;
                        form.labelChordFift.Text = CalculateValues.Fift;

                    }

                    CalculateValues.isDataValid = false;
                    //StopReceivingData();
                }
                            
            }
            else if (listPowerValuePeaks.Any() && listPowerValuePeaks.Any() && form.radioButtonPractice.Checked == true)
            {
                
                

                CalculateValues.CalculateFretBoardKey(listFrequencyValue.ElementAt(listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(0))));
                int harmonics = CalculateValues.RowIndex;

                if (lastFrequencyPeakList.Any() && harmonics < listPowerValuePeaks.Count && harmonics < lastFrequencyPeakList.Count)
                {
                    for (int i = 0; i < harmonics + 1; i++)
                    {
                        int index = listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i));
                        double currentfrequency = listFrequencyValue.ElementAt(index);
                        double lastfrequency = lastFrequencyPeakList.ElementAt(i);
                        CalculateValues.CheckPeakData(currentfrequency, lastfrequency);

                    }

                }

                if (CalculateValues.isDataValid && Calculated == false)
                {
                    validDataEvent++;
                }
                else
                {
                    validDataEvent = 0;
                }


                if (harmonics + 1 < listPowerValuePeaks.Count && eventCount < 12 && CalculateValues.isDataValid && validDataEvent == 3)
                {
                    Console.WriteLine("Akkord megtalálva!");
                    validDataEvent = 0;
                    Calculated = true;

                    for (int i = 0; i < harmonics + 1; i++)
                    {
                        int index = listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i));
                        double keyfrequency = listFrequencyValue.ElementAt(index);

                        CalculateValues.CalculateFretBoardKey(keyfrequency);
                        var cell = form.tableLayoutFretBoard.GetControlFromPosition(CalculateValues.ColumnIndex, CalculateValues.RowIndex);

                        cell.ForeColor = Color.Yellow;

                        CalculateValues.CalculateChord(keyfrequency);
                        form.labelChord.Text = CalculateValues.Chord;
                        form.labelChordRoot.Text = CalculateValues.Root;
                        form.labelChordThird.Text = CalculateValues.Third;
                        form.labelChordFift.Text = CalculateValues.Fift;

                       

                        if (form.labelChordPractice.Text == CalculateValues.Chord)
                        {
                            form.labelChord.ForeColor = Color.Green;
                            form.labelChordRoot.ForeColor = Color.Green;
                            form.labelChordThird.ForeColor = Color.Green;
                            form.labelChordFift.ForeColor = Color.Green;
                        }
                        else
                        {
                            form.labelChord.ForeColor = Color.Red;
                            form.labelChordRoot.ForeColor = Color.Red;
                            form.labelChordThird.ForeColor = Color.Red;
                            form.labelChordFift.ForeColor = Color.Red;

                            if (CalculateValues.PracticeRoot == form.labelChordRoot.Text) form.labelChordRoot.ForeColor = Color.Green;
                            if (CalculateValues.PracticeThird == form.labelChordThird.Text) form.labelChordThird.ForeColor = Color.Green;
                            if (CalculateValues.PracticeFift == form.labelChordFift.Text) form.labelChordFift.ForeColor = Color.Green;
                        }

                    }

                    CalculateValues.isDataValid = false;
                }
            }



            // buffer lista
            lastFrequencyPeakList.Clear();
            foreach (var item in listPowerValuePeaks)
            {                
                lastFrequencyPeakList.Add(listFrequencyValue.ElementAt(listPowerValue.IndexOf(item)));
            }
            
            listPowerValue.Clear();
            listFrequencyValue.Clear();
            listPowerValuePeaks.Clear();
                
        }


        public void DSP()
        {
            WaveOut waveOut = new WaveOut();
        
            int fftlenght = 32768; // a felbontás mindig a 2 hatvány lehet, régi érték: 8192
            var waveStream = new AudioFileReader(@"C:\Users\tothb\Documents\Audacity\Em7_akkord.wav");
            var aggregator = new SampleAggregator(waveStream, fftlenght)
            {
                PerformFFT = true
            };
            aggregator.FftCalculated += new EventHandler<FftEventArgs>(OnFftCalculated);



            waveOut.Init(aggregator);
            waveOut.Play();



            
        }


        private void ClearFretboard()
        {
            for (int y = 0; y < 6; y++)
            {
                for (int i = 0; i < 6; i++)
                {
                    form.tableLayoutFretBoard.GetControlFromPosition(y,i).ForeColor = Color.White;
                }
            }           
        }


        public void StartReceivingRecordedData(string filePath)
        {
            waveOut = new WaveOut();
            sampleRate = 44100;
            int fftlenght = 8192;
            var waveStream = new AudioFileReader(filePath);
            var aggregator = new SampleAggregator(waveStream, fftlenght)
            {
                PerformFFT = true
            };
            aggregator.FftCalculated += new EventHandler<FftEventArgs>(OnFftCalculated);

            waveOut.Init(aggregator);
            waveOut.Play();

        }


    }
}
