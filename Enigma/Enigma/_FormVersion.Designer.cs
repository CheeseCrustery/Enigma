namespace Enigma
{
    partial class _FormVersion
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
            this.buttonChooseVersion = new System.Windows.Forms.Button();
            this.richTextBoxVersion = new System.Windows.Forms.RichTextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonDebug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonChooseVersion
            // 
            this.buttonChooseVersion.Location = new System.Drawing.Point(11, 11);
            this.buttonChooseVersion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonChooseVersion.Name = "buttonChooseVersion";
            this.buttonChooseVersion.Size = new System.Drawing.Size(69, 35);
            this.buttonChooseVersion.TabIndex = 0;
            this.buttonChooseVersion.Text = "Version wählen";
            this.buttonChooseVersion.UseVisualStyleBackColor = true;
            this.buttonChooseVersion.Click += new System.EventHandler(this.buttonChooseVersion_Click);
            // 
            // richTextBoxVersion
            // 
            this.richTextBoxVersion.Location = new System.Drawing.Point(92, 11);
            this.richTextBoxVersion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxVersion.Name = "richTextBoxVersion";
            this.richTextBoxVersion.Size = new System.Drawing.Size(430, 270);
            this.richTextBoxVersion.TabIndex = 1;
            this.richTextBoxVersion.Text = "";
            // 
            // buttonNext
            // 
            this.buttonNext.Enabled = false;
            this.buttonNext.Location = new System.Drawing.Point(11, 50);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(69, 49);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Weiter";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonDebug
            // 
            this.buttonDebug.Location = new System.Drawing.Point(12, 257);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(75, 23);
            this.buttonDebug.TabIndex = 3;
            this.buttonDebug.Text = "Debug";
            this.buttonDebug.UseVisualStyleBackColor = true;
            this.buttonDebug.Click += new System.EventHandler(this.buttonDebug_Click);
            // 
            // _FormVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.buttonDebug);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.richTextBoxVersion);
            this.Controls.Add(this.buttonChooseVersion);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "_FormVersion";
            this.Text = "Versionsauswahl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseVersion;
        private System.Windows.Forms.RichTextBox richTextBoxVersion;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonDebug;
    }
}

