﻿namespace Animat.UI
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
            this.mainMenuSrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.dockPanel1 = new DigitalRune.Windows.Docking.DockPanel();
            this.dEBUGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDockableFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuSrip.SuspendLayout();
            this.mainToolStripContainer.ContentPanel.SuspendLayout();
            this.mainToolStripContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuSrip
            // 
            this.mainMenuSrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.dEBUGToolStripMenuItem});
            this.mainMenuSrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuSrip.Name = "mainMenuSrip";
            this.mainMenuSrip.Size = new System.Drawing.Size(1264, 24);
            this.mainMenuSrip.TabIndex = 0;
            this.mainMenuSrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mainToolStripContainer
            // 
            // 
            // mainToolStripContainer.ContentPanel
            // 
            this.mainToolStripContainer.ContentPanel.Controls.Add(this.dockPanel1);
            this.mainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(1264, 632);
            this.mainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolStripContainer.Location = new System.Drawing.Point(0, 24);
            this.mainToolStripContainer.Name = "mainToolStripContainer";
            this.mainToolStripContainer.Size = new System.Drawing.Size(1264, 657);
            this.mainToolStripContainer.TabIndex = 1;
            this.mainToolStripContainer.Text = "toolStripContainer1";
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.DefaultFloatingWindowSize = new System.Drawing.Size(300, 300);
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(1264, 632);
            this.dockPanel1.TabIndex = 0;
            // 
            // dEBUGToolStripMenuItem
            // 
            this.dEBUGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDockableFormToolStripMenuItem});
            this.dEBUGToolStripMenuItem.Name = "dEBUGToolStripMenuItem";
            this.dEBUGToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.dEBUGToolStripMenuItem.Text = "DEBUG";
            // 
            // addDockableFormToolStripMenuItem
            // 
            this.addDockableFormToolStripMenuItem.Name = "addDockableFormToolStripMenuItem";
            this.addDockableFormToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addDockableFormToolStripMenuItem.Text = "Add Dockable Form";
            this.addDockableFormToolStripMenuItem.Click += new System.EventHandler(this.addDockableFormToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.mainToolStripContainer);
            this.Controls.Add(this.mainMenuSrip);
            this.MainMenuStrip = this.mainMenuSrip;
            this.Name = "MainForm";
            this.Text = "YUAI Animation Studio";
            this.mainMenuSrip.ResumeLayout(false);
            this.mainMenuSrip.PerformLayout();
            this.mainToolStripContainer.ContentPanel.ResumeLayout(false);
            this.mainToolStripContainer.ResumeLayout(false);
            this.mainToolStripContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuSrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer mainToolStripContainer;
        private DigitalRune.Windows.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem dEBUGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDockableFormToolStripMenuItem;
    }
}
