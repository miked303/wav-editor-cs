namespace Cs_WavEditor_v02
{
    partial class Form_NewWav
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnMono = new System.Windows.Forms.RadioButton();
            this.radioBtnStereo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioBtn11025 = new System.Windows.Forms.RadioButton();
            this.radioBtn22050 = new System.Windows.Forms.RadioButton();
            this.radioBtn44100 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioBtnBitD8 = new System.Windows.Forms.RadioButton();
            this.radioBtnBitD16 = new System.Windows.Forms.RadioButton();
            this.radioBtnBitD24 = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.radioBtn48000 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnStereo);
            this.groupBox1.Controls.Add(this.radioBtnMono);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Channels";
            // 
            // radioBtnMono
            // 
            this.radioBtnMono.AutoSize = true;
            this.radioBtnMono.Location = new System.Drawing.Point(7, 20);
            this.radioBtnMono.Name = "radioBtnMono";
            this.radioBtnMono.Size = new System.Drawing.Size(52, 17);
            this.radioBtnMono.TabIndex = 0;
            this.radioBtnMono.Text = "Mono";
            this.radioBtnMono.UseVisualStyleBackColor = true;
            // 
            // radioBtnStereo
            // 
            this.radioBtnStereo.AutoSize = true;
            this.radioBtnStereo.Checked = true;
            this.radioBtnStereo.Location = new System.Drawing.Point(122, 20);
            this.radioBtnStereo.Name = "radioBtnStereo";
            this.radioBtnStereo.Size = new System.Drawing.Size(56, 17);
            this.radioBtnStereo.TabIndex = 1;
            this.radioBtnStereo.TabStop = true;
            this.radioBtnStereo.Text = "Stereo";
            this.radioBtnStereo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioBtn48000);
            this.groupBox2.Controls.Add(this.radioBtn44100);
            this.groupBox2.Controls.Add(this.radioBtn22050);
            this.groupBox2.Controls.Add(this.radioBtn11025);
            this.groupBox2.Location = new System.Drawing.Point(13, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample Rate";
            // 
            // radioBtn11025
            // 
            this.radioBtn11025.AutoSize = true;
            this.radioBtn11025.Location = new System.Drawing.Point(7, 20);
            this.radioBtn11025.Name = "radioBtn11025";
            this.radioBtn11025.Size = new System.Drawing.Size(55, 17);
            this.radioBtn11025.TabIndex = 0;
            this.radioBtn11025.Text = "11025";
            this.radioBtn11025.UseVisualStyleBackColor = true;
            // 
            // radioBtn22050
            // 
            this.radioBtn22050.AutoSize = true;
            this.radioBtn22050.Location = new System.Drawing.Point(122, 19);
            this.radioBtn22050.Name = "radioBtn22050";
            this.radioBtn22050.Size = new System.Drawing.Size(55, 17);
            this.radioBtn22050.TabIndex = 1;
            this.radioBtn22050.Text = "22050";
            this.radioBtn22050.UseVisualStyleBackColor = true;
            // 
            // radioBtn44100
            // 
            this.radioBtn44100.AutoSize = true;
            this.radioBtn44100.Checked = true;
            this.radioBtn44100.Location = new System.Drawing.Point(7, 43);
            this.radioBtn44100.Name = "radioBtn44100";
            this.radioBtn44100.Size = new System.Drawing.Size(55, 17);
            this.radioBtn44100.TabIndex = 2;
            this.radioBtn44100.TabStop = true;
            this.radioBtn44100.Text = "44100";
            this.radioBtn44100.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioBtnBitD24);
            this.groupBox3.Controls.Add(this.radioBtnBitD16);
            this.groupBox3.Controls.Add(this.radioBtnBitD8);
            this.groupBox3.Location = new System.Drawing.Point(13, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 77);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bit Depth";
            // 
            // radioBtnBitD8
            // 
            this.radioBtnBitD8.AutoSize = true;
            this.radioBtnBitD8.Location = new System.Drawing.Point(7, 20);
            this.radioBtnBitD8.Name = "radioBtnBitD8";
            this.radioBtnBitD8.Size = new System.Drawing.Size(45, 17);
            this.radioBtnBitD8.TabIndex = 0;
            this.radioBtnBitD8.Text = "8 bit";
            this.radioBtnBitD8.UseVisualStyleBackColor = true;
            // 
            // radioBtnBitD16
            // 
            this.radioBtnBitD16.AutoSize = true;
            this.radioBtnBitD16.Checked = true;
            this.radioBtnBitD16.Location = new System.Drawing.Point(122, 20);
            this.radioBtnBitD16.Name = "radioBtnBitD16";
            this.radioBtnBitD16.Size = new System.Drawing.Size(51, 17);
            this.radioBtnBitD16.TabIndex = 1;
            this.radioBtnBitD16.TabStop = true;
            this.radioBtnBitD16.Text = "16 bit";
            this.radioBtnBitD16.UseVisualStyleBackColor = true;
            // 
            // radioBtnBitD24
            // 
            this.radioBtnBitD24.AutoSize = true;
            this.radioBtnBitD24.Location = new System.Drawing.Point(7, 43);
            this.radioBtnBitD24.Name = "radioBtnBitD24";
            this.radioBtnBitD24.Size = new System.Drawing.Size(51, 17);
            this.radioBtnBitD24.TabIndex = 2;
            this.radioBtnBitD24.Text = "24 bit";
            this.radioBtnBitD24.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(175, 282);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(94, 282);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // radioBtn48000
            // 
            this.radioBtn48000.AutoSize = true;
            this.radioBtn48000.Location = new System.Drawing.Point(122, 43);
            this.radioBtn48000.Name = "radioBtn48000";
            this.radioBtn48000.Size = new System.Drawing.Size(55, 17);
            this.radioBtn48000.TabIndex = 3;
            this.radioBtn48000.TabStop = true;
            this.radioBtn48000.Text = "48000";
            this.radioBtn48000.UseVisualStyleBackColor = true;
            // 
            // Form_NewWav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 317);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_NewWav";
            this.Text = "New WAV";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnStereo;
        private System.Windows.Forms.RadioButton radioBtnMono;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioBtn44100;
        private System.Windows.Forms.RadioButton radioBtn22050;
        private System.Windows.Forms.RadioButton radioBtn11025;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioBtnBitD24;
        private System.Windows.Forms.RadioButton radioBtnBitD16;
        private System.Windows.Forms.RadioButton radioBtnBitD8;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RadioButton radioBtn48000;
    }
}