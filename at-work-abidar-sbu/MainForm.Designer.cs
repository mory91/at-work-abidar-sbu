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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qRTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(328, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configsToolStripMenuItem,
            this.mapBuilderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraTestToolStripMenuItem,
            this.qRTestToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.testsToolStripMenuItem.Text = "Tests";
            // 
            // cameraTestToolStripMenuItem
            // 
            this.cameraTestToolStripMenuItem.Name = "cameraTestToolStripMenuItem";
            this.cameraTestToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cameraTestToolStripMenuItem.Text = "Camera Test";
            this.cameraTestToolStripMenuItem.Click += new System.EventHandler(this.cameraTestToolStripMenuItem_Click);
            // 
            // configsToolStripMenuItem
            // 
            this.configsToolStripMenuItem.Name = "configsToolStripMenuItem";
            this.configsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.configsToolStripMenuItem.Text = "Configs";
            this.configsToolStripMenuItem.Click += new System.EventHandler(this.configsToolStripMenuItem_Click);
            // 
            // mapBuilderToolStripMenuItem
            // 
            this.mapBuilderToolStripMenuItem.Name = "mapBuilderToolStripMenuItem";
            this.mapBuilderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mapBuilderToolStripMenuItem.Text = "Map Builder";
            this.mapBuilderToolStripMenuItem.Click += new System.EventHandler(this.mapBuilderToolStripMenuItem_Click);
            // 
            // qRTestToolStripMenuItem
            // 
            this.qRTestToolStripMenuItem.Name = "qRTestToolStripMenuItem";
            this.qRTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.qRTestToolStripMenuItem.Text = "QR Test";
            this.qRTestToolStripMenuItem.Click += new System.EventHandler(this.qRTestToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 296);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

