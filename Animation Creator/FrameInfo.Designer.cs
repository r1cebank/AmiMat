namespace Animation_Creator
{
    partial class FrameInfo
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
            this.tbFrameInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFrameInfo
            // 
            this.tbFrameInfo.Location = new System.Drawing.Point(12, 12);
            this.tbFrameInfo.Multiline = true;
            this.tbFrameInfo.Name = "tbFrameInfo";
            this.tbFrameInfo.ReadOnly = true;
            this.tbFrameInfo.Size = new System.Drawing.Size(260, 238);
            this.tbFrameInfo.TabIndex = 0;
            // 
            // FrameInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbFrameInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrameInfo";
            this.Text = "FrameInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFrameInfo;
    }
}