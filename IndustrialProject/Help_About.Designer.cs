namespace IndustrialProject
{
    partial class Help_About
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
            this.richTextBoxAbout = new System.Windows.Forms.RichTextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxAbout
            // 
            this.richTextBoxAbout.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxAbout.Name = "richTextBoxAbout";
            this.richTextBoxAbout.Size = new System.Drawing.Size(617, 384);
            this.richTextBoxAbout.TabIndex = 2;
            this.richTextBoxAbout.Text = "";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(284, 413);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click_1);
            // 
            // Help_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 474);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.richTextBoxAbout);
            this.Name = "Help_About";
            this.Text = "Help_About";
            this.Load += new System.EventHandler(this.Help_About_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxAbout;
        private System.Windows.Forms.Button buttonOK;
    }
}