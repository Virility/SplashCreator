namespace SplashCreator.UI.Forms
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
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreate = new System.Windows.Forms.Button();
            this.tbExecutablePath = new System.Windows.Forms.TextBox();
            this.cbSplashTechniques = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(244, 40);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tbExecutablePath
            // 
            this.tbExecutablePath.Location = new System.Drawing.Point(12, 12);
            this.tbExecutablePath.Name = "tbExecutablePath";
            this.tbExecutablePath.Size = new System.Drawing.Size(307, 21);
            this.tbExecutablePath.TabIndex = 1;
            this.tbExecutablePath.Text = "C:\\Users\\Trvp\\Documents\\Visual Studio 2015\\Projects\\SplashCreator\\SplashCreator\\b" +
    "in\\Debug\\SplashCreator.exe";
            this.tbExecutablePath.DoubleClick += new System.EventHandler(this.tbExecutablePath_DoubleClick);
            // 
            // cbSplashTechniques
            // 
            this.cbSplashTechniques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSplashTechniques.FormattingEnabled = true;
            this.cbSplashTechniques.Location = new System.Drawing.Point(12, 41);
            this.cbSplashTechniques.Name = "cbSplashTechniques";
            this.cbSplashTechniques.Size = new System.Drawing.Size(226, 21);
            this.cbSplashTechniques.TabIndex = 2;
            this.cbSplashTechniques.SelectedValueChanged += new System.EventHandler(this.chSplashTechniques_SelectedValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 261);
            this.Controls.Add(this.cbSplashTechniques);
            this.Controls.Add(this.tbExecutablePath);
            this.Controls.Add(this.btnCreate);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox tbExecutablePath;
        private System.Windows.Forms.ComboBox cbSplashTechniques;
    }
}