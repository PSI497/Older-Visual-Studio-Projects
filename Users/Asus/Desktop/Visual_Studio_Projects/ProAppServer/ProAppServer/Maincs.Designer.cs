namespace ProAppServer
{
    partial class Maincs
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.OnlineUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.MsgBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // OnlineUsers
            // 
            this.OnlineUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "Online";
            this.OnlineUsers.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.OnlineUsers.Location = new System.Drawing.Point(53, 12);
            this.OnlineUsers.Name = "OnlineUsers";
            this.OnlineUsers.Size = new System.Drawing.Size(121, 210);
            this.OnlineUsers.TabIndex = 1;
            this.OnlineUsers.UseCompatibleStateImageBehavior = false;
            this.OnlineUsers.View = System.Windows.Forms.View.List;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MsgBox
            // 
            this.MsgBox.Location = new System.Drawing.Point(218, 12);
            this.MsgBox.Name = "MsgBox";
            this.MsgBox.Size = new System.Drawing.Size(310, 210);
            this.MsgBox.TabIndex = 3;
            this.MsgBox.Text = "";
            // 
            // Maincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 332);
            this.Controls.Add(this.MsgBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OnlineUsers);
            this.Name = "Maincs";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Maincs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView OnlineUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox MsgBox;

    }
}

