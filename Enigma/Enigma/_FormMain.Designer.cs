namespace Enigma
{
    partial class _FormMain
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
			this.buttonPrevious = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonPrevious
			// 
			this.buttonPrevious.Location = new System.Drawing.Point(754, 461);
			this.buttonPrevious.Name = "buttonPrevious";
			this.buttonPrevious.Size = new System.Drawing.Size(104, 88);
			this.buttonPrevious.TabIndex = 0;
			this.buttonPrevious.Text = "Zurück";
			this.buttonPrevious.UseVisualStyleBackColor = true;
			this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(340, 12);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(126, 26);
			this.buttonStart.TabIndex = 1;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// textBoxInput
			// 
			this.textBoxInput.Location = new System.Drawing.Point(12, 12);
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(322, 26);
			this.textBoxInput.TabIndex = 4;
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Location = new System.Drawing.Point(472, 12);
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.Size = new System.Drawing.Size(386, 26);
			this.textBoxOutput.TabIndex = 5;
			// 
			// _FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(870, 561);
			this.Controls.Add(this.textBoxOutput);
			this.Controls.Add(this.textBoxInput);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.buttonPrevious);
			this.Name = "_FormMain";
			this.Text = "Text verschlüsseln/entschlüsseln";
			this.Click += new System.EventHandler(this._FormMain_Click);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this._FormMain_Paint);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
    }
}