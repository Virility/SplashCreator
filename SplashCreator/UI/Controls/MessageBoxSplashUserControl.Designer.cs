namespace SplashCreator.UI.Controls
{
    partial class MessageBoxSplashUserControl
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
            this.lbMessage = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(-3, 6);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(56, 13);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "Message";
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(0, 22);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(307, 21);
            this.tbMessage.TabIndex = 1;
            // 
            // MessageBoxSplashUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lbMessage);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Name = "MessageBoxSplashUserControl";
            this.Size = new System.Drawing.Size(307, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.TextBox tbMessage;
    }
}
