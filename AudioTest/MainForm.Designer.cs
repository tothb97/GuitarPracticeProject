using System;

namespace AudioTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFelvetel = new System.Windows.Forms.Button();
            this.labelPower = new System.Windows.Forms.Label();
            this.labelPowerValue = new System.Windows.Forms.Label();
            this.labelFreq = new System.Windows.Forms.Label();
            this.labelFreqValue = new System.Windows.Forms.Label();
            this.buttonStartLive = new System.Windows.Forms.Button();
            this.buttonStopLive = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.labelKeyValue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.trackBarTunerScale = new System.Windows.Forms.TrackBar();
            this.labelLowKey = new System.Windows.Forms.Label();
            this.labelHighKey = new System.Windows.Forms.Label();
            this.labelBaseKey = new System.Windows.Forms.Label();
            this.comboBoxRecordedSound = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonFretboard = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTunerScale)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(250, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(24, 20);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 33);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(24, 59);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 26);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(12, 38);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(213, 24);
            this.comboBoxDevices.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 7;
            // 
            // buttonFelvetel
            // 
            this.buttonFelvetel.Location = new System.Drawing.Point(15, 34);
            this.buttonFelvetel.Name = "buttonFelvetel";
            this.buttonFelvetel.Size = new System.Drawing.Size(91, 62);
            this.buttonFelvetel.TabIndex = 8;
            this.buttonFelvetel.Text = "Felvétel";
            this.buttonFelvetel.UseVisualStyleBackColor = true;
            this.buttonFelvetel.Click += new System.EventHandler(this.buttonFelvetel_Click);
            // 
            // labelPower
            // 
            this.labelPower.AutoSize = true;
            this.labelPower.Location = new System.Drawing.Point(61, 40);
            this.labelPower.Name = "labelPower";
            this.labelPower.Size = new System.Drawing.Size(29, 17);
            this.labelPower.TabIndex = 11;
            this.labelPower.Text = "dB:";
            // 
            // labelPowerValue
            // 
            this.labelPowerValue.AutoSize = true;
            this.labelPowerValue.Location = new System.Drawing.Point(96, 40);
            this.labelPowerValue.Name = "labelPowerValue";
            this.labelPowerValue.Size = new System.Drawing.Size(16, 17);
            this.labelPowerValue.TabIndex = 12;
            this.labelPowerValue.Text = "0";
            // 
            // labelFreq
            // 
            this.labelFreq.AutoSize = true;
            this.labelFreq.Location = new System.Drawing.Point(196, 40);
            this.labelFreq.Name = "labelFreq";
            this.labelFreq.Size = new System.Drawing.Size(108, 17);
            this.labelFreq.TabIndex = 13;
            this.labelFreq.Text = "Frekvencia(Hz):";
            // 
            // labelFreqValue
            // 
            this.labelFreqValue.AutoSize = true;
            this.labelFreqValue.Location = new System.Drawing.Point(327, 40);
            this.labelFreqValue.Name = "labelFreqValue";
            this.labelFreqValue.Size = new System.Drawing.Size(16, 17);
            this.labelFreqValue.TabIndex = 14;
            this.labelFreqValue.Text = "0";
            // 
            // buttonStartLive
            // 
            this.buttonStartLive.Location = new System.Drawing.Point(11, 40);
            this.buttonStartLive.Name = "buttonStartLive";
            this.buttonStartLive.Size = new System.Drawing.Size(91, 41);
            this.buttonStartLive.TabIndex = 15;
            this.buttonStartLive.Text = "Start";
            this.buttonStartLive.UseVisualStyleBackColor = true;
            this.buttonStartLive.Click += new System.EventHandler(this.buttonStartLive_Click);
            // 
            // buttonStopLive
            // 
            this.buttonStopLive.Location = new System.Drawing.Point(123, 40);
            this.buttonStopLive.Name = "buttonStopLive";
            this.buttonStopLive.Size = new System.Drawing.Size(103, 41);
            this.buttonStopLive.TabIndex = 16;
            this.buttonStopLive.Text = "Stop";
            this.buttonStopLive.UseVisualStyleBackColor = true;
            this.buttonStopLive.Click += new System.EventHandler(this.buttonStopLive_Click);
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Location = new System.Drawing.Point(402, 40);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(46, 17);
            this.labelKey.TabIndex = 17;
            this.labelKey.Text = "Hang:";
            // 
            // labelKeyValue
            // 
            this.labelKeyValue.AutoSize = true;
            this.labelKeyValue.Location = new System.Drawing.Point(454, 40);
            this.labelKeyValue.Name = "labelKeyValue";
            this.labelKeyValue.Size = new System.Drawing.Size(67, 17);
            this.labelKeyValue.TabIndex = 18;
            this.labelKeyValue.Text = "alaphang";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonStop);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Felvétel";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.labelKeyValue);
            this.groupBox2.Controls.Add(this.labelKey);
            this.groupBox2.Controls.Add(this.labelFreqValue);
            this.groupBox2.Controls.Add(this.labelFreq);
            this.groupBox2.Controls.Add(this.labelPowerValue);
            this.groupBox2.Controls.Add(this.labelPower);
            this.groupBox2.Location = new System.Drawing.Point(445, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 88);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hangoló";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 137);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // trackBarTunerScale
            // 
            this.trackBarTunerScale.Enabled = false;
            this.trackBarTunerScale.Location = new System.Drawing.Point(29, 47);
            this.trackBarTunerScale.Maximum = 107;
            this.trackBarTunerScale.Minimum = 90;
            this.trackBarTunerScale.Name = "trackBarTunerScale";
            this.trackBarTunerScale.Size = new System.Drawing.Size(513, 56);
            this.trackBarTunerScale.TabIndex = 100;
            this.trackBarTunerScale.Value = 90;
            // 
            // labelLowKey
            // 
            this.labelLowKey.AutoSize = true;
            this.labelLowKey.Location = new System.Drawing.Point(26, 16);
            this.labelLowKey.Name = "labelLowKey";
            this.labelLowKey.Size = new System.Drawing.Size(37, 17);
            this.labelLowKey.TabIndex = 23;
            this.labelLowKey.Text = "Mély";
            // 
            // labelHighKey
            // 
            this.labelHighKey.AutoSize = true;
            this.labelHighKey.Location = new System.Drawing.Point(510, 16);
            this.labelHighKey.Name = "labelHighKey";
            this.labelHighKey.Size = new System.Drawing.Size(50, 17);
            this.labelHighKey.TabIndex = 24;
            this.labelHighKey.Text = "Magas";
            // 
            // labelBaseKey
            // 
            this.labelBaseKey.AutoSize = true;
            this.labelBaseKey.ForeColor = System.Drawing.Color.Crimson;
            this.labelBaseKey.Location = new System.Drawing.Point(290, 18);
            this.labelBaseKey.Name = "labelBaseKey";
            this.labelBaseKey.Size = new System.Drawing.Size(68, 17);
            this.labelBaseKey.TabIndex = 25;
            this.labelBaseKey.Text = "Alaphang";
            // 
            // comboBoxRecordedSound
            // 
            this.comboBoxRecordedSound.FormattingEnabled = true;
            this.comboBoxRecordedSound.Location = new System.Drawing.Point(122, 54);
            this.comboBoxRecordedSound.Name = "comboBoxRecordedSound";
            this.comboBoxRecordedSound.Size = new System.Drawing.Size(121, 24);
            this.comboBoxRecordedSound.TabIndex = 101;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.trackBarTunerScale);
            this.groupBox4.Controls.Add(this.labelBaseKey);
            this.groupBox4.Controls.Add(this.labelHighKey);
            this.groupBox4.Controls.Add(this.labelLowKey);
            this.groupBox4.Location = new System.Drawing.Point(445, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(560, 114);
            this.groupBox4.TabIndex = 102;
            this.groupBox4.TabStop = false;
            // 
            // buttonFretboard
            // 
            this.buttonFretboard.Location = new System.Drawing.Point(250, 128);
            this.buttonFretboard.Name = "buttonFretboard";
            this.buttonFretboard.Size = new System.Drawing.Size(115, 34);
            this.buttonFretboard.TabIndex = 103;
            this.buttonFretboard.Text = "Gitártabulatúra";
            this.buttonFretboard.UseVisualStyleBackColor = true;
            this.buttonFretboard.Click += new System.EventHandler(this.buttonFretboard_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonFelvetel);
            this.groupBox5.Controls.Add(this.comboBoxRecordedSound);
            this.groupBox5.Location = new System.Drawing.Point(445, 232);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(262, 131);
            this.groupBox5.TabIndex = 106;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rögzített felvétel";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonStartLive);
            this.groupBox6.Controls.Add(this.buttonStopLive);
            this.groupBox6.Location = new System.Drawing.Point(713, 232);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(299, 131);
            this.groupBox6.TabIndex = 107;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Élő felvétel";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 373);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.buttonFretboard);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDevices);
            this.Controls.Add(this.comboBox1);
            this.Name = "MainForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTunerScale)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFelvetel;
        private System.Windows.Forms.Label labelPower;
        private System.Windows.Forms.Label labelFreq;
        private System.Windows.Forms.Button buttonStartLive;
        private System.Windows.Forms.Button buttonStopLive;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxRecordedSound;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonFretboard;
        public System.Windows.Forms.Label labelPowerValue;
        public System.Windows.Forms.Label labelFreqValue;
        public System.Windows.Forms.Label labelKeyValue;
        public System.Windows.Forms.TrackBar trackBarTunerScale;
        public System.Windows.Forms.Label labelLowKey;
        public System.Windows.Forms.Label labelHighKey;
        public System.Windows.Forms.Label labelBaseKey;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

