namespace PadControlHelper {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            listViewMacroList = new ListView();
            columnHeader_No = new ColumnHeader();
            columnHeader_Title = new ColumnHeader();
            columnHeader_MousePoint = new ColumnHeader();
            columnHeader_Action = new ColumnHeader();
            columnHeader_Shortcut = new ColumnHeader();
            columnHeader_Switch = new ColumnHeader();
            columnHeader_SWCondition = new ColumnHeader();
            columnHeader_CHSwith = new ColumnHeader();
            columnHeader_CHValueTo = new ColumnHeader();
            groupBox1 = new GroupBox();
            lblHideMacroEditView = new Label();
            cboVariableValueTo = new ComboBox();
            cboVariableTo = new ComboBox();
            label10 = new Label();
            btnRemove = new Button();
            txtPointY = new TextBox();
            cboShortCut = new ComboBox();
            label7 = new Label();
            btnAdd = new Button();
            cboSWCondition = new ComboBox();
            cboVariable = new ComboBox();
            label4 = new Label();
            cboAction = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            txtPointX = new TextBox();
            label1 = new Label();
            txtTitle = new TextBox();
            panel1 = new Panel();
            chkOptAlwaysTop = new CheckBox();
            lblCloseSetup = new Label();
            chkMinimizeToTray = new CheckBox();
            chkStartMacroWhenRun = new CheckBox();
            chkRunWhenWindow = new CheckBox();
            label9 = new Label();
            lblOpenSetup = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            열기ToolStripMenuItem = new ToolStripMenuItem();
            매크로모드실행ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            종료ToolStripMenuItem = new ToolStripMenuItem();
            notifyIcon1 = new NotifyIcon(components);
            tmrLoopWhileMacroOn = new System.Windows.Forms.Timer(components);
            chkRunMacro = new CheckBox();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            lstVariableList = new ListView();
            btnDelVariable = new Button();
            btnEditVariable = new Button();
            btnAddVariable = new Button();
            label5 = new Label();
            label6 = new Label();
            pnlMainSwitch = new Panel();
            pictureBox1 = new PictureBox();
            btnShowMacroEditView = new Button();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            pnlMainSwitch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listViewMacroList
            // 
            listViewMacroList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewMacroList.CheckBoxes = true;
            listViewMacroList.Columns.AddRange(new ColumnHeader[] { columnHeader_No, columnHeader_Title, columnHeader_MousePoint, columnHeader_Action, columnHeader_Shortcut, columnHeader_Switch, columnHeader_SWCondition, columnHeader_CHSwith, columnHeader_CHValueTo });
            listViewMacroList.FullRowSelect = true;
            listViewMacroList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewMacroList.Location = new Point(12, 116);
            listViewMacroList.MultiSelect = false;
            listViewMacroList.Name = "listViewMacroList";
            listViewMacroList.Size = new Size(806, 380);
            listViewMacroList.TabIndex = 9;
            listViewMacroList.UseCompatibleStateImageBehavior = false;
            listViewMacroList.View = View.Details;
            listViewMacroList.ItemChecked += listViewMacroList_ItemChecked;
            listViewMacroList.ItemSelectionChanged += listViewMacroList_ItemSelectionChanged;
            // 
            // columnHeader_No
            // 
            columnHeader_No.Text = "No";
            // 
            // columnHeader_Title
            // 
            columnHeader_Title.Text = "Title";
            columnHeader_Title.Width = 150;
            // 
            // columnHeader_MousePoint
            // 
            columnHeader_MousePoint.Text = "Point";
            columnHeader_MousePoint.Width = 100;
            // 
            // columnHeader_Action
            // 
            columnHeader_Action.Text = "Action";
            columnHeader_Action.Width = 80;
            // 
            // columnHeader_Shortcut
            // 
            columnHeader_Shortcut.Text = "Shortcut";
            columnHeader_Shortcut.Width = 80;
            // 
            // columnHeader_Switch
            // 
            columnHeader_Switch.Text = "Switch";
            columnHeader_Switch.Width = 90;
            // 
            // columnHeader_SWCondition
            // 
            columnHeader_SWCondition.Text = "SWCondition";
            columnHeader_SWCondition.Width = 90;
            // 
            // columnHeader_CHSwith
            // 
            columnHeader_CHSwith.Text = "ChangeSwith";
            columnHeader_CHSwith.Width = 90;
            // 
            // columnHeader_CHValueTo
            // 
            columnHeader_CHValueTo.Text = "ValueTo";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblHideMacroEditView);
            groupBox1.Controls.Add(cboVariableValueTo);
            groupBox1.Controls.Add(cboVariableTo);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(btnRemove);
            groupBox1.Controls.Add(txtPointY);
            groupBox1.Controls.Add(cboShortCut);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(cboSWCondition);
            groupBox1.Controls.Add(cboVariable);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboAction);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPointX);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTitle);
            groupBox1.Location = new Point(12, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(806, 109);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // lblHideMacroEditView
            // 
            lblHideMacroEditView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHideMacroEditView.AutoSize = true;
            lblHideMacroEditView.Location = new Point(785, 6);
            lblHideMacroEditView.Name = "lblHideMacroEditView";
            lblHideMacroEditView.Size = new Size(19, 15);
            lblHideMacroEditView.TabIndex = 32;
            lblHideMacroEditView.Text = "Ｘ";
            lblHideMacroEditView.TextAlign = ContentAlignment.MiddleCenter;
            lblHideMacroEditView.Click += lblHideMacroEditView_Click;
            // 
            // cboVariableValueTo
            // 
            cboVariableValueTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariableValueTo.Enabled = false;
            cboVariableValueTo.FormattingEnabled = true;
            cboVariableValueTo.Location = new Point(501, 70);
            cboVariableValueTo.Name = "cboVariableValueTo";
            cboVariableValueTo.Size = new Size(87, 23);
            cboVariableValueTo.TabIndex = 31;
            // 
            // cboVariableTo
            // 
            cboVariableTo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariableTo.FormattingEnabled = true;
            cboVariableTo.Location = new Point(408, 70);
            cboVariableTo.Name = "cboVariableTo";
            cboVariableTo.Size = new Size(87, 23);
            cboVariableTo.TabIndex = 30;
            cboVariableTo.SelectionChangeCommitted += cboVariable_SelectionChangeCommitted;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(277, 74);
            label10.Name = "label10";
            label10.Size = new Size(127, 15);
            label10.TabIndex = 29;
            label10.Text = "작동완료 후 변수 변경";
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(725, 62);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 37);
            btnRemove.TabIndex = 28;
            btnRemove.Text = "입력초기화";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // txtPointY
            // 
            txtPointY.Location = new Point(347, 27);
            txtPointY.MaxLength = 6;
            txtPointY.Name = "txtPointY";
            txtPointY.Size = new Size(45, 23);
            txtPointY.TabIndex = 3;
            txtPointY.Text = "0";
            // 
            // cboShortCut
            // 
            cboShortCut.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShortCut.FormattingEnabled = true;
            cboShortCut.Location = new Point(670, 27);
            cboShortCut.Name = "cboShortCut";
            cboShortCut.Size = new Size(130, 23);
            cboShortCut.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(614, 31);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 24;
            label7.Text = "Shortcut";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(644, 62);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 37);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "추가";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboSWCondition
            // 
            cboSWCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSWCondition.Enabled = false;
            cboSWCondition.FormattingEnabled = true;
            cboSWCondition.Location = new Point(160, 70);
            cboSWCondition.Name = "cboSWCondition";
            cboSWCondition.Size = new Size(87, 23);
            cboSWCondition.TabIndex = 7;
            // 
            // cboVariable
            // 
            cboVariable.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVariable.FormattingEnabled = true;
            cboVariable.Location = new Point(67, 70);
            cboVariable.Name = "cboVariable";
            cboVariable.Size = new Size(87, 23);
            cboVariable.TabIndex = 6;
            cboVariable.SelectionChangeCommitted += cboVariable_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 74);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 18;
            label4.Text = "발동조건";
            // 
            // cboAction
            // 
            cboAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAction.FormattingEnabled = true;
            cboAction.Location = new Point(473, 28);
            cboAction.Name = "cboAction";
            cboAction.Size = new Size(115, 23);
            cboAction.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(429, 33);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 16;
            label3.Text = "Action";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 31);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 15;
            label2.Text = "Point(캡쳐:F10)";
            // 
            // txtPointX
            // 
            txtPointX.Location = new Point(300, 27);
            txtPointX.MaxLength = 6;
            txtPointX.Name = "txtPointX";
            txtPointX.Size = new Size(45, 23);
            txtPointX.TabIndex = 2;
            txtPointX.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 31);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 13;
            label1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(39, 27);
            txtTitle.MaxLength = 49;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(151, 23);
            txtTitle.TabIndex = 1;
            txtTitle.KeyDown += txtTitle_KeyDown;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(chkOptAlwaysTop);
            panel1.Controls.Add(lblCloseSetup);
            panel1.Controls.Add(chkMinimizeToTray);
            panel1.Controls.Add(chkStartMacroWhenRun);
            panel1.Controls.Add(chkRunWhenWindow);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(2, 471);
            panel1.Name = "panel1";
            panel1.Size = new Size(1071, 43);
            panel1.TabIndex = 13;
            panel1.Visible = false;
            // 
            // chkOptAlwaysTop
            // 
            chkOptAlwaysTop.AutoSize = true;
            chkOptAlwaysTop.Location = new Point(532, 14);
            chkOptAlwaysTop.Name = "chkOptAlwaysTop";
            chkOptAlwaysTop.Size = new Size(66, 19);
            chkOptAlwaysTop.TabIndex = 5;
            chkOptAlwaysTop.Text = "항상 위";
            chkOptAlwaysTop.UseVisualStyleBackColor = true;
            chkOptAlwaysTop.CheckedChanged += chkOptAlwaysTop_CheckedChanged;
            // 
            // lblCloseSetup
            // 
            lblCloseSetup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCloseSetup.AutoSize = true;
            lblCloseSetup.Location = new Point(1050, 2);
            lblCloseSetup.Name = "lblCloseSetup";
            lblCloseSetup.Size = new Size(19, 15);
            lblCloseSetup.TabIndex = 4;
            lblCloseSetup.Text = "Ｘ";
            lblCloseSetup.TextAlign = ContentAlignment.MiddleCenter;
            lblCloseSetup.Click += lblCloseSetup_Click;
            // 
            // chkMinimizeToTray
            // 
            chkMinimizeToTray.AutoSize = true;
            chkMinimizeToTray.Location = new Point(388, 14);
            chkMinimizeToTray.Name = "chkMinimizeToTray";
            chkMinimizeToTray.Size = new Size(138, 19);
            chkMinimizeToTray.TabIndex = 3;
            chkMinimizeToTray.Text = "최소화시 트레이모드";
            chkMinimizeToTray.UseVisualStyleBackColor = true;
            chkMinimizeToTray.CheckedChanged += chkOpt_CheckedChanged;
            // 
            // chkStartMacroWhenRun
            // 
            chkStartMacroWhenRun.AutoSize = true;
            chkStartMacroWhenRun.Location = new Point(228, 14);
            chkStartMacroWhenRun.Name = "chkStartMacroWhenRun";
            chkStartMacroWhenRun.Size = new Size(154, 19);
            chkStartMacroWhenRun.TabIndex = 2;
            chkStartMacroWhenRun.Text = "시작시 매크로 실행모드";
            chkStartMacroWhenRun.UseVisualStyleBackColor = true;
            chkStartMacroWhenRun.CheckedChanged += chkOpt_CheckedChanged;
            // 
            // chkRunWhenWindow
            // 
            chkRunWhenWindow.AutoSize = true;
            chkRunWhenWindow.Location = new Point(68, 14);
            chkRunWhenWindow.Name = "chkRunWhenWindow";
            chkRunWhenWindow.Size = new Size(154, 19);
            chkRunWhenWindow.TabIndex = 1;
            chkRunWhenWindow.Text = "윈도우 시작시 자동실행";
            chkRunWhenWindow.UseVisualStyleBackColor = true;
            chkRunWhenWindow.CheckedChanged += chkOpt_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 15);
            label9.Name = "label9";
            label9.Size = new Size(31, 15);
            label9.TabIndex = 0;
            label9.Text = "설정";
            // 
            // lblOpenSetup
            // 
            lblOpenSetup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblOpenSetup.Location = new Point(2, 499);
            lblOpenSetup.Name = "lblOpenSetup";
            lblOpenSetup.Size = new Size(1071, 15);
            lblOpenSetup.TabIndex = 14;
            lblOpenSetup.Text = "▲";
            lblOpenSetup.TextAlign = ContentAlignment.TopCenter;
            lblOpenSetup.Click += lblOpenSetup_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 열기ToolStripMenuItem, 매크로모드실행ToolStripMenuItem, toolStripMenuItem1, 종료ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(167, 76);
            // 
            // 열기ToolStripMenuItem
            // 
            열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            열기ToolStripMenuItem.Size = new Size(166, 22);
            열기ToolStripMenuItem.Text = "열기";
            열기ToolStripMenuItem.Click += 열기ToolStripMenuItem_Click;
            // 
            // 매크로모드실행ToolStripMenuItem
            // 
            매크로모드실행ToolStripMenuItem.Name = "매크로모드실행ToolStripMenuItem";
            매크로모드실행ToolStripMenuItem.Size = new Size(166, 22);
            매크로모드실행ToolStripMenuItem.Text = "매크로 모드 실행";
            매크로모드실행ToolStripMenuItem.Click += 매크로모드실행ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(163, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            종료ToolStripMenuItem.Size = new Size(166, 22);
            종료ToolStripMenuItem.Text = "종료";
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Text = "PCH";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // tmrLoopWhileMacroOn
            // 
            tmrLoopWhileMacroOn.Interval = 400;
            tmrLoopWhileMacroOn.Tick += tmrLoopWhileMacroOn_Tick;
            // 
            // chkRunMacro
            // 
            chkRunMacro.Font = new Font("맑은 고딕", 24F, FontStyle.Regular, GraphicsUnit.Point, 129);
            chkRunMacro.Location = new Point(85, 13);
            chkRunMacro.Name = "chkRunMacro";
            chkRunMacro.Size = new Size(223, 73);
            chkRunMacro.TabIndex = 15;
            chkRunMacro.Text = "매크로 실행";
            chkRunMacro.TextAlign = ContentAlignment.MiddleCenter;
            chkRunMacro.UseVisualStyleBackColor = true;
            chkRunMacro.CheckedChanged += chkRunMacro_CheckedChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "변수명";
            columnHeader2.Width = 100;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "현재 값";
            // 
            // lstVariableList
            // 
            lstVariableList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lstVariableList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader10 });
            lstVariableList.FullRowSelect = true;
            lstVariableList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstVariableList.Location = new Point(824, 64);
            lstVariableList.MultiSelect = false;
            lstVariableList.Name = "lstVariableList";
            lstVariableList.Size = new Size(239, 432);
            lstVariableList.TabIndex = 16;
            lstVariableList.UseCompatibleStateImageBehavior = false;
            lstVariableList.View = View.Details;
            lstVariableList.ItemSelectionChanged += lstVariableList_ItemSelectionChanged;
            lstVariableList.MouseDoubleClick += lstVariableList_MouseDoubleClick;
            // 
            // btnDelVariable
            // 
            btnDelVariable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelVariable.Enabled = false;
            btnDelVariable.Location = new Point(989, 37);
            btnDelVariable.Name = "btnDelVariable";
            btnDelVariable.Size = new Size(75, 23);
            btnDelVariable.TabIndex = 19;
            btnDelVariable.Text = "삭제";
            btnDelVariable.UseVisualStyleBackColor = true;
            btnDelVariable.Click += btnDeleteVariable_Click;
            // 
            // btnEditVariable
            // 
            btnEditVariable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditVariable.Enabled = false;
            btnEditVariable.Location = new Point(908, 37);
            btnEditVariable.Name = "btnEditVariable";
            btnEditVariable.Size = new Size(75, 23);
            btnEditVariable.TabIndex = 18;
            btnEditVariable.Text = "수정";
            btnEditVariable.UseVisualStyleBackColor = true;
            btnEditVariable.Click += btnAddVariable_Click;
            // 
            // btnAddVariable
            // 
            btnAddVariable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddVariable.Location = new Point(827, 37);
            btnAddVariable.Name = "btnAddVariable";
            btnAddVariable.Size = new Size(75, 23);
            btnAddVariable.TabIndex = 17;
            btnAddVariable.Text = "추가";
            btnAddVariable.UseVisualStyleBackColor = true;
            btnAddVariable.Click += btnAddVariable_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.Location = new Point(827, 14);
            label5.Name = "label5";
            label5.Size = new Size(236, 15);
            label5.TabIndex = 20;
            label5.Text = "변수";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.BackColor = Color.FromArgb(224, 224, 224);
            label6.Location = new Point(824, 9);
            label6.Name = "label6";
            label6.Size = new Size(239, 1);
            label6.TabIndex = 21;
            // 
            // pnlMainSwitch
            // 
            pnlMainSwitch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMainSwitch.Controls.Add(pictureBox1);
            pnlMainSwitch.Controls.Add(btnShowMacroEditView);
            pnlMainSwitch.Controls.Add(chkRunMacro);
            pnlMainSwitch.Location = new Point(13, 8);
            pnlMainSwitch.Name = "pnlMainSwitch";
            pnlMainSwitch.Size = new Size(804, 101);
            pnlMainSwitch.TabIndex = 22;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = PadControllHelper.res.iconImg64;
            pictureBox1.Location = new Point(10, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // btnShowMacroEditView
            // 
            btnShowMacroEditView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowMacroEditView.Location = new Point(642, 14);
            btnShowMacroEditView.Name = "btnShowMacroEditView";
            btnShowMacroEditView.Size = new Size(134, 72);
            btnShowMacroEditView.TabIndex = 16;
            btnShowMacroEditView.Text = "새 매크로 추가\r\nor\r\n매크로 편집모드";
            btnShowMacroEditView.UseVisualStyleBackColor = true;
            btnShowMacroEditView.Click += btnShowMacroEditView_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 514);
            Controls.Add(pnlMainSwitch);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnDelVariable);
            Controls.Add(btnEditVariable);
            Controls.Add(btnAddVariable);
            Controls.Add(lblOpenSetup);
            Controls.Add(panel1);
            Controls.Add(lstVariableList);
            Controls.Add(groupBox1);
            Controls.Add(listViewMacroList);
            Name = "Form1";
            Text = "LeeBaeng PCH Macro v1.0";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            pnlMainSwitch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewMacroList;
        private ColumnHeader columnHeader_No;
        private ColumnHeader columnHeader_Title;
        private ColumnHeader columnHeader_MousePoint;
        private ColumnHeader columnHeader_Action;
        private ColumnHeader columnHeader_Switch;
        private ColumnHeader columnHeader_SWCondition;
        private GroupBox groupBox1;
        private ComboBox cboSWCondition;
        private ComboBox cboVariable;
        private Label label4;
        private ComboBox cboAction;
        private Label label3;
        private Label label2;
        private TextBox txtPointX;
        private Label label1;
        private TextBox txtTitle;
        private Button btnAdd;
        private ComboBox cboShortCut;
        private Label label7;
        private TextBox txtPointY;
        private Button btnRemove;
        private ColumnHeader columnHeader_Shortcut;
        private Panel panel1;
        private Label label9;
        private CheckBox chkRunWhenWindow;
        private CheckBox chkMinimizeToTray;
        private CheckBox chkStartMacroWhenRun;
        private Label lblCloseSetup;
        private Label lblOpenSetup;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 열기ToolStripMenuItem;
        private ToolStripMenuItem 매크로모드실행ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem 종료ToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer tmrLoopWhileMacroOn;
        private CheckBox chkRunMacro;
        private ComboBox cboVariableValueTo;
        private ComboBox cboVariableTo;
        private Label label10;
        private ColumnHeader columnHeader_CHSwith;
        private ColumnHeader columnHeader_CHValueTo;
        private CheckBox chkOptAlwaysTop;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader10;
        private ListView lstVariableList;
        private Button btnDelVariable;
        private Button btnEditVariable;
        private Button btnAddVariable;
        private Label label5;
        private Label label6;
        private Panel pnlMainSwitch;
        private Button btnShowMacroEditView;
        private Label lblHideMacroEditView;
        private PictureBox pictureBox1;
    }
}
