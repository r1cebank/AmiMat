namespace Animation_Creator
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lbGifFrames = new System.Windows.Forms.ListBox();
            this.lblMd5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssAsset = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssWorkingDir = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFrameCount = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbActions = new System.Windows.Forms.ListBox();
            this.btnCreateAsNew = new System.Windows.Forms.Button();
            this.btnAddToExisting = new System.Windows.Forms.Button();
            this.lbFrames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentAction = new System.Windows.Forms.Label();
            this.btnOpenExisting = new System.Windows.Forms.Button();
            this.lblDebug = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteFrame = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnShowPreview = new System.Windows.Forms.Button();
            this.btnShowText = new System.Windows.Forms.Button();
            this.pbFrame = new System.Windows.Forms.PictureBox();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGifFrames
            // 
            this.lbGifFrames.FormattingEnabled = true;
            this.lbGifFrames.Location = new System.Drawing.Point(15, 25);
            this.lbGifFrames.Name = "lbGifFrames";
            this.lbGifFrames.Size = new System.Drawing.Size(57, 199);
            this.lbGifFrames.TabIndex = 0;
            this.lbGifFrames.SelectedIndexChanged += new System.EventHandler(this.lbFrames_SelectedIndexChanged);
            // 
            // lblMd5
            // 
            this.lblMd5.AutoSize = true;
            this.lblMd5.Location = new System.Drawing.Point(12, 268);
            this.lblMd5.Name = "lblMd5";
            this.lblMd5.Size = new System.Drawing.Size(30, 13);
            this.lblMd5.TabIndex = 1;
            this.lblMd5.Text = "MD5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Frames:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(583, 263);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open .gif";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tssAsset,
            this.toolStripStatusLabel1,
            this.tssWorkingDir});
            this.ssStatus.Location = new System.Drawing.Point(0, 289);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(751, 22);
            this.ssStatus.TabIndex = 5;
            this.ssStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel2.Text = "Asset:";
            // 
            // tssAsset
            // 
            this.tssAsset.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tssAsset.Name = "tssAsset";
            this.tssAsset.Size = new System.Drawing.Size(39, 17);
            this.tssAsset.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(106, 17);
            this.toolStripStatusLabel1.Text = "Working Directory:";
            // 
            // tssWorkingDir
            // 
            this.tssWorkingDir.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tssWorkingDir.Name = "tssWorkingDir";
            this.tssWorkingDir.Size = new System.Drawing.Size(16, 17);
            this.tssWorkingDir.Text = "...";
            // 
            // lblFrameCount
            // 
            this.lblFrameCount.AutoSize = true;
            this.lblFrameCount.Location = new System.Drawing.Point(59, 9);
            this.lblFrameCount.Name = "lblFrameCount";
            this.lblFrameCount.Size = new System.Drawing.Size(13, 13);
            this.lblFrameCount.TabIndex = 6;
            this.lblFrameCount.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(664, 263);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbActions
            // 
            this.lbActions.FormattingEnabled = true;
            this.lbActions.Location = new System.Drawing.Point(286, 26);
            this.lbActions.Name = "lbActions";
            this.lbActions.Size = new System.Drawing.Size(106, 199);
            this.lbActions.TabIndex = 8;
            this.lbActions.SelectedIndexChanged += new System.EventHandler(this.lbActions_SelectedIndexChanged);
            // 
            // btnCreateAsNew
            // 
            this.btnCreateAsNew.Location = new System.Drawing.Point(80, 231);
            this.btnCreateAsNew.Name = "btnCreateAsNew";
            this.btnCreateAsNew.Size = new System.Drawing.Size(99, 23);
            this.btnCreateAsNew.TabIndex = 9;
            this.btnCreateAsNew.Text = "Create as new";
            this.btnCreateAsNew.UseVisualStyleBackColor = true;
            this.btnCreateAsNew.Click += new System.EventHandler(this.btnCreateAsNew_Click);
            // 
            // btnAddToExisting
            // 
            this.btnAddToExisting.Location = new System.Drawing.Point(185, 231);
            this.btnAddToExisting.Name = "btnAddToExisting";
            this.btnAddToExisting.Size = new System.Drawing.Size(95, 23);
            this.btnAddToExisting.TabIndex = 10;
            this.btnAddToExisting.Text = "Add to existing";
            this.btnAddToExisting.UseVisualStyleBackColor = true;
            this.btnAddToExisting.Click += new System.EventHandler(this.btnAddToExisting_Click);
            // 
            // lbFrames
            // 
            this.lbFrames.FormattingEnabled = true;
            this.lbFrames.Location = new System.Drawing.Point(398, 26);
            this.lbFrames.Name = "lbFrames";
            this.lbFrames.Size = new System.Drawing.Size(341, 160);
            this.lbFrames.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Currently editing:";
            // 
            // lblCurrentAction
            // 
            this.lblCurrentAction.AutoSize = true;
            this.lblCurrentAction.ForeColor = System.Drawing.Color.Crimson;
            this.lblCurrentAction.Location = new System.Drawing.Point(486, 9);
            this.lblCurrentAction.Name = "lblCurrentAction";
            this.lblCurrentAction.Size = new System.Drawing.Size(23, 13);
            this.lblCurrentAction.TabIndex = 13;
            this.lblCurrentAction.Text = "null";
            // 
            // btnOpenExisting
            // 
            this.btnOpenExisting.Location = new System.Drawing.Point(489, 263);
            this.btnOpenExisting.Name = "btnOpenExisting";
            this.btnOpenExisting.Size = new System.Drawing.Size(88, 23);
            this.btnOpenExisting.TabIndex = 14;
            this.btnOpenExisting.Text = "Open Existing";
            this.btnOpenExisting.UseVisualStyleBackColor = true;
            this.btnOpenExisting.Click += new System.EventHandler(this.btnOpenExisting_Click);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(398, 240);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(45, 13);
            this.lblDebug.TabIndex = 17;
            this.lblDebug.Text = "DEBUG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Actions in AMT.mf";
            // 
            // btnDeleteFrame
            // 
            this.btnDeleteFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFrame.Image")));
            this.btnDeleteFrame.Location = new System.Drawing.Point(551, 192);
            this.btnDeleteFrame.Name = "btnDeleteFrame";
            this.btnDeleteFrame.Size = new System.Drawing.Size(32, 32);
            this.btnDeleteFrame.TabIndex = 21;
            this.btnDeleteFrame.UseVisualStyleBackColor = true;
            this.btnDeleteFrame.Click += new System.EventHandler(this.btnDeleteFrame_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Image = global::Animation_Creator.Properties.Resources.up;
            this.btnMoveUp.Location = new System.Drawing.Point(589, 192);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(32, 32);
            this.btnMoveUp.TabIndex = 19;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(627, 192);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(32, 32);
            this.btnMoveDown.TabIndex = 18;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnShowPreview
            // 
            this.btnShowPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPreview.Image = global::Animation_Creator.Properties.Resources.preview;
            this.btnShowPreview.Location = new System.Drawing.Point(665, 192);
            this.btnShowPreview.Name = "btnShowPreview";
            this.btnShowPreview.Size = new System.Drawing.Size(32, 32);
            this.btnShowPreview.TabIndex = 16;
            this.btnShowPreview.UseVisualStyleBackColor = true;
            this.btnShowPreview.Click += new System.EventHandler(this.btnShowPreview_Click);
            // 
            // btnShowText
            // 
            this.btnShowText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowText.Image = ((System.Drawing.Image)(resources.GetObject("btnShowText.Image")));
            this.btnShowText.Location = new System.Drawing.Point(703, 192);
            this.btnShowText.Name = "btnShowText";
            this.btnShowText.Size = new System.Drawing.Size(32, 32);
            this.btnShowText.TabIndex = 15;
            this.btnShowText.UseVisualStyleBackColor = true;
            this.btnShowText.Click += new System.EventHandler(this.btnShowText_Click);
            // 
            // pbFrame
            // 
            this.pbFrame.BackColor = System.Drawing.SystemColors.Control;
            this.pbFrame.BackgroundImage = global::Animation_Creator.Properties.Resources.grid;
            this.pbFrame.Location = new System.Drawing.Point(80, 25);
            this.pbFrame.Name = "pbFrame";
            this.pbFrame.Size = new System.Drawing.Size(200, 200);
            this.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFrame.TabIndex = 3;
            this.pbFrame.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 311);
            this.Controls.Add(this.btnDeleteFrame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.btnShowPreview);
            this.Controls.Add(this.btnShowText);
            this.Controls.Add(this.btnOpenExisting);
            this.Controls.Add(this.lblCurrentAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFrames);
            this.Controls.Add(this.btnAddToExisting);
            this.Controls.Add(this.btnCreateAsNew);
            this.Controls.Add(this.lbActions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblFrameCount);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pbFrame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMd5);
            this.Controls.Add(this.lbGifFrames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "AmiMat （アミマト）by r1cebank";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGifFrames;
        private System.Windows.Forms.Label lblMd5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbFrame;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssAsset;
        private System.Windows.Forms.ToolStripStatusLabel tssWorkingDir;
        private System.Windows.Forms.Label lblFrameCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lbActions;
        private System.Windows.Forms.Button btnCreateAsNew;
        private System.Windows.Forms.Button btnAddToExisting;
        private System.Windows.Forms.ListBox lbFrames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentAction;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btnOpenExisting;
        private System.Windows.Forms.Button btnShowText;
        private System.Windows.Forms.Button btnShowPreview;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteFrame;
    }
}

