namespace Cs_WavEditor_v02
{
    partial class Dialog_Prog_ShrinkExtend
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelOriginalLength = new System.Windows.Forms.Label();
            this.textBoxOriginalLength = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericNearestValue = new System.Windows.Forms.NumericUpDown();
            this.radioBtnExtendSpecific = new System.Windows.Forms.RadioButton();
            this.radioBtnExtendNearestN = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNewLength = new System.Windows.Forms.TextBox();
            this.numericSpecificValue = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNearestValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecificValue)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(114, 216);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelOriginalLength
            // 
            this.labelOriginalLength.AutoSize = true;
            this.labelOriginalLength.Location = new System.Drawing.Point(13, 13);
            this.labelOriginalLength.Name = "labelOriginalLength";
            this.labelOriginalLength.Size = new System.Drawing.Size(78, 13);
            this.labelOriginalLength.TabIndex = 2;
            this.labelOriginalLength.Text = "Original Length";
            // 
            // textBoxOriginalLength
            // 
            this.textBoxOriginalLength.Location = new System.Drawing.Point(127, 10);
            this.textBoxOriginalLength.Name = "textBoxOriginalLength";
            this.textBoxOriginalLength.ReadOnly = true;
            this.textBoxOriginalLength.Size = new System.Drawing.Size(100, 20);
            this.textBoxOriginalLength.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericSpecificValue);
            this.panel1.Controls.Add(this.numericNearestValue);
            this.panel1.Controls.Add(this.radioBtnExtendSpecific);
            this.panel1.Controls.Add(this.radioBtnExtendNearestN);
            this.panel1.Location = new System.Drawing.Point(16, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 120);
            this.panel1.TabIndex = 5;
            // 
            // numericNearestValue
            // 
            this.numericNearestValue.Location = new System.Drawing.Point(111, 28);
            this.numericNearestValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericNearestValue.Name = "numericNearestValue";
            this.numericNearestValue.Size = new System.Drawing.Size(77, 20);
            this.numericNearestValue.TabIndex = 2;
            this.numericNearestValue.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericNearestValue.ValueChanged += new System.EventHandler(this.numericNearestValue_ValueChanged);
            // 
            // radioBtnExtendSpecific
            // 
            this.radioBtnExtendSpecific.AutoSize = true;
            this.radioBtnExtendSpecific.Location = new System.Drawing.Point(4, 54);
            this.radioBtnExtendSpecific.Name = "radioBtnExtendSpecific";
            this.radioBtnExtendSpecific.Size = new System.Drawing.Size(93, 17);
            this.radioBtnExtendSpecific.TabIndex = 1;
            this.radioBtnExtendSpecific.Text = "Specific Value";
            this.radioBtnExtendSpecific.UseVisualStyleBackColor = true;
            this.radioBtnExtendSpecific.CheckedChanged += new System.EventHandler(this.radioBtnExtendSpecific_CheckedChanged);
            // 
            // radioBtnExtendNearestN
            // 
            this.radioBtnExtendNearestN.AutoSize = true;
            this.radioBtnExtendNearestN.Checked = true;
            this.radioBtnExtendNearestN.Location = new System.Drawing.Point(4, 4);
            this.radioBtnExtendNearestN.Name = "radioBtnExtendNearestN";
            this.radioBtnExtendNearestN.Size = new System.Drawing.Size(110, 17);
            this.radioBtnExtendNearestN.TabIndex = 0;
            this.radioBtnExtendNearestN.TabStop = true;
            this.radioBtnExtendNearestN.Text = "Nearest Boundary";
            this.radioBtnExtendNearestN.UseVisualStyleBackColor = true;
            this.radioBtnExtendNearestN.CheckedChanged += new System.EventHandler(this.radioBtnExtendNearestN_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "New Length";
            // 
            // textBoxNewLength
            // 
            this.textBoxNewLength.Location = new System.Drawing.Point(127, 175);
            this.textBoxNewLength.Name = "textBoxNewLength";
            this.textBoxNewLength.ReadOnly = true;
            this.textBoxNewLength.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewLength.TabIndex = 7;
            // 
            // numericSpecificValue
            // 
            this.numericSpecificValue.Location = new System.Drawing.Point(111, 73);
            this.numericSpecificValue.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericSpecificValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSpecificValue.Name = "numericSpecificValue";
            this.numericSpecificValue.Size = new System.Drawing.Size(77, 20);
            this.numericSpecificValue.TabIndex = 3;
            this.numericSpecificValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSpecificValue.ValueChanged += new System.EventHandler(this.numericSpecificValue_ValueChanged);
            // 
            // Dialog_Prog_ShrinkExtend
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxNewLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxOriginalLength);
            this.Controls.Add(this.labelOriginalLength);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_Prog_ShrinkExtend";
            this.Text = "Shrink Or Extend";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericNearestValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpecificValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelOriginalLength;
        private System.Windows.Forms.TextBox textBoxOriginalLength;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioBtnExtendSpecific;
        private System.Windows.Forms.RadioButton radioBtnExtendNearestN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNewLength;
        private System.Windows.Forms.NumericUpDown numericNearestValue;
        private System.Windows.Forms.NumericUpDown numericSpecificValue;
    }
}