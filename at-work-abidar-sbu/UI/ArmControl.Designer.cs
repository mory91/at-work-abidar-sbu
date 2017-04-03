namespace at_work_abidar_sbu
{
    partial class ArmControl
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
            this.restBtn = new System.Windows.Forms.Button();
            this.cameraBtn = new System.Windows.Forms.Button();
            this.gripBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cannyHighHS = new System.Windows.Forms.HScrollBar();
            this.cannyLowHS = new System.Windows.Forms.HScrollBar();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBtn = new System.Windows.Forms.Button();
            this.checkLbl = new System.Windows.Forms.Label();
            this.dropBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // restBtn
            // 
            this.restBtn.Location = new System.Drawing.Point(681, 30);
            this.restBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.restBtn.Name = "restBtn";
            this.restBtn.Size = new System.Drawing.Size(100, 28);
            this.restBtn.TabIndex = 0;
            this.restBtn.Text = "Rest";
            this.restBtn.UseVisualStyleBackColor = true;
            this.restBtn.Click += new System.EventHandler(this.restBtn_Click);
            // 
            // cameraBtn
            // 
            this.cameraBtn.Location = new System.Drawing.Point(681, 65);
            this.cameraBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cameraBtn.Name = "cameraBtn";
            this.cameraBtn.Size = new System.Drawing.Size(100, 28);
            this.cameraBtn.TabIndex = 1;
            this.cameraBtn.Text = "Camera";
            this.cameraBtn.UseVisualStyleBackColor = true;
            this.cameraBtn.Click += new System.EventHandler(this.cameraBtn_Click);
            // 
            // gripBtn
            // 
            this.gripBtn.Location = new System.Drawing.Point(681, 101);
            this.gripBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gripBtn.Name = "gripBtn";
            this.gripBtn.Size = new System.Drawing.Size(100, 28);
            this.gripBtn.TabIndex = 2;
            this.gripBtn.Text = "Grip";
            this.gripBtn.UseVisualStyleBackColor = true;
            this.gripBtn.Click += new System.EventHandler(this.gripBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 203);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "Detect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(637, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cannyHighHS
            // 
            this.cannyHighHS.Location = new System.Drawing.Point(681, 330);
            this.cannyHighHS.Maximum = 300;
            this.cannyHighHS.Name = "cannyHighHS";
            this.cannyHighHS.Size = new System.Drawing.Size(219, 26);
            this.cannyHighHS.TabIndex = 10;
            // 
            // cannyLowHS
            // 
            this.cannyLowHS.Location = new System.Drawing.Point(681, 273);
            this.cannyLowHS.Maximum = 300;
            this.cannyLowHS.Name = "cannyLowHS";
            this.cannyLowHS.Size = new System.Drawing.Size(219, 26);
            this.cannyLowHS.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(800, 203);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 11;
            this.button2.Text = "Scan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(800, 30);
            this.checkBtn.Margin = new System.Windows.Forms.Padding(4);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(100, 63);
            this.checkBtn.TabIndex = 12;
            this.checkBtn.Text = "Check Gripper";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // checkLbl
            // 
            this.checkLbl.AutoSize = true;
            this.checkLbl.Location = new System.Drawing.Point(932, 53);
            this.checkLbl.Name = "checkLbl";
            this.checkLbl.Size = new System.Drawing.Size(42, 17);
            this.checkLbl.TabIndex = 13;
            this.checkLbl.Text = "False";
            // 
            // dropBtn
            // 
            this.dropBtn.Location = new System.Drawing.Point(681, 137);
            this.dropBtn.Margin = new System.Windows.Forms.Padding(4);
            this.dropBtn.Name = "dropBtn";
            this.dropBtn.Size = new System.Drawing.Size(100, 28);
            this.dropBtn.TabIndex = 14;
            this.dropBtn.Text = "Drop";
            this.dropBtn.UseVisualStyleBackColor = true;
            this.dropBtn.Click += new System.EventHandler(this.dropBtn_Click);
            // 
            // ArmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 444);
            this.Controls.Add(this.dropBtn);
            this.Controls.Add(this.checkLbl);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cannyHighHS);
            this.Controls.Add(this.cannyLowHS);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gripBtn);
            this.Controls.Add(this.cameraBtn);
            this.Controls.Add(this.restBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ArmControl";
            this.Text = "ArmControl";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button restBtn;
        private System.Windows.Forms.Button cameraBtn;
        private System.Windows.Forms.Button gripBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HScrollBar cannyHighHS;
        private System.Windows.Forms.HScrollBar cannyLowHS;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Label checkLbl;
        private System.Windows.Forms.Button dropBtn;
    }
}