namespace at_work_abidar_sbu
{
    partial class CreateWallForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.X2TextBox = new System.Windows.Forms.TextBox();
            this.Y2TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Y1TextBox = new System.Windows.Forms.TextBox();
            this.X1TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "END Y";
            // 
            // X2TextBox
            // 
            this.X2TextBox.Location = new System.Drawing.Point(53, 76);
            this.X2TextBox.Name = "X2TextBox";
            this.X2TextBox.Size = new System.Drawing.Size(160, 20);
            this.X2TextBox.TabIndex = 20;
            // 
            // Y2TextBox
            // 
            this.Y2TextBox.Location = new System.Drawing.Point(53, 102);
            this.Y2TextBox.Name = "Y2TextBox";
            this.Y2TextBox.Size = new System.Drawing.Size(160, 20);
            this.Y2TextBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "END X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "X";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Y1TextBox
            // 
            this.Y1TextBox.Location = new System.Drawing.Point(53, 50);
            this.Y1TextBox.Name = "Y1TextBox";
            this.Y1TextBox.Size = new System.Drawing.Size(160, 20);
            this.Y1TextBox.TabIndex = 13;
            // 
            // X1TextBox
            // 
            this.X1TextBox.Location = new System.Drawing.Point(53, 19);
            this.X1TextBox.Name = "X1TextBox";
            this.X1TextBox.Size = new System.Drawing.Size(160, 20);
            this.X1TextBox.TabIndex = 12;
            // 
            // CreateWallForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 168);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.X2TextBox);
            this.Controls.Add(this.Y2TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Y1TextBox);
            this.Controls.Add(this.X1TextBox);
            this.Name = "CreateWallForm";
            this.Text = "Create Wall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox X2TextBox;
        private System.Windows.Forms.TextBox Y2TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Y1TextBox;
        private System.Windows.Forms.TextBox X1TextBox;
    }
}