namespace Animation_Creator
{
    partial class ActionPreview
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
            this.components = new System.ComponentModel.Container();
            this.pbAnimation = new System.Windows.Forms.PictureBox();
            this.PlayTimer = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentDelay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentFrame = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAnimation
            // 
            this.pbAnimation.BackgroundImage = global::Animation_Creator.Properties.Resources.grid;
            this.pbAnimation.Location = new System.Drawing.Point(12, 36);
            this.pbAnimation.Name = "pbAnimation";
            this.pbAnimation.Size = new System.Drawing.Size(260, 260);
            this.pbAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnimation.TabIndex = 0;
            this.pbAnimation.TabStop = false;
            // 
            // PlayTimer
            // 
            this.PlayTimer.Tick += new System.EventHandler(this.PlayTimer_Tick);
            // 
            // lblCurrentDelay
            // 
            this.lblCurrentDelay.AutoSize = true;
            this.lblCurrentDelay.Location = new System.Drawing.Point(92, 9);
            this.lblCurrentDelay.Name = "lblCurrentDelay";
            this.lblCurrentDelay.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentDelay.TabIndex = 1;
            this.lblCurrentDelay.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Delay:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Frame:";
            // 
            // lblCurrentFrame
            // 
            this.lblCurrentFrame.AutoSize = true;
            this.lblCurrentFrame.Location = new System.Drawing.Point(258, 9);
            this.lblCurrentFrame.Name = "lblCurrentFrame";
            this.lblCurrentFrame.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentFrame.TabIndex = 4;
            this.lblCurrentFrame.Text = "0";
            // 
            // ActionPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 308);
            this.Controls.Add(this.lblCurrentFrame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCurrentDelay);
            this.Controls.Add(this.pbAnimation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ActionPreview";
            this.Text = "Action Preview";
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAnimation;
        private System.Windows.Forms.Timer PlayTimer;
        private System.Windows.Forms.Label lblCurrentDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentFrame;
    }
}