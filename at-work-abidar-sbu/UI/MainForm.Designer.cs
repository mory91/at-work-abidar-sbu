namespace at_work_abidar_sbu
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qRTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motorTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectRecognitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iMUTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.navigateBtn = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.bntBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(654, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configsToolStripMenuItem,
            this.mapBuilderToolStripMenuItem,
            this.loadMapMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // configsToolStripMenuItem
            // 
            this.configsToolStripMenuItem.Name = "configsToolStripMenuItem";
            this.configsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.configsToolStripMenuItem.Text = "Configs";
            this.configsToolStripMenuItem.Click += new System.EventHandler(this.configsToolStripMenuItem_Click);
            // 
            // mapBuilderToolStripMenuItem
            // 
            this.mapBuilderToolStripMenuItem.Name = "mapBuilderToolStripMenuItem";
            this.mapBuilderToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.mapBuilderToolStripMenuItem.Text = "Map Builder";
            this.mapBuilderToolStripMenuItem.Click += new System.EventHandler(this.mapBuilderToolStripMenuItem_Click);
            // 
            // loadMapMenuItem
            // 
            this.loadMapMenuItem.Name = "loadMapMenuItem";
            this.loadMapMenuItem.Size = new System.Drawing.Size(138, 22);
            this.loadMapMenuItem.Text = "Load Map";
            this.loadMapMenuItem.Click += new System.EventHandler(this.loadMapMenuItem_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraTestToolStripMenuItem,
            this.qRTestToolStripMenuItem,
            this.motorTestToolStripMenuItem,
            this.objectRecognitionToolStripMenuItem,
            this.armTestToolStripMenuItem,
            this.iMUTestToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.testsToolStripMenuItem.Text = "Tests";
            // 
            // cameraTestToolStripMenuItem
            // 
            this.cameraTestToolStripMenuItem.Name = "cameraTestToolStripMenuItem";
            this.cameraTestToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cameraTestToolStripMenuItem.Text = "Camera Test";
            this.cameraTestToolStripMenuItem.Click += new System.EventHandler(this.cameraTestToolStripMenuItem_Click);
            // 
            // qRTestToolStripMenuItem
            // 
            this.qRTestToolStripMenuItem.Name = "qRTestToolStripMenuItem";
            this.qRTestToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.qRTestToolStripMenuItem.Text = "QR Test";
            this.qRTestToolStripMenuItem.Click += new System.EventHandler(this.qRTestToolStripMenuItem_Click);
            // 
            // motorTestToolStripMenuItem
            // 
            this.motorTestToolStripMenuItem.Name = "motorTestToolStripMenuItem";
            this.motorTestToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.motorTestToolStripMenuItem.Text = "Motor Test";
            this.motorTestToolStripMenuItem.Click += new System.EventHandler(this.motorTestToolStripMenuItem_Click);
            // 
            // objectRecognitionToolStripMenuItem
            // 
            this.objectRecognitionToolStripMenuItem.Name = "objectRecognitionToolStripMenuItem";
            this.objectRecognitionToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.objectRecognitionToolStripMenuItem.Text = "Object Recognition";
            this.objectRecognitionToolStripMenuItem.Click += new System.EventHandler(this.objectRecognitionToolStripMenuItem_Click);
            // 
            // armTestToolStripMenuItem
            // 
            this.armTestToolStripMenuItem.Name = "armTestToolStripMenuItem";
            this.armTestToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.armTestToolStripMenuItem.Text = "Arm Test";
            this.armTestToolStripMenuItem.Click += new System.EventHandler(this.armTestToolStripMenuItem_Click);
            // 
            // iMUTestToolStripMenuItem
            // 
            this.iMUTestToolStripMenuItem.Name = "iMUTestToolStripMenuItem";
            this.iMUTestToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.iMUTestToolStripMenuItem.Text = "IMU Test";
            this.iMUTestToolStripMenuItem.Click += new System.EventHandler(this.iMUTestToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(638, 442);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // navigateBtn
            // 
            this.navigateBtn.Location = new System.Drawing.Point(12, 473);
            this.navigateBtn.Name = "navigateBtn";
            this.navigateBtn.Size = new System.Drawing.Size(75, 23);
            this.navigateBtn.TabIndex = 2;
            this.navigateBtn.Text = "Navigate";
            this.navigateBtn.UseVisualStyleBackColor = true;
            this.navigateBtn.Click += new System.EventHandler(this.navigateBtn_Click);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 500;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "RobotPosition";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bntBtn
            // 
            this.bntBtn.Location = new System.Drawing.Point(208, 473);
            this.bntBtn.Name = "bntBtn";
            this.bntBtn.Size = new System.Drawing.Size(75, 23);
            this.bntBtn.TabIndex = 4;
            this.bntBtn.Text = "BNT";
            this.bntBtn.UseVisualStyleBackColor = true;
            this.bntBtn.Click += new System.EventHandler(this.bntBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 503);
            this.Controls.Add(this.bntBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.navigateBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qRTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motorTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button navigateBtn;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem objectRecognitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMUTestToolStripMenuItem;
        private System.Windows.Forms.Button bntBtn;
    }
}

