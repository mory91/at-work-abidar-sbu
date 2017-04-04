namespace at_work_abidar_sbu
{
	partial class CreatePathForm
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
            this.srcXTextBox = new System.Windows.Forms.TextBox();
            this.srcYTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dstYTextBox = new System.Windows.Forms.TextBox();
            this.dstXtextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // srcXTextBox
            // 
            this.srcXTextBox.Location = new System.Drawing.Point(45, 12);
            this.srcXTextBox.Name = "srcXTextBox";
            this.srcXTextBox.Size = new System.Drawing.Size(160, 20);
            this.srcXTextBox.TabIndex = 1;
            // 
            // srcYTextBox
            // 
            this.srcYTextBox.Location = new System.Drawing.Point(45, 43);
            this.srcYTextBox.Name = "srcYTextBox";
            this.srcYTextBox.Size = new System.Drawing.Size(160, 20);
            this.srcYTextBox.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "srcX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "srcY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "dstX";
            // 
            // dstYTextBox
            // 
            this.dstYTextBox.Location = new System.Drawing.Point(45, 95);
            this.dstYTextBox.Name = "dstYTextBox";
            this.dstYTextBox.Size = new System.Drawing.Size(160, 20);
            this.dstYTextBox.TabIndex = 4;
            // 
            // dstXtextBox
            // 
            this.dstXtextBox.Location = new System.Drawing.Point(45, 69);
            this.dstXtextBox.Name = "dstXtextBox";
            this.dstXtextBox.Size = new System.Drawing.Size(160, 20);
            this.dstXtextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "dstY";
            // 
            // CreatePathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 179);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dstXtextBox);
            this.Controls.Add(this.dstYTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.srcYTextBox);
            this.Controls.Add(this.srcXTextBox);
            this.Name = "CreatePathForm";
            this.Text = "Create Path";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

	    public System.Windows.Forms.TextBox srcXTextBox;
	    public System.Windows.Forms.TextBox srcYTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	    public System.Windows.Forms.TextBox dstYTextBox;
	    public System.Windows.Forms.TextBox dstXtextBox;
		private System.Windows.Forms.Label label4;
	}
}