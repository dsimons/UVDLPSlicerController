namespace UV_DLP_3D_Printer
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.glControl1 = new OpenTK.GLControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbMove = new System.Windows.Forms.TabPage();
            this.txtZTrans = new System.Windows.Forms.TextBox();
            this.cmdZInc = new System.Windows.Forms.Button();
            this.cmdZdec = new System.Windows.Forms.Button();
            this.txtYTrans = new System.Windows.Forms.TextBox();
            this.cmdYInc = new System.Windows.Forms.Button();
            this.cmdYDec = new System.Windows.Forms.Button();
            this.txtXTrans = new System.Windows.Forms.TextBox();
            this.cmdXInc = new System.Windows.Forms.Button();
            this.cmdXDec = new System.Windows.Forms.Button();
            this.cmdCenter = new System.Windows.Forms.Button();
            this.cmdPlace = new System.Windows.Forms.Button();
            this.tbRotate = new System.Windows.Forms.TabPage();
            this.cmdYRInc = new System.Windows.Forms.Button();
            this.cmdYRDec = new System.Windows.Forms.Button();
            this.cmdZRInc = new System.Windows.Forms.Button();
            this.cmdZRDec = new System.Windows.Forms.Button();
            this.cmdXRInc = new System.Windows.Forms.Button();
            this.cmdXRDec = new System.Windows.Forms.Button();
            this.tbScale = new System.Windows.Forms.TabPage();
            this.cmdScale = new System.Windows.Forms.Button();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.chkWireframe = new System.Windows.Forms.CheckBox();
            this.treeScene = new System.Windows.Forms.TreeView();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabModel1 = new System.Windows.Forms.TabPage();
            this.tabGCode = new System.Windows.Forms.TabPage();
            this.txtGCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdReloadGCode = new System.Windows.Forms.Button();
            this.cmdSaveGCode = new System.Windows.Forms.Button();
            this.tabSliceView = new System.Windows.Forms.TabPage();
            this.picSlice = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdBuild = new System.Windows.Forms.ToolStripButton();
            this.cmdPause = new System.Windows.Forms.ToolStripButton();
            this.cmdStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdConnect = new System.Windows.Forms.ToolStripButton();
            this.cmdDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdControl = new System.Windows.Forms.ToolStripButton();
            this.cmdSlice1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdActions = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMainMessage = new System.Windows.Forms.ToolStripLabel();
            this.lblTime = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBinarySTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSceneSTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addManualSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAutomaticSupportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slicingOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendGCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageMachinesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.dLPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBlankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdRemoveObject = new System.Windows.Forms.ToolStripMenuItem();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbMove.SuspendLayout();
            this.tbRotate.SuspendLayout();
            this.tbScale.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabModel1.SuspendLayout();
            this.tabGCode.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabSliceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(2, 2);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(986, 529);
            this.glControl1.TabIndex = 15;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseLeave += new System.EventHandler(this.glControl1_MouseLeave);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.treeScene);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Panel2.Controls.Add(this.vScrollBar1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1238, 618);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 20;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbMove);
            this.tabControl1.Controls.Add(this.tbRotate);
            this.tabControl1.Controls.Add(this.tbScale);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 206);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(198, 408);
            this.tabControl1.TabIndex = 7;
            // 
            // tbMove
            // 
            this.tbMove.Controls.Add(this.txtZTrans);
            this.tbMove.Controls.Add(this.cmdZInc);
            this.tbMove.Controls.Add(this.cmdZdec);
            this.tbMove.Controls.Add(this.txtYTrans);
            this.tbMove.Controls.Add(this.cmdYInc);
            this.tbMove.Controls.Add(this.cmdYDec);
            this.tbMove.Controls.Add(this.txtXTrans);
            this.tbMove.Controls.Add(this.cmdXInc);
            this.tbMove.Controls.Add(this.cmdXDec);
            this.tbMove.Controls.Add(this.cmdCenter);
            this.tbMove.Controls.Add(this.cmdPlace);
            this.tbMove.Location = new System.Drawing.Point(4, 22);
            this.tbMove.Margin = new System.Windows.Forms.Padding(2);
            this.tbMove.Name = "tbMove";
            this.tbMove.Padding = new System.Windows.Forms.Padding(2);
            this.tbMove.Size = new System.Drawing.Size(190, 382);
            this.tbMove.TabIndex = 0;
            this.tbMove.Text = "Move";
            this.tbMove.UseVisualStyleBackColor = true;
            // 
            // txtZTrans
            // 
            this.txtZTrans.Location = new System.Drawing.Point(66, 144);
            this.txtZTrans.Margin = new System.Windows.Forms.Padding(2);
            this.txtZTrans.Name = "txtZTrans";
            this.txtZTrans.Size = new System.Drawing.Size(37, 20);
            this.txtZTrans.TabIndex = 12;
            this.txtZTrans.Text = "10";
            this.txtZTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdZInc
            // 
            this.cmdZInc.Location = new System.Drawing.Point(107, 139);
            this.cmdZInc.Margin = new System.Windows.Forms.Padding(2);
            this.cmdZInc.Name = "cmdZInc";
            this.cmdZInc.Size = new System.Drawing.Size(56, 28);
            this.cmdZInc.TabIndex = 11;
            this.cmdZInc.Text = "Z+";
            this.cmdZInc.UseVisualStyleBackColor = true;
            this.cmdZInc.Click += new System.EventHandler(this.cmdZInc_Click);
            // 
            // cmdZdec
            // 
            this.cmdZdec.Location = new System.Drawing.Point(5, 139);
            this.cmdZdec.Margin = new System.Windows.Forms.Padding(2);
            this.cmdZdec.Name = "cmdZdec";
            this.cmdZdec.Size = new System.Drawing.Size(56, 28);
            this.cmdZdec.TabIndex = 10;
            this.cmdZdec.Text = "Z-";
            this.cmdZdec.UseVisualStyleBackColor = true;
            this.cmdZdec.Click += new System.EventHandler(this.cmdZdec_Click);
            // 
            // txtYTrans
            // 
            this.txtYTrans.Location = new System.Drawing.Point(66, 106);
            this.txtYTrans.Margin = new System.Windows.Forms.Padding(2);
            this.txtYTrans.Name = "txtYTrans";
            this.txtYTrans.Size = new System.Drawing.Size(37, 20);
            this.txtYTrans.TabIndex = 9;
            this.txtYTrans.Text = "10";
            this.txtYTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdYInc
            // 
            this.cmdYInc.Location = new System.Drawing.Point(107, 101);
            this.cmdYInc.Margin = new System.Windows.Forms.Padding(2);
            this.cmdYInc.Name = "cmdYInc";
            this.cmdYInc.Size = new System.Drawing.Size(56, 28);
            this.cmdYInc.TabIndex = 8;
            this.cmdYInc.Text = "Y+";
            this.cmdYInc.UseVisualStyleBackColor = true;
            this.cmdYInc.Click += new System.EventHandler(this.cmdYInc_Click);
            // 
            // cmdYDec
            // 
            this.cmdYDec.Location = new System.Drawing.Point(5, 101);
            this.cmdYDec.Margin = new System.Windows.Forms.Padding(2);
            this.cmdYDec.Name = "cmdYDec";
            this.cmdYDec.Size = new System.Drawing.Size(56, 28);
            this.cmdYDec.TabIndex = 7;
            this.cmdYDec.Text = "Y-";
            this.cmdYDec.UseVisualStyleBackColor = true;
            this.cmdYDec.Click += new System.EventHandler(this.cmdYDec_Click);
            // 
            // txtXTrans
            // 
            this.txtXTrans.Location = new System.Drawing.Point(66, 67);
            this.txtXTrans.Margin = new System.Windows.Forms.Padding(2);
            this.txtXTrans.Name = "txtXTrans";
            this.txtXTrans.Size = new System.Drawing.Size(37, 20);
            this.txtXTrans.TabIndex = 6;
            this.txtXTrans.Text = "10";
            this.txtXTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdXInc
            // 
            this.cmdXInc.Location = new System.Drawing.Point(107, 63);
            this.cmdXInc.Margin = new System.Windows.Forms.Padding(2);
            this.cmdXInc.Name = "cmdXInc";
            this.cmdXInc.Size = new System.Drawing.Size(56, 28);
            this.cmdXInc.TabIndex = 5;
            this.cmdXInc.Text = "X+";
            this.cmdXInc.UseVisualStyleBackColor = true;
            this.cmdXInc.Click += new System.EventHandler(this.cmdXInc_Click);
            // 
            // cmdXDec
            // 
            this.cmdXDec.Location = new System.Drawing.Point(5, 63);
            this.cmdXDec.Margin = new System.Windows.Forms.Padding(2);
            this.cmdXDec.Name = "cmdXDec";
            this.cmdXDec.Size = new System.Drawing.Size(56, 28);
            this.cmdXDec.TabIndex = 4;
            this.cmdXDec.Text = "X-";
            this.cmdXDec.UseVisualStyleBackColor = true;
            this.cmdXDec.Click += new System.EventHandler(this.cmdXDec_Click);
            // 
            // cmdCenter
            // 
            this.cmdCenter.Location = new System.Drawing.Point(4, 12);
            this.cmdCenter.Margin = new System.Windows.Forms.Padding(2);
            this.cmdCenter.Name = "cmdCenter";
            this.cmdCenter.Size = new System.Drawing.Size(71, 37);
            this.cmdCenter.TabIndex = 2;
            this.cmdCenter.Text = "Center";
            this.cmdCenter.UseVisualStyleBackColor = true;
            this.cmdCenter.Click += new System.EventHandler(this.cmdCenter_Click);
            // 
            // cmdPlace
            // 
            this.cmdPlace.Location = new System.Drawing.Point(80, 12);
            this.cmdPlace.Margin = new System.Windows.Forms.Padding(2);
            this.cmdPlace.Name = "cmdPlace";
            this.cmdPlace.Size = new System.Drawing.Size(71, 37);
            this.cmdPlace.TabIndex = 3;
            this.cmdPlace.Text = "Place on Platform";
            this.cmdPlace.UseVisualStyleBackColor = true;
            this.cmdPlace.Click += new System.EventHandler(this.cmdPlace_Click);
            // 
            // tbRotate
            // 
            this.tbRotate.Controls.Add(this.cmdYRInc);
            this.tbRotate.Controls.Add(this.cmdYRDec);
            this.tbRotate.Controls.Add(this.cmdZRInc);
            this.tbRotate.Controls.Add(this.cmdZRDec);
            this.tbRotate.Controls.Add(this.cmdXRInc);
            this.tbRotate.Controls.Add(this.cmdXRDec);
            this.tbRotate.Location = new System.Drawing.Point(4, 22);
            this.tbRotate.Margin = new System.Windows.Forms.Padding(2);
            this.tbRotate.Name = "tbRotate";
            this.tbRotate.Padding = new System.Windows.Forms.Padding(2);
            this.tbRotate.Size = new System.Drawing.Size(167, 302);
            this.tbRotate.TabIndex = 1;
            this.tbRotate.Text = "Rotate";
            this.tbRotate.UseVisualStyleBackColor = true;
            // 
            // cmdYRInc
            // 
            this.cmdYRInc.Location = new System.Drawing.Point(85, 71);
            this.cmdYRInc.Margin = new System.Windows.Forms.Padding(2);
            this.cmdYRInc.Name = "cmdYRInc";
            this.cmdYRInc.Size = new System.Drawing.Size(56, 32);
            this.cmdYRInc.TabIndex = 5;
            this.cmdYRInc.Text = "Y+";
            this.cmdYRInc.UseVisualStyleBackColor = true;
            this.cmdYRInc.Click += new System.EventHandler(this.cmdYRInc_Click);
            // 
            // cmdYRDec
            // 
            this.cmdYRDec.Location = new System.Drawing.Point(5, 71);
            this.cmdYRDec.Margin = new System.Windows.Forms.Padding(2);
            this.cmdYRDec.Name = "cmdYRDec";
            this.cmdYRDec.Size = new System.Drawing.Size(56, 32);
            this.cmdYRDec.TabIndex = 4;
            this.cmdYRDec.Text = "Y-";
            this.cmdYRDec.UseVisualStyleBackColor = true;
            this.cmdYRDec.Click += new System.EventHandler(this.cmdYRDec_Click);
            // 
            // cmdZRInc
            // 
            this.cmdZRInc.Location = new System.Drawing.Point(85, 107);
            this.cmdZRInc.Margin = new System.Windows.Forms.Padding(2);
            this.cmdZRInc.Name = "cmdZRInc";
            this.cmdZRInc.Size = new System.Drawing.Size(56, 32);
            this.cmdZRInc.TabIndex = 3;
            this.cmdZRInc.Text = "Z+";
            this.cmdZRInc.UseVisualStyleBackColor = true;
            this.cmdZRInc.Click += new System.EventHandler(this.cmdZRInc_Click);
            // 
            // cmdZRDec
            // 
            this.cmdZRDec.Location = new System.Drawing.Point(5, 107);
            this.cmdZRDec.Margin = new System.Windows.Forms.Padding(2);
            this.cmdZRDec.Name = "cmdZRDec";
            this.cmdZRDec.Size = new System.Drawing.Size(56, 32);
            this.cmdZRDec.TabIndex = 2;
            this.cmdZRDec.Text = "Z-";
            this.cmdZRDec.UseVisualStyleBackColor = true;
            this.cmdZRDec.Click += new System.EventHandler(this.cmdZRDec_Click);
            // 
            // cmdXRInc
            // 
            this.cmdXRInc.Location = new System.Drawing.Point(85, 34);
            this.cmdXRInc.Margin = new System.Windows.Forms.Padding(2);
            this.cmdXRInc.Name = "cmdXRInc";
            this.cmdXRInc.Size = new System.Drawing.Size(56, 32);
            this.cmdXRInc.TabIndex = 1;
            this.cmdXRInc.Text = "X+";
            this.cmdXRInc.UseVisualStyleBackColor = true;
            this.cmdXRInc.Click += new System.EventHandler(this.cmdXRInc_Click);
            // 
            // cmdXRDec
            // 
            this.cmdXRDec.Location = new System.Drawing.Point(5, 34);
            this.cmdXRDec.Margin = new System.Windows.Forms.Padding(2);
            this.cmdXRDec.Name = "cmdXRDec";
            this.cmdXRDec.Size = new System.Drawing.Size(56, 32);
            this.cmdXRDec.TabIndex = 0;
            this.cmdXRDec.Text = "X-";
            this.cmdXRDec.UseVisualStyleBackColor = true;
            this.cmdXRDec.Click += new System.EventHandler(this.cmdXRDec_Click);
            // 
            // tbScale
            // 
            this.tbScale.Controls.Add(this.cmdScale);
            this.tbScale.Controls.Add(this.txtScale);
            this.tbScale.Controls.Add(this.chkWireframe);
            this.tbScale.Location = new System.Drawing.Point(4, 22);
            this.tbScale.Margin = new System.Windows.Forms.Padding(2);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(167, 302);
            this.tbScale.TabIndex = 2;
            this.tbScale.Text = "Scale";
            this.tbScale.UseVisualStyleBackColor = true;
            // 
            // cmdScale
            // 
            this.cmdScale.Location = new System.Drawing.Point(4, 24);
            this.cmdScale.Margin = new System.Windows.Forms.Padding(2);
            this.cmdScale.Name = "cmdScale";
            this.cmdScale.Size = new System.Drawing.Size(70, 37);
            this.cmdScale.TabIndex = 4;
            this.cmdScale.Text = "Scale";
            this.cmdScale.UseVisualStyleBackColor = true;
            this.cmdScale.Click += new System.EventHandler(this.cmdScale_Click);
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(4, 74);
            this.txtScale.Margin = new System.Windows.Forms.Padding(2);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(52, 20);
            this.txtScale.TabIndex = 5;
            this.txtScale.Text = "1.0";
            // 
            // chkWireframe
            // 
            this.chkWireframe.AutoSize = true;
            this.chkWireframe.Location = new System.Drawing.Point(26, 177);
            this.chkWireframe.Margin = new System.Windows.Forms.Padding(2);
            this.chkWireframe.Name = "chkWireframe";
            this.chkWireframe.Size = new System.Drawing.Size(74, 17);
            this.chkWireframe.TabIndex = 0;
            this.chkWireframe.Text = "Wireframe";
            this.chkWireframe.UseVisualStyleBackColor = true;
            this.chkWireframe.CheckedChanged += new System.EventHandler(this.chkWireframe_CheckedChanged);
            // 
            // treeScene
            // 
            this.treeScene.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeScene.Location = new System.Drawing.Point(0, 0);
            this.treeScene.Margin = new System.Windows.Forms.Padding(2);
            this.treeScene.Name = "treeScene";
            this.treeScene.Size = new System.Drawing.Size(198, 206);
            this.treeScene.TabIndex = 6;
            this.treeScene.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeScene_NodeMouseClick);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabModel1);
            this.tabMain.Controls.Add(this.tabGCode);
            this.tabMain.Controls.Add(this.tabSliceView);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(30, 55);
            this.tabMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(998, 559);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 18;
            // 
            // tabModel1
            // 
            this.tabModel1.Controls.Add(this.glControl1);
            this.tabModel1.Location = new System.Drawing.Point(4, 22);
            this.tabModel1.Margin = new System.Windows.Forms.Padding(2);
            this.tabModel1.Name = "tabModel1";
            this.tabModel1.Padding = new System.Windows.Forms.Padding(2);
            this.tabModel1.Size = new System.Drawing.Size(990, 533);
            this.tabModel1.TabIndex = 0;
            this.tabModel1.Text = "Model View";
            this.tabModel1.UseVisualStyleBackColor = true;
            // 
            // tabGCode
            // 
            this.tabGCode.Controls.Add(this.txtGCode);
            this.tabGCode.Controls.Add(this.panel1);
            this.tabGCode.Location = new System.Drawing.Point(4, 22);
            this.tabGCode.Margin = new System.Windows.Forms.Padding(2);
            this.tabGCode.Name = "tabGCode";
            this.tabGCode.Padding = new System.Windows.Forms.Padding(2);
            this.tabGCode.Size = new System.Drawing.Size(868, 453);
            this.tabGCode.TabIndex = 1;
            this.tabGCode.Text = "GCode";
            this.tabGCode.UseVisualStyleBackColor = true;
            // 
            // txtGCode
            // 
            this.txtGCode.AcceptsReturn = true;
            this.txtGCode.BackColor = System.Drawing.Color.White;
            this.txtGCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGCode.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGCode.Location = new System.Drawing.Point(2, 2);
            this.txtGCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtGCode.Multiline = true;
            this.txtGCode.Name = "txtGCode";
            this.txtGCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGCode.Size = new System.Drawing.Size(864, 386);
            this.txtGCode.TabIndex = 0;
            this.txtGCode.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdReloadGCode);
            this.panel1.Controls.Add(this.cmdSaveGCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 388);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 63);
            this.panel1.TabIndex = 1;
            // 
            // cmdReloadGCode
            // 
            this.cmdReloadGCode.Location = new System.Drawing.Point(170, 13);
            this.cmdReloadGCode.Margin = new System.Windows.Forms.Padding(2);
            this.cmdReloadGCode.Name = "cmdReloadGCode";
            this.cmdReloadGCode.Size = new System.Drawing.Size(96, 41);
            this.cmdReloadGCode.TabIndex = 1;
            this.cmdReloadGCode.Text = "Reload GCode";
            this.cmdReloadGCode.UseVisualStyleBackColor = true;
            this.cmdReloadGCode.Click += new System.EventHandler(this.cmdReloadGCode_Click);
            // 
            // cmdSaveGCode
            // 
            this.cmdSaveGCode.Location = new System.Drawing.Point(47, 13);
            this.cmdSaveGCode.Margin = new System.Windows.Forms.Padding(2);
            this.cmdSaveGCode.Name = "cmdSaveGCode";
            this.cmdSaveGCode.Size = new System.Drawing.Size(96, 41);
            this.cmdSaveGCode.TabIndex = 0;
            this.cmdSaveGCode.Text = "Save GCode";
            this.cmdSaveGCode.UseVisualStyleBackColor = true;
            this.cmdSaveGCode.Click += new System.EventHandler(this.cmdSaveGCode_Click);
            // 
            // tabSliceView
            // 
            this.tabSliceView.Controls.Add(this.picSlice);
            this.tabSliceView.Location = new System.Drawing.Point(4, 22);
            this.tabSliceView.Margin = new System.Windows.Forms.Padding(2);
            this.tabSliceView.Name = "tabSliceView";
            this.tabSliceView.Size = new System.Drawing.Size(868, 453);
            this.tabSliceView.TabIndex = 2;
            this.tabSliceView.Text = "Slice Viewer";
            this.tabSliceView.UseVisualStyleBackColor = true;
            // 
            // picSlice
            // 
            this.picSlice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSlice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSlice.Location = new System.Drawing.Point(0, 0);
            this.picSlice.Margin = new System.Windows.Forms.Padding(2);
            this.picSlice.Name = "picSlice";
            this.picSlice.Size = new System.Drawing.Size(868, 453);
            this.picSlice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSlice.TabIndex = 17;
            this.picSlice.TabStop = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vScrollBar1.Location = new System.Drawing.Point(0, 55);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(30, 559);
            this.vScrollBar1.TabIndex = 19;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdLoad,
            this.toolStripSeparator3,
            this.cmdBuild,
            this.cmdPause,
            this.cmdStop,
            this.toolStripSeparator1,
            this.cmdConnect,
            this.cmdDisconnect,
            this.toolStripSeparator2,
            this.cmdControl,
            this.cmdSlice1,
            this.toolStripSeparator4,
            this.cmdActions,
            this.lblMainMessage,
            this.lblTime});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 55);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdLoad
            // 
            this.cmdLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdLoad.Image = global::UV_DLP_3D_Printer.Properties.Resources.Load;
            this.cmdLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(52, 52);
            this.cmdLoad.Text = "Load Binary STL Model";
            this.cmdLoad.Click += new System.EventHandler(this.LoadSTLModel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // cmdBuild
            // 
            this.cmdBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdBuild.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_004;
            this.cmdBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(52, 52);
            this.cmdBuild.Text = "Start Build";
            this.cmdBuild.Click += new System.EventHandler(this.cmdStartPrint_Click);
            // 
            // cmdPause
            // 
            this.cmdPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdPause.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_003;
            this.cmdPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPause.Name = "cmdPause";
            this.cmdPause.Size = new System.Drawing.Size(52, 52);
            this.cmdPause.Text = "Pause";
            this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click_1);
            // 
            // cmdStop
            // 
            this.cmdStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdStop.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_006;
            this.cmdStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(52, 52);
            this.cmdStop.Text = "Stop Build";
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // cmdConnect
            // 
            this.cmdConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdConnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.Connect;
            this.cmdConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(52, 52);
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect1_Click);
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdDisconnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.Disconnect;
            this.cmdDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(52, 52);
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // cmdControl
            // 
            this.cmdControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdControl.Image = global::UV_DLP_3D_Printer.Properties.Resources.move;
            this.cmdControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdControl.Name = "cmdControl";
            this.cmdControl.Size = new System.Drawing.Size(52, 52);
            this.cmdControl.Text = "View Printer Controls";
            this.cmdControl.Click += new System.EventHandler(this.cmdControl_Click);
            // 
            // cmdSlice1
            // 
            this.cmdSlice1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSlice1.Image = global::UV_DLP_3D_Printer.Properties.Resources.slice;
            this.cmdSlice1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSlice1.Name = "cmdSlice1";
            this.cmdSlice1.Size = new System.Drawing.Size(52, 52);
            this.cmdSlice1.Text = "Slice!";
            this.cmdSlice1.Click += new System.EventHandler(this.cmdSlice1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // cmdActions
            // 
            this.cmdActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView,
            this.mnuMove,
            this.mnuRotate,
            this.mnuScale});
            this.cmdActions.Image = ((System.Drawing.Image)(resources.GetObject("cmdActions.Image")));
            this.cmdActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdActions.Name = "cmdActions";
            this.cmdActions.Size = new System.Drawing.Size(63, 52);
            this.cmdActions.Text = "Actions";
            // 
            // mnuView
            // 
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(108, 22);
            this.mnuView.Text = "View";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuMove
            // 
            this.mnuMove.Name = "mnuMove";
            this.mnuMove.Size = new System.Drawing.Size(108, 22);
            this.mnuMove.Text = "Move";
            this.mnuMove.Click += new System.EventHandler(this.mnuMove_Click);
            // 
            // mnuRotate
            // 
            this.mnuRotate.Name = "mnuRotate";
            this.mnuRotate.Size = new System.Drawing.Size(108, 22);
            this.mnuRotate.Text = "Rotate";
            this.mnuRotate.Click += new System.EventHandler(this.mnuRotate_Click);
            // 
            // mnuScale
            // 
            this.mnuScale.Name = "mnuScale";
            this.mnuScale.Size = new System.Drawing.Size(108, 22);
            this.mnuScale.Text = "Scale";
            this.mnuScale.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // lblMainMessage
            // 
            this.lblMainMessage.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainMessage.Name = "lblMainMessage";
            this.lblMainMessage.Size = new System.Drawing.Size(0, 52);
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 52);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.machineToolStripMenuItem,
            this.dLPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1238, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBinarySTLToolStripMenuItem,
            this.saveSceneSTLToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.addManualSupportToolStripMenuItem,
            this.addAutomaticSupportsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadBinarySTLToolStripMenuItem
            // 
            this.loadBinarySTLToolStripMenuItem.Name = "loadBinarySTLToolStripMenuItem";
            this.loadBinarySTLToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.loadBinarySTLToolStripMenuItem.Text = "Load Binary STL";
            this.loadBinarySTLToolStripMenuItem.Click += new System.EventHandler(this.loadBinarySTLToolStripMenuItem_Click);
            // 
            // saveSceneSTLToolStripMenuItem
            // 
            this.saveSceneSTLToolStripMenuItem.Name = "saveSceneSTLToolStripMenuItem";
            this.saveSceneSTLToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.saveSceneSTLToolStripMenuItem.Text = "Save Scene STL";
            this.saveSceneSTLToolStripMenuItem.Click += new System.EventHandler(this.saveSceneSTLToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addManualSupportToolStripMenuItem
            // 
            this.addManualSupportToolStripMenuItem.Enabled = false;
            this.addManualSupportToolStripMenuItem.Name = "addManualSupportToolStripMenuItem";
            this.addManualSupportToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.addManualSupportToolStripMenuItem.Text = "Add Manual Support";
            this.addManualSupportToolStripMenuItem.Click += new System.EventHandler(this.addManualSupportToolStripMenuItem_Click);
            // 
            // addAutomaticSupportsToolStripMenuItem
            // 
            this.addAutomaticSupportsToolStripMenuItem.Enabled = false;
            this.addAutomaticSupportsToolStripMenuItem.Name = "addAutomaticSupportsToolStripMenuItem";
            this.addAutomaticSupportsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.addAutomaticSupportsToolStripMenuItem.Text = "Add Automatic Supports";
            this.addAutomaticSupportsToolStripMenuItem.Click += new System.EventHandler(this.addAutomaticSupportsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slicingOptionsToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.sendGCodeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // slicingOptionsToolStripMenuItem
            // 
            this.slicingOptionsToolStripMenuItem.Name = "slicingOptionsToolStripMenuItem";
            this.slicingOptionsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.slicingOptionsToolStripMenuItem.Text = "Slicing Options";
            this.slicingOptionsToolStripMenuItem.Click += new System.EventHandler(this.slicingOptionsToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // sendGCodeToolStripMenuItem
            // 
            this.sendGCodeToolStripMenuItem.Name = "sendGCodeToolStripMenuItem";
            this.sendGCodeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sendGCodeToolStripMenuItem.Text = "Send GCode";
            this.sendGCodeToolStripMenuItem.Click += new System.EventHandler(this.sendGCodeToolStripMenuItem_Click);
            // 
            // machineToolStripMenuItem
            // 
            this.machineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem,
            this.manageMachinesToolStripMenuItem1,
            this.toolStripSeparator5});
            this.machineToolStripMenuItem.Name = "machineToolStripMenuItem";
            this.machineToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.machineToolStripMenuItem.Text = "Machine";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.machinePropertiesToolStripMenuItem_Click);
            // 
            // manageMachinesToolStripMenuItem1
            // 
            this.manageMachinesToolStripMenuItem1.Name = "manageMachinesToolStripMenuItem1";
            this.manageMachinesToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.manageMachinesToolStripMenuItem1.Text = "Manage Machines";
            this.manageMachinesToolStripMenuItem1.Click += new System.EventHandler(this.manageMachinesToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(168, 6);
            // 
            // dLPToolStripMenuItem
            // 
            this.dLPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showBlankToolStripMenuItem,
            this.showCalibrationToolStripMenuItem,
            this.showCurrentToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.dLPToolStripMenuItem.Name = "dLPToolStripMenuItem";
            this.dLPToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.dLPToolStripMenuItem.Text = "DLP";
            // 
            // showBlankToolStripMenuItem
            // 
            this.showBlankToolStripMenuItem.Name = "showBlankToolStripMenuItem";
            this.showBlankToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showBlankToolStripMenuItem.Text = "Show Blank";
            this.showBlankToolStripMenuItem.Click += new System.EventHandler(this.showBlankToolStripMenuItem_Click);
            // 
            // showCalibrationToolStripMenuItem
            // 
            this.showCalibrationToolStripMenuItem.Name = "showCalibrationToolStripMenuItem";
            this.showCalibrationToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showCalibrationToolStripMenuItem.Text = "Show Calibration";
            this.showCalibrationToolStripMenuItem.Click += new System.EventHandler(this.showCalibrationToolStripMenuItem_Click);
            // 
            // showCurrentToolStripMenuItem
            // 
            this.showCurrentToolStripMenuItem.Name = "showCurrentToolStripMenuItem";
            this.showCurrentToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showCurrentToolStripMenuItem.Text = "Show Current";
            this.showCurrentToolStripMenuItem.Click += new System.EventHandler(this.showCurrentToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtLog);
            this.splitContainer2.Size = new System.Drawing.Size(1238, 736);
            this.splitContainer2.SplitterDistance = 642;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 21;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Margin = new System.Windows.Forms.Padding(2);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1238, 91);
            this.txtLog.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdRemoveObject});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 26);
            // 
            // cmdRemoveObject
            // 
            this.cmdRemoveObject.Name = "cmdRemoveObject";
            this.cmdRemoveObject.Size = new System.Drawing.Size(155, 22);
            this.cmdRemoveObject.Text = "Remove Object";
            this.cmdRemoveObject.Click += new System.EventHandler(this.cmdRemoveObject_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 736);
            this.Controls.Add(this.splitContainer2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "Profi Creation Workshop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbMove.ResumeLayout(false);
            this.tbMove.PerformLayout();
            this.tbRotate.ResumeLayout(false);
            this.tbScale.ResumeLayout(false);
            this.tbScale.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabModel1.ResumeLayout(false);
            this.tabGCode.ResumeLayout(false);
            this.tabGCode.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabSliceView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkWireframe;
        private System.Windows.Forms.Button cmdPlace;
        private System.Windows.Forms.Button cmdCenter;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.Button cmdScale;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox picSlice;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtGCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBinarySTLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slicingOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdBuild;
        private System.Windows.Forms.ToolStripButton cmdStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdConnect;
        private System.Windows.Forms.ToolStripButton cmdDisconnect;
        private System.Windows.Forms.ToolStripButton cmdControl;
        private System.Windows.Forms.ToolStripButton cmdSlice1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabModel1;
        private System.Windows.Forms.TabPage tabGCode;
        private System.Windows.Forms.TabPage tabSliceView;
        private System.Windows.Forms.ToolStripButton cmdLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ToolStripMenuItem sendGCodeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdReloadGCode;
        private System.Windows.Forms.Button cmdSaveGCode;
        private System.Windows.Forms.TreeView treeScene;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmdRemoveObject;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbMove;
        private System.Windows.Forms.TabPage tbRotate;
        private System.Windows.Forms.TextBox txtZTrans;
        private System.Windows.Forms.Button cmdZInc;
        private System.Windows.Forms.Button cmdZdec;
        private System.Windows.Forms.TextBox txtYTrans;
        private System.Windows.Forms.Button cmdYInc;
        private System.Windows.Forms.Button cmdYDec;
        private System.Windows.Forms.TextBox txtXTrans;
        private System.Windows.Forms.Button cmdXInc;
        private System.Windows.Forms.Button cmdXDec;
        private System.Windows.Forms.Button cmdYRInc;
        private System.Windows.Forms.Button cmdYRDec;
        private System.Windows.Forms.Button cmdZRInc;
        private System.Windows.Forms.Button cmdZRDec;
        private System.Windows.Forms.Button cmdXRInc;
        private System.Windows.Forms.Button cmdXRDec;
        private System.Windows.Forms.TabPage tbScale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblMainMessage;
        private System.Windows.Forms.ToolStripLabel lblTime;
        private System.Windows.Forms.ToolStripSplitButton cmdActions;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuMove;
        private System.Windows.Forms.ToolStripMenuItem mnuRotate;
        private System.Windows.Forms.ToolStripMenuItem mnuScale;
        private System.Windows.Forms.ToolStripMenuItem machineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageMachinesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem dLPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBlankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCalibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton cmdPause;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripMenuItem saveSceneSTLToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem addManualSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAutomaticSupportsToolStripMenuItem;
    }
}

