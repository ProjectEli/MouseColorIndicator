namespace MouseColorIndicator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hookStateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mousePosLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.imageCountsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Hook on/off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current hook state:";
            // 
            // hookStateLabel
            // 
            this.hookStateLabel.AutoSize = true;
            this.hookStateLabel.Location = new System.Drawing.Point(638, 38);
            this.hookStateLabel.Name = "hookStateLabel";
            this.hookStateLabel.Size = new System.Drawing.Size(22, 15);
            this.hookStateLabel.TabIndex = 3;
            this.hookStateLabel.Text = "off";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mouse pos:";
            // 
            // mousePosLabel
            // 
            this.mousePosLabel.AutoSize = true;
            this.mousePosLabel.Location = new System.Drawing.Point(597, 53);
            this.mousePosLabel.Name = "mousePosLabel";
            this.mousePosLabel.Size = new System.Drawing.Size(72, 15);
            this.mousePosLabel.TabIndex = 5;
            this.mousePosLabel.Text = "Unidentified";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Counts:";
            // 
            // imageCountsLabel
            // 
            this.imageCountsLabel.AutoSize = true;
            this.imageCountsLabel.Location = new System.Drawing.Point(576, 68);
            this.imageCountsLabel.Name = "imageCountsLabel";
            this.imageCountsLabel.Size = new System.Drawing.Size(34, 15);
            this.imageCountsLabel.TabIndex = 7;
            this.imageCountsLabel.Text = "none";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.imageCountsLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mousePosLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hookStateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "MouseColorIndicator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Label label1;
        private Label hookStateLabel;
        private Label label2;
        private Label mousePosLabel;
        private Label label3;
        private Label imageCountsLabel;
    }
}