namespace Cs_WavEditor_v02
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.programmerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportRAWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findPeakLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseStereoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToStereoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToMonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mixLRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.silenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amplifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normaliseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programmingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shrinkExtendWavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareWavsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findLastNonzeroFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteIntoOppositeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.numericUpDownSelStart = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownSelEnd = new System.Windows.Forms.NumericUpDown();
            this.labelSelEnd = new System.Windows.Forms.Label();
            this.labelSelStart = new System.Windows.Forms.Label();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knownLimitationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelStart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(14, 76);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(135, 132);
            this.listBox1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 380);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 190);
            this.textBox1.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 700);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(912, 30);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(180, 24);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 24);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(151, 24);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSplitButton1.AutoSize = false;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmerModeToolStripMenuItem,
            this.audioModeToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(149, 28);
            this.toolStripSplitButton1.Text = "Programmer Mode";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // programmerModeToolStripMenuItem
            // 
            this.programmerModeToolStripMenuItem.Name = "programmerModeToolStripMenuItem";
            this.programmerModeToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.programmerModeToolStripMenuItem.Text = "Programmer Mode";
            this.programmerModeToolStripMenuItem.Click += new System.EventHandler(this.programmerModeToolStripMenuItem_Click);
            // 
            // audioModeToolStripMenuItem
            // 
            this.audioModeToolStripMenuItem.Name = "audioModeToolStripMenuItem";
            this.audioModeToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.audioModeToolStripMenuItem.Text = "Audio Mode";
            this.audioModeToolStripMenuItem.Click += new System.EventHandler(this.audioModeToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.analyseToolStripMenuItem,
            this.processToolStripMenuItem,
            this.programmingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportRAWToolStripMenuItem,
            this.exportTextToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportRAWToolStripMenuItem
            // 
            this.exportRAWToolStripMenuItem.Name = "exportRAWToolStripMenuItem";
            this.exportRAWToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exportRAWToolStripMenuItem.Text = "Export RAW";
            this.exportRAWToolStripMenuItem.Click += new System.EventHandler(this.exportRAWToolStripMenuItem_Click);
            // 
            // exportTextToolStripMenuItem
            // 
            this.exportTextToolStripMenuItem.Name = "exportTextToolStripMenuItem";
            this.exportTextToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exportTextToolStripMenuItem.Text = "Export Text";
            this.exportTextToolStripMenuItem.Click += new System.EventHandler(this.exportTextToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.pasteMixToolStripMenuItem,
            this.toolStripSeparator1,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator3,
            this.cropToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // pasteMixToolStripMenuItem
            // 
            this.pasteMixToolStripMenuItem.Name = "pasteMixToolStripMenuItem";
            this.pasteMixToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pasteMixToolStripMenuItem.Text = "Paste - Mix";
            this.pasteMixToolStripMenuItem.Click += new System.EventHandler(this.pasteMixToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(130, 6);
            // 
            // cropToolStripMenuItem
            // 
            this.cropToolStripMenuItem.Name = "cropToolStripMenuItem";
            this.cropToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cropToolStripMenuItem.Text = "Crop";
            this.cropToolStripMenuItem.Click += new System.EventHandler(this.cropToolStripMenuItem_Click);
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findPeakLevelToolStripMenuItem,
            this.analyseStereoToolStripMenuItem});
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.analyseToolStripMenuItem.Text = "Analyse";
            // 
            // findPeakLevelToolStripMenuItem
            // 
            this.findPeakLevelToolStripMenuItem.Name = "findPeakLevelToolStripMenuItem";
            this.findPeakLevelToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.findPeakLevelToolStripMenuItem.Text = "Find peak level";
            this.findPeakLevelToolStripMenuItem.Click += new System.EventHandler(this.findPeakLevelToolStripMenuItem_Click_1);
            // 
            // analyseStereoToolStripMenuItem
            // 
            this.analyseStereoToolStripMenuItem.Name = "analyseStereoToolStripMenuItem";
            this.analyseStereoToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.analyseStereoToolStripMenuItem.Text = "Analyse Stereo";
            this.analyseStereoToolStripMenuItem.Click += new System.EventHandler(this.analyseStereoToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToStereoToolStripMenuItem,
            this.convertToMonoToolStripMenuItem,
            this.toolStripSeparator2,
            this.silenceToolStripMenuItem,
            this.amplifyToolStripMenuItem,
            this.normaliseToolStripMenuItem,
            this.resampleToolStripMenuItem,
            this.playToolStripMenuItem,
            this.generateSoundToolStripMenuItem,
            this.changeBitDepthToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // convertToStereoToolStripMenuItem
            // 
            this.convertToStereoToolStripMenuItem.Name = "convertToStereoToolStripMenuItem";
            this.convertToStereoToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.convertToStereoToolStripMenuItem.Text = "Convert To Stereo";
            this.convertToStereoToolStripMenuItem.Click += new System.EventHandler(this.convertToStereoToolStripMenuItem_Click);
            // 
            // convertToMonoToolStripMenuItem
            // 
            this.convertToMonoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mixLRToolStripMenuItem,
            this.useLToolStripMenuItem,
            this.useRToolStripMenuItem});
            this.convertToMonoToolStripMenuItem.Name = "convertToMonoToolStripMenuItem";
            this.convertToMonoToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.convertToMonoToolStripMenuItem.Text = "Convert To Mono";
            this.convertToMonoToolStripMenuItem.Click += new System.EventHandler(this.convertToMonoToolStripMenuItem_Click);
            // 
            // mixLRToolStripMenuItem
            // 
            this.mixLRToolStripMenuItem.Name = "mixLRToolStripMenuItem";
            this.mixLRToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.mixLRToolStripMenuItem.Text = "Mix L+R";
            this.mixLRToolStripMenuItem.Click += new System.EventHandler(this.mixLRToolStripMenuItem_Click);
            // 
            // useLToolStripMenuItem
            // 
            this.useLToolStripMenuItem.Name = "useLToolStripMenuItem";
            this.useLToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.useLToolStripMenuItem.Text = "Use L";
            this.useLToolStripMenuItem.Click += new System.EventHandler(this.useLToolStripMenuItem_Click);
            // 
            // useRToolStripMenuItem
            // 
            this.useRToolStripMenuItem.Name = "useRToolStripMenuItem";
            this.useRToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.useRToolStripMenuItem.Text = "Use R";
            this.useRToolStripMenuItem.Click += new System.EventHandler(this.useRToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // silenceToolStripMenuItem
            // 
            this.silenceToolStripMenuItem.Name = "silenceToolStripMenuItem";
            this.silenceToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.silenceToolStripMenuItem.Text = "Silence";
            this.silenceToolStripMenuItem.Click += new System.EventHandler(this.silenceToolStripMenuItem_Click);
            // 
            // amplifyToolStripMenuItem
            // 
            this.amplifyToolStripMenuItem.Name = "amplifyToolStripMenuItem";
            this.amplifyToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.amplifyToolStripMenuItem.Text = "Amplify";
            this.amplifyToolStripMenuItem.Click += new System.EventHandler(this.amplifyToolStripMenuItem_Click);
            // 
            // normaliseToolStripMenuItem
            // 
            this.normaliseToolStripMenuItem.Name = "normaliseToolStripMenuItem";
            this.normaliseToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.normaliseToolStripMenuItem.Text = "Normalise";
            this.normaliseToolStripMenuItem.Click += new System.EventHandler(this.normaliseToolStripMenuItem_Click);
            // 
            // resampleToolStripMenuItem
            // 
            this.resampleToolStripMenuItem.Name = "resampleToolStripMenuItem";
            this.resampleToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.resampleToolStripMenuItem.Text = "Resample";
            this.resampleToolStripMenuItem.Click += new System.EventHandler(this.resampleToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // generateSoundToolStripMenuItem
            // 
            this.generateSoundToolStripMenuItem.Name = "generateSoundToolStripMenuItem";
            this.generateSoundToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.generateSoundToolStripMenuItem.Text = "Generate Sound";
            this.generateSoundToolStripMenuItem.Click += new System.EventHandler(this.generateSoundToolStripMenuItem_Click);
            // 
            // changeBitDepthToolStripMenuItem
            // 
            this.changeBitDepthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bit8ToolStripMenuItem,
            this.bit16ToolStripMenuItem,
            this.bit24ToolStripMenuItem});
            this.changeBitDepthToolStripMenuItem.Name = "changeBitDepthToolStripMenuItem";
            this.changeBitDepthToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.changeBitDepthToolStripMenuItem.Text = "Change Bit-Depth";
            // 
            // bit8ToolStripMenuItem
            // 
            this.bit8ToolStripMenuItem.Name = "bit8ToolStripMenuItem";
            this.bit8ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.bit8ToolStripMenuItem.Text = "8-Bit";
            this.bit8ToolStripMenuItem.Click += new System.EventHandler(this.bit8ToolStripMenuItem_Click);
            // 
            // bit16ToolStripMenuItem
            // 
            this.bit16ToolStripMenuItem.Name = "bit16ToolStripMenuItem";
            this.bit16ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.bit16ToolStripMenuItem.Text = "16-Bit";
            this.bit16ToolStripMenuItem.Click += new System.EventHandler(this.bit16ToolStripMenuItem_Click);
            // 
            // bit24ToolStripMenuItem
            // 
            this.bit24ToolStripMenuItem.Name = "bit24ToolStripMenuItem";
            this.bit24ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.bit24ToolStripMenuItem.Text = "24-Bit";
            this.bit24ToolStripMenuItem.Click += new System.EventHandler(this.bit24ToolStripMenuItem_Click);
            // 
            // programmingToolStripMenuItem
            // 
            this.programmingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shrinkExtendWavToolStripMenuItem,
            this.compareWavsToolStripMenuItem,
            this.findLastNonzeroFrameToolStripMenuItem,
            this.pasteIntoOppositeChannelToolStripMenuItem});
            this.programmingToolStripMenuItem.Name = "programmingToolStripMenuItem";
            this.programmingToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.programmingToolStripMenuItem.Text = "Programming";
            // 
            // shrinkExtendWavToolStripMenuItem
            // 
            this.shrinkExtendWavToolStripMenuItem.Name = "shrinkExtendWavToolStripMenuItem";
            this.shrinkExtendWavToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.shrinkExtendWavToolStripMenuItem.Text = "Shrink/Extend Wav";
            this.shrinkExtendWavToolStripMenuItem.Click += new System.EventHandler(this.shrinkExtendWavToolStripMenuItem_Click);
            // 
            // compareWavsToolStripMenuItem
            // 
            this.compareWavsToolStripMenuItem.Name = "compareWavsToolStripMenuItem";
            this.compareWavsToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.compareWavsToolStripMenuItem.Text = "Compare Wavs";
            this.compareWavsToolStripMenuItem.Click += new System.EventHandler(this.compareWavsToolStripMenuItem_Click);
            // 
            // findLastNonzeroFrameToolStripMenuItem
            // 
            this.findLastNonzeroFrameToolStripMenuItem.Name = "findLastNonzeroFrameToolStripMenuItem";
            this.findLastNonzeroFrameToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.findLastNonzeroFrameToolStripMenuItem.Text = "Find Last Non-zero Frame";
            this.findLastNonzeroFrameToolStripMenuItem.Click += new System.EventHandler(this.findLastNonzeroFrameToolStripMenuItem_Click);
            // 
            // pasteIntoOppositeChannelToolStripMenuItem
            // 
            this.pasteIntoOppositeChannelToolStripMenuItem.Name = "pasteIntoOppositeChannelToolStripMenuItem";
            this.pasteIntoOppositeChannelToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.pasteIntoOppositeChannelToolStripMenuItem.Text = "Paste Into Opposite Channel";
            this.pasteIntoOppositeChannelToolStripMenuItem.Click += new System.EventHandler(this.pasteIntoOppositeChannelToolStripMenuItem_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(14, 223);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(135, 150);
            this.propertyGrid1.TabIndex = 13;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // numericUpDownSelStart
            // 
            this.numericUpDownSelStart.Location = new System.Drawing.Point(216, 2);
            this.numericUpDownSelStart.Name = "numericUpDownSelStart";
            this.numericUpDownSelStart.Size = new System.Drawing.Size(92, 22);
            this.numericUpDownSelStart.TabIndex = 15;
            this.numericUpDownSelStart.ValueChanged += new System.EventHandler(this.numericUpDownSelStart_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBarZoom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDownSelEnd);
            this.panel1.Controls.Add(this.labelSelEnd);
            this.panel1.Controls.Add(this.labelSelStart);
            this.panel1.Controls.Add(this.numericUpDownSelStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 42);
            this.panel1.TabIndex = 16;
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Location = new System.Drawing.Point(534, 5);
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(125, 56);
            this.trackBarZoom.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Zoom";
            // 
            // numericUpDownSelEnd
            // 
            this.numericUpDownSelEnd.Location = new System.Drawing.Point(368, 1);
            this.numericUpDownSelEnd.Name = "numericUpDownSelEnd";
            this.numericUpDownSelEnd.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownSelEnd.TabIndex = 18;
            this.numericUpDownSelEnd.ValueChanged += new System.EventHandler(this.numericUpDownSelEnd_ValueChanged);
            // 
            // labelSelEnd
            // 
            this.labelSelEnd.AutoSize = true;
            this.labelSelEnd.Location = new System.Drawing.Point(329, 5);
            this.labelSelEnd.Name = "labelSelEnd";
            this.labelSelEnd.Size = new System.Drawing.Size(33, 17);
            this.labelSelEnd.TabIndex = 17;
            this.labelSelEnd.Text = "End";
            // 
            // labelSelStart
            // 
            this.labelSelStart.AutoSize = true;
            this.labelSelStart.Location = new System.Drawing.Point(174, 5);
            this.labelSelStart.Name = "labelSelStart";
            this.labelSelStart.Size = new System.Drawing.Size(38, 17);
            this.labelSelStart.TabIndex = 16;
            this.labelSelStart.Text = "Start";
            // 
            // helpToolStripMenuItem
            // 
            // bit8ToolStripMenuItem
            // 
            this.bit8ToolStripMenuItem.Name = "bit8ToolStripMenuItem";
            this.bit8ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bit8ToolStripMenuItem.Text = "8-Bit";
            this.bit8ToolStripMenuItem.Click += new System.EventHandler(this.bit8ToolStripMenuItem_Click);
            // 
            // bit16ToolStripMenuItem
            // 
            this.bit16ToolStripMenuItem.Name = "bit16ToolStripMenuItem";
            this.bit16ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bit16ToolStripMenuItem.Text = "16-Bit";
            this.bit16ToolStripMenuItem.Click += new System.EventHandler(this.bit16ToolStripMenuItem_Click);
            // 
            // bit24ToolStripMenuItem
            // 
            this.bit24ToolStripMenuItem.Name = "bit24ToolStripMenuItem";
            this.bit24ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bit24ToolStripMenuItem.Text = "24-Bit";
            this.bit24ToolStripMenuItem.Click += new System.EventHandler(this.bit24ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(912, 730);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelStart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.NumericUpDown numericUpDownSelStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownSelEnd;
        private System.Windows.Forms.Label labelSelEnd;
        private System.Windows.Forms.Label labelSelStart;
        private System.Windows.Forms.ToolStripMenuItem convertToStereoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToMonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem analyseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findPeakLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseStereoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportRAWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem programmerModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mixLRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amplifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normaliseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resampleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateSoundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programmingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shrinkExtendWavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareWavsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findLastNonzeroFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteIntoOppositeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBitDepthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bit8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bit16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bit24ToolStripMenuItem;
    }
}

