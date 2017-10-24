namespace GameDemo_Server
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
            this.textBox_ConsoleOutput = new System.Windows.Forms.TextBox();
            this.textBox_ConsoleInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_ConsoleOutput
            // 
            this.textBox_ConsoleOutput.Location = new System.Drawing.Point(12, 2);
            this.textBox_ConsoleOutput.Multiline = true;
            this.textBox_ConsoleOutput.Name = "textBox_ConsoleOutput";
            this.textBox_ConsoleOutput.ReadOnly = true;
            this.textBox_ConsoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ConsoleOutput.Size = new System.Drawing.Size(856, 459);
            this.textBox_ConsoleOutput.TabIndex = 0;
            // 
            // textBox_ConsoleInput
            // 
            this.textBox_ConsoleInput.Location = new System.Drawing.Point(12, 467);
            this.textBox_ConsoleInput.Name = "textBox_ConsoleInput";
            this.textBox_ConsoleInput.Size = new System.Drawing.Size(856, 20);
            this.textBox_ConsoleInput.TabIndex = 1;
            this.textBox_ConsoleInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_ConsoleInput_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 499);
            this.Controls.Add(this.textBox_ConsoleInput);
            this.Controls.Add(this.textBox_ConsoleOutput);
            this.Name = "MainForm";
            this.Text = "GameDemo Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ConsoleOutput;
        private System.Windows.Forms.TextBox textBox_ConsoleInput;
    }
}

