using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudioSampleAggregator;


namespace AudioTest
{
    public partial class FretBoard : Form
    {
        public int SetText
        {
            get { return rowindex; }
            set { rowindex = value; }

        }

        private readonly Read read;
        int rowindex;
       

        public FretBoard()
        {
            InitializeComponent();
            read = new Read(this);
        }
        private void FretBoard_Load(object sender, EventArgs e)
        {
            

        }

      

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            radioButtonChord.Enabled = false;
            radioButtonSingleNotes.Enabled = false;
            radioButtonPractice.Enabled = false;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            read.StartReceivingData();
            
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            radioButtonChord.Enabled = true;
            radioButtonSingleNotes.Enabled = true;
            radioButtonPractice.Enabled = true;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            read.StopReceivingData();
           
        }

        private void ButtonChord_Click(object sender, EventArgs e)
        {

        }

       

        private void RadioButtonSingleNotes_Click(object sender, EventArgs e)
        {
            radioButtonChord.Checked = false;
            radioButtonPractice.Checked = false;
            radioButtonSingleNotes.Checked = true;
        }

        private void RadioButtonChord_Click(object sender, EventArgs e)
        {
            radioButtonSingleNotes.Checked = false;
            radioButtonPractice.Checked = false;
            radioButtonChord.Checked = true;           
        }

        private void RadioButtonPractice_Click(object sender, EventArgs e)
        {
            radioButtonChord.Checked = false;
            radioButtonSingleNotes.Checked = false;
            radioButtonPractice.Checked = true;
        }

        private void ButtonGenerateChord_Click(object sender, EventArgs e)
        {
            read.GenerateChord();
            labelChord.ForeColor = Color.Black;
            labelChordRoot.ForeColor = Color.Black;
            labelChordThird.ForeColor = Color.Black;
            labelChordFift.ForeColor = Color.Black;
        }
    }
}
