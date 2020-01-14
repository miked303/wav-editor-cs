namespace Cs_WavEditor_v02
{
    partial class Dialog_ExportText
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
            this.groupBoxNumberFormat = new System.Windows.Forms.GroupBox();
            this.radioHex = new System.Windows.Forms.RadioButton();
            this.radioDecimal = new System.Windows.Forms.RadioButton();
            this.groupBoxEndianness = new System.Windows.Forms.GroupBox();
            this.radioEndianBig = new System.Windows.Forms.RadioButton();
            this.radioEndianSmall = new System.Windows.Forms.RadioButton();
            this.numericValuesPerLine = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxGroupSingleValues = new System.Windows.Forms.CheckBox();
            this.checkBoxPrintSampleNumber = new System.Windows.Forms.CheckBox();
            this.labelMaxFrames = new System.Windows.Forms.Label();
            this.numericMaxValuesPerDoc = new System.Windows.Forms.NumericUpDown();
            this.checkBoxSplitLongFile = new System.Windows.Forms.CheckBox();
            this.labelSplitFileInfo = new System.Windows.Forms.Label();
            this.groupBoxNumberFormat.SuspendLayout();
            this.groupBoxEndianness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValuesPerLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxValuesPerDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(371, 206);
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
            this.buttonCancel.Location = new System.Drawing.Point(452, 206);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxNumberFormat
            // 
            this.groupBoxNumberFormat.Controls.Add(this.radioHex);
            this.groupBoxNumberFormat.Controls.Add(this.radioDecimal);
            this.groupBoxNumberFormat.Location = new System.Drawing.Point(13, 13);
            this.groupBoxNumberFormat.Name = "groupBoxNumberFormat";
            this.groupBoxNumberFormat.Size = new System.Drawing.Size(169, 56);
            this.groupBoxNumberFormat.TabIndex = 2;
            this.groupBoxNumberFormat.TabStop = false;
            this.groupBoxNumberFormat.Text = "Number Format";
            // 
            // radioHex
            // 
            this.radioHex.AutoSize = true;
            this.radioHex.Checked = true;
            this.radioHex.Location = new System.Drawing.Point(99, 20);
            this.radioHex.Name = "radioHex";
            this.radioHex.Size = new System.Drawing.Size(44, 17);
            this.radioHex.TabIndex = 1;
            this.radioHex.TabStop = true;
            this.radioHex.Text = "Hex";
            this.radioHex.UseVisualStyleBackColor = true;
            this.radioHex.CheckedChanged += new System.EventHandler(this.radioHex_CheckedChanged);
            // 
            // radioDecimal
            // 
            this.radioDecimal.AutoSize = true;
            this.radioDecimal.Location = new System.Drawing.Point(7, 20);
            this.radioDecimal.Name = "radioDecimal";
            this.radioDecimal.Size = new System.Drawing.Size(63, 17);
            this.radioDecimal.TabIndex = 0;
            this.radioDecimal.Text = "Decimal";
            this.radioDecimal.UseVisualStyleBackColor = true;
            this.radioDecimal.CheckedChanged += new System.EventHandler(this.radioDecimal_CheckedChanged);
            // 
            // groupBoxEndianness
            // 
            this.groupBoxEndianness.Controls.Add(this.radioEndianBig);
            this.groupBoxEndianness.Controls.Add(this.radioEndianSmall);
            this.groupBoxEndianness.Location = new System.Drawing.Point(13, 88);
            this.groupBoxEndianness.Name = "groupBoxEndianness";
            this.groupBoxEndianness.Size = new System.Drawing.Size(169, 84);
            this.groupBoxEndianness.TabIndex = 3;
            this.groupBoxEndianness.TabStop = false;
            this.groupBoxEndianness.Text = "Format";
            // 
            // radioEndianBig
            // 
            this.radioEndianBig.AutoSize = true;
            this.radioEndianBig.Location = new System.Drawing.Point(7, 43);
            this.radioEndianBig.Name = "radioEndianBig";
            this.radioEndianBig.Size = new System.Drawing.Size(76, 17);
            this.radioEndianBig.TabIndex = 1;
            this.radioEndianBig.Text = "Big Endian";
            this.radioEndianBig.UseVisualStyleBackColor = true;
            this.radioEndianBig.CheckedChanged += new System.EventHandler(this.radioEndianBig_CheckedChanged);
            // 
            // radioEndianSmall
            // 
            this.radioEndianSmall.AutoSize = true;
            this.radioEndianSmall.Checked = true;
            this.radioEndianSmall.Location = new System.Drawing.Point(7, 20);
            this.radioEndianSmall.Name = "radioEndianSmall";
            this.radioEndianSmall.Size = new System.Drawing.Size(124, 17);
            this.radioEndianSmall.TabIndex = 0;
            this.radioEndianSmall.TabStop = true;
            this.radioEndianSmall.Text = "Little Endian (default)";
            this.radioEndianSmall.UseVisualStyleBackColor = true;
            this.radioEndianSmall.CheckedChanged += new System.EventHandler(this.radioEndianSmall_CheckedChanged);
            // 
            // numericValuesPerLine
            // 
            this.numericValuesPerLine.Location = new System.Drawing.Point(289, 33);
            this.numericValuesPerLine.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericValuesPerLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericValuesPerLine.Name = "numericValuesPerLine";
            this.numericValuesPerLine.Size = new System.Drawing.Size(63, 20);
            this.numericValuesPerLine.TabIndex = 4;
            this.numericValuesPerLine.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericValuesPerLine.ValueChanged += new System.EventHandler(this.numericValuesPerLine_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Values Per Line";
            // 
            // checkBoxGroupSingleValues
            // 
            this.checkBoxGroupSingleValues.AutoSize = true;
            this.checkBoxGroupSingleValues.Location = new System.Drawing.Point(230, 59);
            this.checkBoxGroupSingleValues.Name = "checkBoxGroupSingleValues";
            this.checkBoxGroupSingleValues.Size = new System.Drawing.Size(233, 17);
            this.checkBoxGroupSingleValues.TabIndex = 6;
            this.checkBoxGroupSingleValues.Text = "Group Stereo Values (if values per line == 1)";
            this.checkBoxGroupSingleValues.UseVisualStyleBackColor = true;
            this.checkBoxGroupSingleValues.CheckedChanged += new System.EventHandler(this.checkBoxGroupSingleValues_CheckedChanged);
            // 
            // checkBoxPrintSampleNumber
            // 
            this.checkBoxPrintSampleNumber.AutoSize = true;
            this.checkBoxPrintSampleNumber.Location = new System.Drawing.Point(205, 108);
            this.checkBoxPrintSampleNumber.Name = "checkBoxPrintSampleNumber";
            this.checkBoxPrintSampleNumber.Size = new System.Drawing.Size(125, 17);
            this.checkBoxPrintSampleNumber.TabIndex = 7;
            this.checkBoxPrintSampleNumber.Text = "Print Sample Number";
            this.checkBoxPrintSampleNumber.UseVisualStyleBackColor = true;
            this.checkBoxPrintSampleNumber.CheckedChanged += new System.EventHandler(this.checkBoxPrintSampleNumber_CheckedChanged);
            // 
            // labelMaxFrames
            // 
            this.labelMaxFrames.AutoSize = true;
            this.labelMaxFrames.Location = new System.Drawing.Point(227, 166);
            this.labelMaxFrames.Name = "labelMaxFrames";
            this.labelMaxFrames.Size = new System.Drawing.Size(64, 13);
            this.labelMaxFrames.TabIndex = 8;
            this.labelMaxFrames.Text = "Max Frames";
            // 
            // numericMaxValuesPerDoc
            // 
            this.numericMaxValuesPerDoc.Location = new System.Drawing.Point(306, 164);
            this.numericMaxValuesPerDoc.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericMaxValuesPerDoc.Name = "numericMaxValuesPerDoc";
            this.numericMaxValuesPerDoc.Size = new System.Drawing.Size(63, 20);
            this.numericMaxValuesPerDoc.TabIndex = 9;
            this.numericMaxValuesPerDoc.Value = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numericMaxValuesPerDoc.ValueChanged += new System.EventHandler(this.numericMaxValuesPerDoc_ValueChanged);
            // 
            // checkBoxSplitLongFile
            // 
            this.checkBoxSplitLongFile.AutoSize = true;
            this.checkBoxSplitLongFile.Location = new System.Drawing.Point(205, 141);
            this.checkBoxSplitLongFile.Name = "checkBoxSplitLongFile";
            this.checkBoxSplitLongFile.Size = new System.Drawing.Size(107, 17);
            this.checkBoxSplitLongFile.TabIndex = 10;
            this.checkBoxSplitLongFile.Text = "Split Long File up";
            this.checkBoxSplitLongFile.UseVisualStyleBackColor = true;
            this.checkBoxSplitLongFile.CheckedChanged += new System.EventHandler(this.checkBoxSplitLongFile_CheckedChanged);
            // 
            // labelSplitFileInfo
            // 
            this.labelSplitFileInfo.AutoSize = true;
            this.labelSplitFileInfo.Location = new System.Drawing.Point(390, 166);
            this.labelSplitFileInfo.Name = "labelSplitFileInfo";
            this.labelSplitFileInfo.Size = new System.Drawing.Size(11, 13);
            this.labelSplitFileInfo.TabIndex = 11;
            this.labelSplitFileInfo.Text = "*";
            // 
            // Dialog_ExportText
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(538, 248);
            this.Controls.Add(this.labelSplitFileInfo);
            this.Controls.Add(this.checkBoxSplitLongFile);
            this.Controls.Add(this.numericMaxValuesPerDoc);
            this.Controls.Add(this.labelMaxFrames);
            this.Controls.Add(this.checkBoxPrintSampleNumber);
            this.Controls.Add(this.checkBoxGroupSingleValues);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericValuesPerLine);
            this.Controls.Add(this.groupBoxEndianness);
            this.Controls.Add(this.groupBoxNumberFormat);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialog_ExportText";
            this.Text = "Export Text";
            this.groupBoxNumberFormat.ResumeLayout(false);
            this.groupBoxNumberFormat.PerformLayout();
            this.groupBoxEndianness.ResumeLayout(false);
            this.groupBoxEndianness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericValuesPerLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxValuesPerDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxNumberFormat;
        private System.Windows.Forms.RadioButton radioHex;
        private System.Windows.Forms.RadioButton radioDecimal;
        private System.Windows.Forms.GroupBox groupBoxEndianness;
        private System.Windows.Forms.RadioButton radioEndianBig;
        private System.Windows.Forms.RadioButton radioEndianSmall;
        private System.Windows.Forms.NumericUpDown numericValuesPerLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxGroupSingleValues;
        private System.Windows.Forms.CheckBox checkBoxPrintSampleNumber;
        private System.Windows.Forms.Label labelMaxFrames;
        private System.Windows.Forms.NumericUpDown numericMaxValuesPerDoc;
        private System.Windows.Forms.CheckBox checkBoxSplitLongFile;
        private System.Windows.Forms.Label labelSplitFileInfo;
    }
}