using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using System.Linq;
using NAudio.Wave;
using NAudio.Dsp;
using NAudioSampleAggregator;
using System.Collections.Generic;
using System.Drawing;



namespace AudioTest
    {
        public class TunerRead : IRead 
        {
        private WaveIn sourceStream = null;
        private WaveOut waveOut = null;
        private SampleAggregator aggregator = null;
        private BufferedWaveProvider waveBuffer;


        private double power;
            int eventCount = 0;
            private readonly MainForm form;
        int sampleRate = 44100;
        private bool live = false;

        public TunerRead(MainForm form)
            {
            this.form = form;

            }

      



        

            public void StartReceivingData()
            {
            

            waveOut = new WaveOut();
            sourceStream = new WaveIn();
            int deviceNumber = 2;

        
            sourceStream.DeviceNumber = deviceNumber;
            sourceStream.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);

            sourceStream.StartRecording();
            waveBuffer = new BufferedWaveProvider(sourceStream.WaveFormat);

            sourceStream.DataAvailable += (s, a) =>
            {
                waveBuffer.AddSamples(a.Buffer, 0, a.BytesRecorded);
                var sample = waveBuffer.ToSampleProvider();
                aggregator = new SampleAggregator(sample, 8192);
                aggregator.PerformFFT = true;
                aggregator.FftCalculated += new EventHandler<FftEventArgs>(OnFftCalculatedTuner);

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

            public void OnFftCalculatedTuner(Object sender, FftEventArgs e)
            {
                Complex[] complexArray = e.Result;
                List<double> listPowerValue = new List<double>();
                List<double> listFrequencyValue = new List<double>();
                List<double> listPowerValuePeaks = new List<double>();
                CalculateValues.chordNotesList.Clear();


                int count = 0;
                double minPower = -50;
                double frequency;


            Console.WriteLine("Lista eleje--------------");
            foreach (var item in complexArray)
                {
                    power = CalculatePower(item);
                    frequency = count * sampleRate / complexArray.Length;

                    listPowerValue.Add(power);
                    listFrequencyValue.Add(frequency);
                Console.WriteLine("db: " + power + ", frekvencia: " + frequency);
                if (frequency > 440)
                    {
                        break;
                    }
                    count++;
                }
            Console.WriteLine("Lista vége--------------");
                if (minPower < listPowerValue.Max())
                {
                    minPower = listPowerValue.Max() - 4;
                }


                for (int i = 1; i < listPowerValue.Count - 1; i++)
                {
                    if (listPowerValue[i] > listPowerValue[i - 1] && listPowerValue[i] > listPowerValue[i + 1] && listPowerValue[i] > minPower)
                    {
                        listPowerValuePeaks.Add(listPowerValue.ElementAt(i));                  
                    }
                }

                if (listPowerValuePeaks.Any())
                {
                double basefreq = listFrequencyValue.ElementAt(listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(0)));
             
                //labelek kezelése
                    form.labelFreqValue.Text = basefreq.ToString();
                    form.labelPowerValue.Text = listPowerValuePeaks.ElementAt(0).ToString();                    
                    form.labelKeyValue.Text = CalculateValues.CalculateClosestKeyToTune(basefreq);

                // trackbar kezelése
                    AdjustFormItems(basefreq);                                                    
                    form.labelBaseKey.Text = CalculateValues.CalculateClosestKeyToTune(basefreq);
                    

                Console.WriteLine("---------------------------------");
                    for (int i = 0; i < listPowerValuePeaks.Count; i++)
                    {
                   
                        Console.WriteLine("db: " + listPowerValuePeaks.ElementAt(i) + ", freq: " + listFrequencyValue.ElementAt(listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i))));
                    }

                }
                else
                {
                    eventCount++;
                }

                listPowerValue.Clear();
                listFrequencyValue.Clear();
                listPowerValuePeaks.Clear();
                
                         
            }


            public void OnFftCalculated(Object sender, FftEventArgs e)
            {
                Complex[] complexArray = e.Result;
                List<double> listPowerValue = new List<double>();
                List<double> listFrequencyValue = new List<double>();
                List<double> listPowerValuePeaks = new List<double>();
                CalculateValues.chordNotesList.Clear();


                int count = 0;
                double maxPower = -40;
                double frequency;



                foreach (var item in complexArray)
                {
                    power = CalculatePower(item);
                    frequency = count * 44100 / complexArray.Length;

                    listPowerValue.Add(power);
                    listFrequencyValue.Add(frequency);

                    if (count == 1024)
                    {
                        break;
                    }
                    count++;
                }
                if (maxPower < listPowerValue.Max())
                {
                    maxPower = listPowerValue.Max() - 15;
                }


                for (int i = 1; i < listPowerValue.Count - 1; i++)
                {
                    if (listPowerValue[i] > listPowerValue[i - 1] && listPowerValue[i] > listPowerValue[i + 1] && listPowerValue[i] > maxPower && listFrequencyValue[i] > 80)
                    {
                        listPowerValuePeaks.Add(listPowerValue.ElementAt(i));
                    }
                }

                if (listPowerValuePeaks.Any())
                {
                    Console.WriteLine("---------------------------------");
                    for (int i = 0; i < listPowerValuePeaks.Count; i++)
                    {
                        //form.labelChord.Text = listFrequencyValue.ElementAt(listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i))).ToString();
                        Console.WriteLine("db: " + listPowerValuePeaks.ElementAt(i) + ", freq: " + listFrequencyValue.ElementAt(listPowerValue.IndexOf(listPowerValuePeaks.ElementAt(i))));
                    }
                }
                else
                {
                    eventCount++;
                }



                listPowerValue.Clear();
                listFrequencyValue.Clear();
                listPowerValuePeaks.Clear();
                waveOut.Stop();     
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
            aggregator.FftCalculated += new EventHandler<FftEventArgs>(OnFftCalculatedTuner);

                waveOut.Init(aggregator);
                waveOut.Play();
            
            }

        private void AdjustFormItems(double basefreq)
        {
            double difference = Math.Abs(CalculateValues.KeyValue - basefreq);

            if (CalculateValues.isInRange)
            {
                form.labelBaseKey.ForeColor = Color.Orange;
                form.labelHighKey.ForeColor = Color.Empty;
                form.labelLowKey.ForeColor = Color.Empty;
                form.trackBarTunerScale.Value = Convert.ToInt32((basefreq / CalculateValues.KeyValue) * 100);

                if (CalculateValues.isInRange && difference <= 2)
                {
                    form.labelBaseKey.ForeColor = Color.Green;
                    form.labelHighKey.ForeColor = Color.Empty;
                    form.labelLowKey.ForeColor = Color.Empty;
                    form.trackBarTunerScale.Value = 99;
                }
            }
            else
            {
                form.labelBaseKey.ForeColor = Color.Red;

                if (basefreq < CalculateValues.KeyValue)
                {
                    form.trackBarTunerScale.Value = 90;
                    form.labelLowKey.ForeColor = Color.Red;
                }
                else if (basefreq > CalculateValues.KeyValue)
                {
                    form.trackBarTunerScale.Value = 107;
                    form.labelHighKey.ForeColor = Color.Red;
                }

            }
        }

        

        }
}
