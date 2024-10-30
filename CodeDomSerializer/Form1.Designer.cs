using CustomControl;
using System;
using System.Windows.Forms;

namespace CodeDomSerializer
{
    partial class Form1
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customUserControl1 = new CustomUserControl();
            this.SuspendLayout();
            // 
            // customUserControl1
            // 
            this.customUserControl1.BackColor = System.Drawing.Color.LightBlue;
            this.customUserControl1.Location = new System.Drawing.Point(73, 58);
            this.customUserControl1.Name = "customUserControl1";
            this.customUserControl1.Size = new System.Drawing.Size(150, 150);
            this.customUserControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(768, 261);
            this.Controls.Add(this.customUserControl1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private CustomUserControl customUserControl1;
    }
}

