using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using System.Linq;
using NAudio.Wave;
using NAudio.Dsp;
using NAudioSampleAggregator;
using System.Collections.Generic;
using System.Drawing;
using NAudio.MediaFoundation;


namespace AudioTest
{
    public partial class MainForm : Form
    {

        private WaveFileWriter RecordedAudioWriter = null;        
        private WasapiLoopbackCapture CaptureInstance = null;

        private readonly TunerRead read;
       

        string[] filePathArray = new string[] {
        @"tesztaudio\audioteszt1.wav",
        @"tesztaudio\audioteszt2.wav",
        @"tesztaudio\audioteszt3.wav",
        @"tesztaudio\audioteszt4.wav",
        @"tesztaudio\audioteszt5.wav",
        @"tesztaudio\audioteszt6.wav",
        };

      
        

        public MainForm()
        {
            InitializeComponent();
            read = new TunerRead(this);

            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            
            comboBoxRecordedSound.Items.AddRange(filePathArray);
            comboBox1.Items.AddRange(devices.ToArray());
            

            for (int i = -1; i < WaveIn.DeviceCount; i++)
            {
                var caps = WaveIn.GetCapabilities(i);
                comboBoxDevices.Items.Add(($"{i}: {caps.ProductName}"));
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        



        private void buttonStart_Click(object sender, EventArgs e)
        {
            string outputFilePath = @"tesztaudio\audioteszt.wav";
            var recordingDevice = new WaveInEvent();
            this.CaptureInstance = new WasapiLoopbackCapture();
            //deviceNumber mindig a kimeneti eszköz száma
            recordingDevice.DeviceNumber = 2;
            Console.WriteLine("felvétel start");
            this.RecordedAudioWriter = new WaveFileWriter(outputFilePath, recordingDevice.WaveFormat);

            recordingDevice.DataAvailable += (s, a) =>
            {
                this.RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
            };

            recordingDevice.RecordingStopped += (s, a) =>
            {
                this.RecordedAudioWriter.Dispose();
                this.RecordedAudioWriter = null;
                recordingDevice.Dispose();
            };

            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = true;

            recordingDevice.StartRecording();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            var recordingDevice = new WaveInEvent() ;
           
            recordingDevice.StopRecording();

            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
        }

        public void buttonFelvetel_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRecordedSound.SelectedItem != null)
                {
                   read.StartReceivingRecordedData(comboBoxRecordedSound.SelectedItem.ToString());
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show("A megadott fájlhivatkozáson lévő fájl nem létezik!");                
            }
            
            
            
            

        }

       
        


      
        private void buttonStartLive_Click(object sender, EventArgs e)
        {
            buttonStopLive.Enabled = true;
            buttonStartLive.Enabled = false;
            read.StartReceivingData();            
        }

        private void buttonStopLive_Click(object sender, EventArgs e)
        {
            read.StopReceivingData();
            BeginInvoke(new Action(() =>
            {
                labelFreqValue.Text = "0";
                labelPowerValue.Text = "0";
            }));
            

            buttonStopLive.Enabled = false;
            buttonStartLive.Enabled = true;
        }

        


        private void buttonFretboard_Click(object sender, EventArgs e)
        {
            FretBoard fb = new FretBoard();
            fb.Show();
            MainForm form = new MainForm();
            form.Close();
        }

       
    }
}
    