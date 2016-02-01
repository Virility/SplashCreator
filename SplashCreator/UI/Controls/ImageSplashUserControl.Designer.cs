namespace SplashCreator.UI.Controls
{
    partial class ImageSplashUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbFormText = new System.Windows.Forms.TextBox();
            this.lbFormText = new System.Windows.Forms.Label();
            this.lbImage = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFormText
            // 
            this.tbFormText.Location = new System.Drawing.Point(0, 22);
            this.tbFormText.Name = "tbFormText";
            this.tbFormText.Size = new System.Drawing.Size(307, 21);
            this.tbFormText.TabIndex = 3;
            // 
            // lbFormText
            // 
            this.lbFormText.AutoSize = true;
            this.lbFormText.Location = new System.Drawing.Point(-3, 6);
            this.lbFormText.Name = "lbFormText";
            this.lbFormText.Size = new System.Drawing.Size(64, 13);
            this.lbFormText.TabIndex = 2;
            this.lbFormText.Text = "Form Text";
            // 
            // lbImage
            // 
            this.lbImage.AutoSize = true;
            this.lbImage.Location = new System.Drawing.Point(-3, 52);
            this.lbImage.Name = "lbImage";
            this.lbImage.Size = new System.Drawing.Size(308, 13);
            this.lbImage.TabIndex = 2;
            this.lbImage.Text = "Image (Double click picture box to select an image.)";
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(51, 68);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(205, 111);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 4;
            this.pbImage.TabStop = false;
            this.pbImage.DoubleClick += new System.EventHandler(this.pbImage_DoubleClick);
            // 
            // ImageSplashUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.tbFormText);
            this.Controls.Add(this.lbImage);
            this.Controls.Add(this.lbFormText);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Name = "ImageSplashUserControl";
            this.Size = new System.Drawing.Size(307, 181);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFormText;
        private System.Windows.Forms.Label lbFormText;
        private System.Windows.Forms.Label lbImage;
        private System.Windows.Forms.PictureBox pbImage;
    }
}
