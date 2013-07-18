namespace ManualProfilabController
{
    partial class Main
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
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shpConnected = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPrintSig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profilab connection status";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.shpConnected});
            this.shapeContainer1.Size = new System.Drawing.Size(204, 223);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // shpConnected
            // 
            this.shpConnected.FillColor = System.Drawing.Color.Lime;
            this.shpConnected.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.shpConnected.Location = new System.Drawing.Point(166, 10);
            this.shpConnected.Name = "shpConnected";
            this.shpConnected.Size = new System.Drawing.Size(20, 20);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(16, 74);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(84, 66);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "START";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(106, 74);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(84, 66);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "PAUSE";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPrintSig
            // 
            this.btnPrintSig.Location = new System.Drawing.Point(16, 147);
            this.btnPrintSig.Name = "btnPrintSig";
            this.btnPrintSig.Size = new System.Drawing.Size(174, 66);
            this.btnPrintSig.TabIndex = 5;
            this.btnPrintSig.Text = "PRINT SIGNAL";
            this.btnPrintSig.UseVisualStyleBackColor = true;
            this.btnPrintSig.Click += new System.EventHandler(this.btnPrintSig_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 223);
            this.Controls.Add(this.btnPrintSig);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Main";
            this.Text = "Test profilab";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape shpConnected;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPrintSig;
    }
}

