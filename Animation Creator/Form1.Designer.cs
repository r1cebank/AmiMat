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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lbGifFrames = new System.Windows.Forms.ListBox();
            this.lblMd5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssProjectName = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.btnPlayAction = new System.Windows.Forms.Button();
            this.nudDefaultDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tAutoSave = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lblAutoSave = new System.Windows.Forms.Label();
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnFrameRef = new System.Windows.Forms.Button();
            this.btnEditTag = new System.Windows.Forms.Button();
            this.btnChangeDelay = new System.Windows.Forms.Button();
            this.btnDeleteFrame = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnShowPreview = new System.Windows.Forms.Button();
            this.btnShowText = new System.Windows.Forms.Button();
            this.pbFrame = new System.Windows.Forms.PictureBox();
            this.btnSaveAsset = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbAssets = new System.Windows.Forms.ListBox();
            this.btnNewAsset = new System.Windows.Forms.Button();
            this.btnLoadToExisting = new System.Windows.Forms.Button();
            this.btnLoadExistingAsset = new System.Windows.Forms.Button();
            this.ssStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefaultDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGifFrames
            // 
            this.lbGifFrames.FormattingEnabled = true;
            this.lbGifFrames.Location = new System.Drawing.Point(124, 38);
            this.lbGifFrames.Name = "lbGifFrames";
            this.lbGifFrames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbGifFrames.Size = new System.Drawing.Size(57, 212);
            this.lbGifFrames.TabIndex = 0;
            this.lbGifFrames.SelectedIndexChanged += new System.EventHandler(this.lbFrames_SelectedIndexChanged);
            // 
            // lblMd5
            // 
            this.lblMd5.AutoSize = true;
            this.lblMd5.Location = new System.Drawing.Point(182, 326);
            this.lblMd5.Name = "lblMd5";
            this.lblMd5.Size = new System.Drawing.Size(30, 13);
            this.lblMd5.TabIndex = 1;
            this.lblMd5.Text = "MD5";
            this.lblMd5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Frames:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 359);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(106, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "New Project";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tssProjectName,
            this.toolStripStatusLabel1,
            this.tssWorkingDir});
            this.ssStatus.Location = new System.Drawing.Point(0, 395);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(868, 22);
            this.ssStatus.TabIndex = 5;
            this.ssStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel2.Text = "Project:";
            // 
            // tssProjectName
            // 
            this.tssProjectName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tssProjectName.Name = "tssProjectName";
            this.tssProjectName.Size = new System.Drawing.Size(39, 17);
            this.tssProjectName.Text = "Ready";
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
            this.lblFrameCount.Location = new System.Drawing.Point(168, 21);
            this.lblFrameCount.Name = "lblFrameCount";
            this.lblFrameCount.Size = new System.Drawing.Size(13, 13);
            this.lblFrameCount.TabIndex = 6;
            this.lblFrameCount.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(779, 359);
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
            this.lbActions.Location = new System.Drawing.Point(393, 39);
            this.lbActions.Name = "lbActions";
            this.lbActions.Size = new System.Drawing.Size(106, 212);
            this.lbActions.TabIndex = 8;
            this.lbActions.SelectedIndexChanged += new System.EventHandler(this.lbActions_SelectedIndexChanged);
            // 
            // btnCreateAsNew
            // 
            this.btnCreateAsNew.Location = new System.Drawing.Point(187, 266);
            this.btnCreateAsNew.Name = "btnCreateAsNew";
            this.btnCreateAsNew.Size = new System.Drawing.Size(99, 23);
            this.btnCreateAsNew.TabIndex = 9;
            this.btnCreateAsNew.Text = "Create as new";
            this.btnCreateAsNew.UseVisualStyleBackColor = true;
            this.btnCreateAsNew.Click += new System.EventHandler(this.btnCreateAsNew_Click);
            // 
            // btnAddToExisting
            // 
            this.btnAddToExisting.Location = new System.Drawing.Point(292, 266);
            this.btnAddToExisting.Name = "btnAddToExisting";
            this.btnAddToExisting.Size = new System.Drawing.Size(95, 23);
            this.btnAddToExisting.TabIndex = 10;
            this.btnAddToExisting.Text = "Add to selected";
            this.btnAddToExisting.UseVisualStyleBackColor = true;
            this.btnAddToExisting.Click += new System.EventHandler(this.btnAddToExisting_Click);
            // 
            // lbFrames
            // 
            this.lbFrames.FormattingEnabled = true;
            this.lbFrames.Location = new System.Drawing.Point(513, 39);
            this.lbFrames.Name = "lbFrames";
            this.lbFrames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFrames.Size = new System.Drawing.Size(341, 212);
            this.lbFrames.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Currently editing:";
            // 
            // lblCurrentAction
            // 
            this.lblCurrentAction.AutoSize = true;
            this.lblCurrentAction.ForeColor = System.Drawing.Color.Crimson;
            this.lblCurrentAction.Location = new System.Drawing.Point(604, 23);
            this.lblCurrentAction.Name = "lblCurrentAction";
            this.lblCurrentAction.Size = new System.Drawing.Size(23, 13);
            this.lblCurrentAction.TabIndex = 13;
            this.lblCurrentAction.Text = "null";
            // 
            // btnOpenExisting
            // 
            this.btnOpenExisting.Location = new System.Drawing.Point(604, 359);
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
            this.lblDebug.Location = new System.Drawing.Point(149, 364);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(45, 13);
            this.lblDebug.TabIndex = 17;
            this.lblDebug.Text = "DEBUG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Actions in AMT.amf";
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Location = new System.Drawing.Point(393, 266);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(106, 23);
            this.btnDeleteAction.TabIndex = 24;
            this.btnDeleteAction.Text = "Delete Action";
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            // 
            // btnPlayAction
            // 
            this.btnPlayAction.Location = new System.Drawing.Point(393, 293);
            this.btnPlayAction.Name = "btnPlayAction";
            this.btnPlayAction.Size = new System.Drawing.Size(106, 23);
            this.btnPlayAction.TabIndex = 25;
            this.btnPlayAction.Text = "Play Action";
            this.btnPlayAction.UseVisualStyleBackColor = true;
            this.btnPlayAction.Click += new System.EventHandler(this.btnPlayAction_Click);
            // 
            // nudDefaultDelay
            // 
            this.nudDefaultDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudDefaultDelay.Location = new System.Drawing.Point(302, 295);
            this.nudDefaultDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDefaultDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDefaultDelay.Name = "nudDefaultDelay";
            this.nudDefaultDelay.Size = new System.Drawing.Size(59, 20);
            this.nudDefaultDelay.TabIndex = 27;
            this.nudDefaultDelay.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Default delay:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "ms";
            // 
            // tAutoSave
            // 
            this.tAutoSave.Enabled = true;
            this.tAutoSave.Tick += new System.EventHandler(this.tAutoSave_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Last Save:";
            // 
            // lblAutoSave
            // 
            this.lblAutoSave.AutoSize = true;
            this.lblAutoSave.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAutoSave.Location = new System.Drawing.Point(248, 326);
            this.lblAutoSave.Name = "lblAutoSave";
            this.lblAutoSave.Size = new System.Drawing.Size(51, 13);
            this.lblAutoSave.TabIndex = 31;
            this.lblAutoSave.Text = "unknown";
            // 
            // btnCurve
            // 
            this.btnCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurve.Image = global::Animation_Creator.Properties.Resources.curve;
            this.btnCurve.Location = new System.Drawing.Point(518, 272);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(32, 32);
            this.btnCurve.TabIndex = 32;
            this.btnCurve.UseVisualStyleBackColor = true;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnFrameRef
            // 
            this.btnFrameRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrameRef.Image = global::Animation_Creator.Properties.Resources.action;
            this.btnFrameRef.Location = new System.Drawing.Point(556, 272);
            this.btnFrameRef.Name = "btnFrameRef";
            this.btnFrameRef.Size = new System.Drawing.Size(32, 32);
            this.btnFrameRef.TabIndex = 26;
            this.btnFrameRef.UseVisualStyleBackColor = true;
            this.btnFrameRef.Click += new System.EventHandler(this.btnFrameRef_Click);
            // 
            // btnEditTag
            // 
            this.btnEditTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTag.Image = global::Animation_Creator.Properties.Resources.tag;
            this.btnEditTag.Location = new System.Drawing.Point(594, 272);
            this.btnEditTag.Name = "btnEditTag";
            this.btnEditTag.Size = new System.Drawing.Size(32, 32);
            this.btnEditTag.TabIndex = 23;
            this.btnEditTag.UseVisualStyleBackColor = true;
            this.btnEditTag.Click += new System.EventHandler(this.btnEditTag_Click);
            // 
            // btnChangeDelay
            // 
            this.btnChangeDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeDelay.Image = global::Animation_Creator.Properties.Resources.clock;
            this.btnChangeDelay.Location = new System.Drawing.Point(632, 272);
            this.btnChangeDelay.Name = "btnChangeDelay";
            this.btnChangeDelay.Size = new System.Drawing.Size(32, 32);
            this.btnChangeDelay.TabIndex = 22;
            this.btnChangeDelay.UseVisualStyleBackColor = true;
            this.btnChangeDelay.Click += new System.EventHandler(this.btnChangeDelay_Click);
            // 
            // btnDeleteFrame
            // 
            this.btnDeleteFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFrame.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFrame.Image")));
            this.btnDeleteFrame.Location = new System.Drawing.Point(670, 272);
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
            this.btnMoveUp.Location = new System.Drawing.Point(708, 272);
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
            this.btnMoveDown.Location = new System.Drawing.Point(746, 272);
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
            this.btnShowPreview.Location = new System.Drawing.Point(784, 272);
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
            this.btnShowText.Location = new System.Drawing.Point(822, 272);
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
            this.pbFrame.Location = new System.Drawing.Point(187, 39);
            this.pbFrame.Name = "pbFrame";
            this.pbFrame.Size = new System.Drawing.Size(200, 200);
            this.pbFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFrame.TabIndex = 3;
            this.pbFrame.TabStop = false;
            // 
            // btnSaveAsset
            // 
            this.btnSaveAsset.Location = new System.Drawing.Point(523, 359);
            this.btnSaveAsset.Name = "btnSaveAsset";
            this.btnSaveAsset.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAsset.TabIndex = 33;
            this.btnSaveAsset.Text = "Save pkg";
            this.btnSaveAsset.UseVisualStyleBackColor = true;
            this.btnSaveAsset.Click += new System.EventHandler(this.btnSaveAsset_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandom.Image = global::Animation_Creator.Properties.Resources.random;
            this.btnRandom.Location = new System.Drawing.Point(822, 310);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(32, 32);
            this.btnRandom.TabIndex = 34;
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.Location = new System.Drawing.Point(393, 322);
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(106, 23);
            this.btnSetDefault.TabIndex = 35;
            this.btnSetDefault.Text = "Set as default";
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Assets:";
            // 
            // lbAssets
            // 
            this.lbAssets.FormattingEnabled = true;
            this.lbAssets.Location = new System.Drawing.Point(12, 39);
            this.lbAssets.Name = "lbAssets";
            this.lbAssets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAssets.Size = new System.Drawing.Size(106, 212);
            this.lbAssets.TabIndex = 36;
            this.lbAssets.SelectedIndexChanged += new System.EventHandler(this.lbAssets_SelectedIndexChanged);
            // 
            // btnNewAsset
            // 
            this.btnNewAsset.Location = new System.Drawing.Point(12, 257);
            this.btnNewAsset.Name = "btnNewAsset";
            this.btnNewAsset.Size = new System.Drawing.Size(106, 23);
            this.btnNewAsset.TabIndex = 38;
            this.btnNewAsset.Text = "New Asset";
            this.btnNewAsset.UseVisualStyleBackColor = true;
            this.btnNewAsset.Click += new System.EventHandler(this.btnNewAsset_Click);
            // 
            // btnLoadToExisting
            // 
            this.btnLoadToExisting.Location = new System.Drawing.Point(12, 287);
            this.btnLoadToExisting.Name = "btnLoadToExisting";
            this.btnLoadToExisting.Size = new System.Drawing.Size(106, 23);
            this.btnLoadToExisting.TabIndex = 39;
            this.btnLoadToExisting.Text = "Add to existing";
            this.btnLoadToExisting.UseVisualStyleBackColor = true;
            this.btnLoadToExisting.Click += new System.EventHandler(this.btnLoadToExisting_Click);
            // 
            // btnLoadExistingAsset
            // 
            this.btnLoadExistingAsset.Location = new System.Drawing.Point(12, 316);
            this.btnLoadExistingAsset.Name = "btnLoadExistingAsset";
            this.btnLoadExistingAsset.Size = new System.Drawing.Size(106, 23);
            this.btnLoadExistingAsset.TabIndex = 40;
            this.btnLoadExistingAsset.Text = "Load existing";
            this.btnLoadExistingAsset.UseVisualStyleBackColor = true;
            this.btnLoadExistingAsset.Click += new System.EventHandler(this.btnLoadExistingAsset_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 417);
            this.Controls.Add(this.btnLoadExistingAsset);
            this.Controls.Add(this.btnLoadToExisting);
            this.Controls.Add(this.btnNewAsset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbAssets);
            this.Controls.Add(this.btnSetDefault);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnSaveAsset);
            this.Controls.Add(this.btnCurve);
            this.Controls.Add(this.lblAutoSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudDefaultDelay);
            this.Controls.Add(this.btnFrameRef);
            this.Controls.Add(this.btnPlayAction);
            this.Controls.Add(this.btnDeleteAction);
            this.Controls.Add(this.btnEditTag);
            this.Controls.Add(this.btnChangeDelay);
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
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "AmiMat （アミマト）by r1cebank";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefaultDelay)).EndInit();
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
        private System.Windows.Forms.ToolStripStatusLabel tssProjectName;
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
        private System.Windows.Forms.Button btnChangeDelay;
        private System.Windows.Forms.Button btnEditTag;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.Button btnPlayAction;
        private System.Windows.Forms.Button btnFrameRef;
        private System.Windows.Forms.NumericUpDown nudDefaultDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer tAutoSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAutoSave;
        private System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Button btnSaveAsset;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnSetDefault;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbAssets;
        private System.Windows.Forms.Button btnNewAsset;
        private System.Windows.Forms.Button btnLoadToExisting;
        private System.Windows.Forms.Button btnLoadExistingAsset;
    }
}

