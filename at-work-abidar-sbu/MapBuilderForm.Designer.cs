namespace at_work_abidar_sbu
{
    partial class MapBuilderForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.createStage = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.createWall = new System.Windows.Forms.Button();
            this.createQR = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(638, 442);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // createStage
            // 
            this.createStage.Location = new System.Drawing.Point(12, 460);
            this.createStage.Name = "createStage";
            this.createStage.Size = new System.Drawing.Size(75, 23);
            this.createStage.TabIndex = 4;
            this.createStage.Text = "Stage";
            this.createStage.UseVisualStyleBackColor = true;
            this.createStage.Click += new System.EventHandler(this.createStage_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(575, 460);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 5;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(719, 460);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 7;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // createWall
            // 
            this.createWall.Location = new System.Drawing.Point(93, 460);
            this.createWall.Name = "createWall";
            this.createWall.Size = new System.Drawing.Size(75, 23);
            this.createWall.TabIndex = 8;
            this.createWall.Text = "Wall";
            this.createWall.UseVisualStyleBackColor = true;
            this.createWall.Click += new System.EventHandler(this.createWall_Click);
            // 
            // createQR
            // 
            this.createQR.Location = new System.Drawing.Point(174, 460);
            this.createQR.Name = "createQR";
            this.createQR.Size = new System.Drawing.Size(75, 23);
            this.createQR.TabIndex = 9;
            this.createQR.Text = "QR";
            this.createQR.UseVisualStyleBackColor = true;
            this.createQR.Click += new System.EventHandler(this.createQR_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(656, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(138, 433);
            this.listBox1.TabIndex = 10;
            // 
            // MapBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 495);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.createQR);
            this.Controls.Add(this.createWall);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.save);
            this.Controls.Add(this.createStage);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MapBuilder";
            this.Text = "MapBuilder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button createStage;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button createWall;
        private System.Windows.Forms.Button createQR;
        private System.Windows.Forms.ListBox listBox1;
    }
}