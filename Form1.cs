using PadControllHelper;
using System.Data;
using System.Diagnostics;
using UKW.Util.common;

namespace PadControlHelper {
    public partial class Form1 : Form, IPopupListener {

        private List<Variable> vars = new List<Variable>();
        private List<Macro> macros = new List<Macro>();
        private PopAddVariable popAddVariable;
        private PopupSelectProgram popSelectProgram;

        private GlobalKeyHook gkHook;
        private GlobalMouseHook gmHook;
        private CboItems cboItems;
        private SQLitePCH sqLite = new SQLitePCH();
        private bool isEditMode = false;
        private bool isMacroRunning = false;
        private RegistryHelperPCH regHelper;
        private bool changeIconFlag = true;
        private bool initComplete = false;

        public Form1() {
            InitializeComponent();
            KeyList.initKeyList();
            popAddVariable = new PopAddVariable(this);
            popSelectProgram = new PopupSelectProgram(this);
        }

        private void Form1_Load(object sender, EventArgs e) {
            notifyIcon1.Icon = PadControllHelper.res.icon2;

            cboItems = new CboItems();

            //cboActionItem 추가
            foreach(KeyValuePair<string, CboActionItem> kv in cboItems.cboActionItems)
                cboAction.Items.Add(kv.Value);

            // cboShortCut 추가
            foreach(KeyValuePair<string, CboShortcutItem> kv in cboItems.cboShortcutItems)
                cboShortCut.Items.Add(kv.Value);

            // cboSWCondition
            foreach(KeyValuePair<string, CboActivateCondition> kv in cboItems.cboActivateCondition) {
                cboSWCondition.Items.Add(kv.Value);
                if(kv.Value.activateCondition != ActivateCondition.ANY)
                    cboVariableValueTo.Items.Add(kv.Value);
            }

            //cboVariableItem 추가
            readVariableListFromDB();
            updateVariableList();

            // 매크로 리스트 구성
            updateMacroList();


            gkHook = new GlobalKeyHook();
            gkHook.AddKeyDownHandler(KeyDownHandler);
            gkHook.Start();

            gmHook = new GlobalMouseHook();
            gmHook.Start();

            initInputValues();

            initRegistry();

            initComplete = true;
        }

        private Variable? getSwitch(int id) {
            foreach(Variable s in vars) {
                if(s.id == id)
                    return s;
            }
            return null;
        }

        private void initRegistry() {
            regHelper = new RegistryHelperPCH();
            chkRunWhenWindow.Checked = regHelper.getOpt_AutoRun();
            chkStartMacroWhenRun.Checked = regHelper.getOpt_AutoMacroOn();
            chkMinimizeToTray.Checked = regHelper.getOpt_TrayMode();
            chkOptAlwaysTop.Checked = regHelper.getOpt_AlwaysTop();
        }


        #region =============================================== Popup Listener ===============================================
        public void onPopupConfirmed(Popup popup, object data) {
            if(popup != null && data != null) {
                if(popup.Equals(popAddVariable)) {
                    if(data is Variable) {
                        if(popAddVariable.editVar == null) {
                            Variable s = (Variable)data;
                            sqLite.Insert(SQLitePCH.TB_VAR + "('" + SQLitePCH.VAR_NAME + "','" + SQLitePCH.VAR_VALUE + "')", "'" + s.name + "', '" + s.value.ToString() + "'");
                        } else {
                            Variable s = (Variable)data;
                            sqLite.Update(SQLitePCH.TB_VAR, SQLitePCH.VAR_NAME + "='" + s.name + "', " + SQLitePCH.VAR_VALUE + " = '" + s.value.ToString() + "'", "id=" + s.id);
                        }
                        readVariableListFromDB();
                        updateVariableList();
                    }
                } else if(popup.Equals(popSelectProgram) && data is RunInfo) {
                    setProgramPath((RunInfo)data);
                }
            }
        }
        public void onPopupCanceled(Popup popup) {
            Debug.WriteLine(popup.ToString());
            if(popup != null && popup.Equals(popAddVariable)) {
                cboVariable.SelectedIndex = 0;
                updateCboVariablesSubUiState(cboVariable);
            }
        }
        #endregion


        #region ============================================= WinForm & UI Events =============================================
        private void cboVariable_SelectionChangeCommitted(object sender, EventArgs e) {
            if(sender != null && sender is ComboBox)
                updateCboVariablesSubUiState(sender as ComboBox);
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            if(isEditMode && listViewMacroList.SelectedItems != null && listViewMacroList.SelectedItems[0].Tag is Macro) {
                Macro macro = (Macro)listViewMacroList.SelectedItems[0].Tag;
                sqLite.DeleteDetail(SQLitePCH.TB_MACRO, SQLitePCH.MACRO_Id, macro.id);
                updateMacroList();
            } else {
                initInputValues();
            }
        }

        private void btnDeleteVariable_Click(object sender, EventArgs e) {
            if(lstVariableList.SelectedItems != null && lstVariableList.SelectedItems.Count > 0 && lstVariableList.SelectedItems[0].Tag is Variable) {
                var s = lstVariableList.SelectedItems[0].Tag as Variable;
                sqLite.DeleteDetail(SQLitePCH.TB_VAR, SQLitePCH.VAR_Id, s.id);
                cboVariable.SelectedIndex = 0;
                updateCboVariablesSubUiState(cboVariable);
                readVariableListFromDB();
                updateVariableList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            //if(cboVariable.SelectedItem == cboItems.cboVarItems[CboVariableItem.ADDNEW]) {
            //    MessageBox.Show("스위치 선택값이 올바르지 않습니다. 미사용 혹은 사용할 변수 값을 선택해 주셈");
            //    return;
            //}

            if(txtTitle.Text.Trim().Equals("") || txtTitle.Text.Length < 2) {
                MessageBox.Show("매크로 제목을 올바르게 입력해주세요.(공백 불가, 3글자 이상 필수)");
                return;
            }

            if(cboAction.SelectedItem == null || cboShortCut.SelectedItem == null) {
                MessageBox.Show("Action, Shortcut 선택이 올바르지 않음.");
                return;
            }

            if(cboAction.SelectedItem == cboItems.cboActionItems[CboActionItem.RUN_PROGRAM] && lblFilePath.Text == "") {
                MessageBox.Show("실행할 프로그램 경로가 올바르지 않습니다.");
                return;
            }

            Macro m = new Macro(
                        txtTitle.Text,
                        Int32.Parse(txtPointX.Text),
                        Int32.Parse(txtPointY.Text),
                        (cboAction.SelectedItem as CboActionItem).action,
                        (cboShortCut.SelectedItem as CboShortcutItem).keyInfo,
                        (cboVariable.SelectedItem != null && cboVariable.SelectedItem != cboItems.cboVarItems[CboVariableItem.NOTUSE]) ? cboVariable.SelectedItem as Variable : null,
                        cboSWCondition.Enabled ? (cboSWCondition.SelectedItem as CboActivateCondition).activateCondition : ActivateCondition.ANY,
                        true,
                        (cboVariableTo.SelectedItem != null && cboVariableTo.SelectedItem != cboItems.cboVarItems[CboVariableItem.NOTUSE]) ? cboVariableTo.SelectedItem as Variable : null,
                        cboVariableValueTo.Enabled ? (cboVariableValueTo.SelectedItem as CboActivateCondition).activateCondition : ActivateCondition.ANY,
                        (lblFilePath.Tag != null && lblFilePath.Tag is RunInfo) ? lblFilePath.Tag as RunInfo : null
                    );

            if(!isEditMode) {
                // 추가
                sqLite.Insert(
                    SQLitePCH.TB_MACRO + "('" +
                    SQLitePCH.MACRO_TITLE + "','" +
                    SQLitePCH.MACRO_POINTX + "','" +
                    SQLitePCH.MACRO_POINTY + "','" +
                    SQLitePCH.MACRO_ACTION + "','" +
                    SQLitePCH.MACRO_SHORTCUT + "','" +
                    SQLitePCH.MACRO_SWITCH + "','" +
                    SQLitePCH.MACRO_SWCONDITION + "','" +
                    SQLitePCH.MACRO_SWITCHTO + "','" +
                    SQLitePCH.MACRO_VALUETO + "','" +
                    SQLitePCH.MACRO_PROGRAMPATH + "','" +
                    SQLitePCH.MACRO_PROGRAMARGS
                    + "')",
                    "'" + m.title + "'," +
                    m.pointX + ", " +
                    m.pointY + ", " +
                    (int)m.action + ", " +
                    (int)m.keyInfo.key + ", " +
                    ((m.variable != null) ? m.variable.id : -1) + ", " +
                    (int)m.activateCondition + ", " +
                    ((m.changeAfterVar != null) ? (int)m.changeAfterVar.id : -1) + ", " +
                    (int)m.changeValueTo + ", " +
                    "'" + m.runInfo?.fullPath + "', " +
                    "'" + m.runInfo?.arguments + "', "
                    );

            } else {
                // 수정
                if(listViewMacroList.SelectedItems != null && listViewMacroList.SelectedItems.Count > 0) {
                    m.id = (listViewMacroList.SelectedItems[0].Tag as Macro).id;
                    sqLite.Update(
                        SQLitePCH.TB_MACRO,
                        SQLitePCH.MACRO_TITLE + "=" + "'" + m.title + "'," +
                        SQLitePCH.MACRO_POINTX + "=" + m.pointX + ", " +
                        SQLitePCH.MACRO_POINTY + "=" + m.pointY + ", " +
                        SQLitePCH.MACRO_ACTION + "=" + (int)m.action + ", " +
                        SQLitePCH.MACRO_SHORTCUT + "=" + (int)m.keyInfo.key + ", " +
                        SQLitePCH.MACRO_SWITCH + "=" + ((m.variable != null) ? m.variable.id : -1) + ", " +
                        SQLitePCH.MACRO_SWCONDITION + "=" + (int)m.activateCondition + ", " +
                        SQLitePCH.MACRO_SWITCHTO + "=" + ((m.changeAfterVar != null) ? m.changeAfterVar.id : -1) + ", " +
                        SQLitePCH.MACRO_VALUETO + "=" + (int)m.changeValueTo + ", " +
                        SQLitePCH.MACRO_PROGRAMPATH + "=" + "'" + m.runInfo?.fullPath + "', " +
                        SQLitePCH.MACRO_PROGRAMARGS + "=" + "'" + m.runInfo?.arguments + "'"
                        , "id=" + m.id
                    );
                }
            }
            updateMacroList();
            setEditMode(false);
            initInputValues();
        }

        private void listViewMacroList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if(e.Item != null && e.IsSelected) {
                if(e.Item.Tag != null && e.Item.Tag is Macro) {
                    Macro macro = (Macro)e.Item.Tag;
                    setEditMode(true);
                    txtTitle.Text = macro.title;
                    txtPointX.Text = macro.pointX.ToString();
                    txtPointY.Text = macro.pointY.ToString();

                    foreach(CboActionItem ci in cboAction.Items)
                        if(ci.action == macro.action) {
                            cboAction.SelectedItem = ci;
                            setProgramPath(macro.runInfo);
                            if(macro.action == MacroAction.RUN_PROGRAM) {
                                txtPointX.Enabled = false;
                                txtPointY.Enabled = false;
                            } else {
                                txtPointX.Enabled = true;
                                txtPointY.Enabled = true;
                            }
                        }

                    foreach(CboShortcutItem ci in cboShortCut.Items)
                        if(ci.keyInfo == macro.keyInfo)
                            cboShortCut.SelectedItem = ci;

                    if(macro.variable != null) {
                        foreach(Variable v in vars) {
                            if(v == macro.variable)
                                cboVariable.SelectedItem = v;
                            if(v == macro.changeAfterVar)
                                cboVariableTo.SelectedItem = v;
                        }

                        foreach(CboActivateCondition ci in cboSWCondition.Items)
                            if(ci.activateCondition == macro.activateCondition)
                                cboSWCondition.SelectedItem = ci;

                        foreach(CboActivateCondition ci in cboVariableValueTo.Items)
                            if(ci.activateCondition == macro.changeValueTo)
                                cboVariableValueTo.SelectedItem = ci;

                        updateCboVariablesSubUiState(cboVariable);
                        updateCboVariablesSubUiState(cboVariableTo);
                    } else {
                        cboVariable.SelectedIndex = 0;
                        cboSWCondition.SelectedIndex = 0;
                        cboVariableTo.SelectedIndex = 0;
                        cboVariableValueTo.SelectedIndex = 0;

                        updateCboVariablesSubUiState(cboVariable);
                        updateCboVariablesSubUiState(cboVariableTo);
                    }
                }

            } else {
                setEditMode(false);
                initInputValues();
            }
        }

        private void lblOpenSetup_Click(object sender, EventArgs e) {
            lblOpenSetup.Visible = false;
            panel1.Visible = true;
        }

        private void lblCloseSetup_Click(object sender, EventArgs e) {
            lblOpenSetup.Visible = true;
            panel1.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            gkHook.Stop();
            gmHook.Stop();
            foreach(ListViewItem item in listViewMacroList.Items) {
                if(item.Tag != null && item.Tag is Macro) {
                    Macro? m = item.Tag as Macro;
                    if(m != null) {
                        m.power = item.Checked;
                        sqLite.Update(
                            SQLitePCH.TB_MACRO,
                            SQLitePCH.MACRO_POWER + "=" + m.power,
                            "id=" + m.id
                        );
                    }
                }
            }
        }

        private void chkOpt_CheckedChanged(object sender, EventArgs e) {
            if(sender is CheckBox) {
                if(sender == chkRunWhenWindow)
                    regHelper.setOpt_AutoRun(((CheckBox)sender).Checked);
                else if(sender == chkStartMacroWhenRun)
                    regHelper.setOpt_AutoMacroOn(((CheckBox)sender).Checked);
                else if(sender == chkMinimizeToTray)
                    regHelper.setOpt_TrayMode(((CheckBox)sender).Checked);
            }
        }

        private void chkOptAlwaysTop_CheckedChanged(object sender, EventArgs e) {
            this.TopMost = ((CheckBox)sender).Checked;
            regHelper.setOpt_AlwaysTop(((CheckBox)sender).Checked);

        }

        private void Form1_Resize(object sender, EventArgs e) {
            if(this.WindowState == FormWindowState.Minimized) {
                if(chkMinimizeToTray.Checked) {
                    this.Hide();
                    notifyIcon1.Visible = true;
                }
            }
        }

        private void tmrLoopWhileMacroOn_Tick(object sender, EventArgs e) {
            if(isMacroRunning) {
                changeIconFlag = !changeIconFlag;
                if(changeIconFlag) {
                    notifyIcon1.Icon = res.icon21;
                    pictureBox1.Image = res.iconImg64;
                } else {
                    notifyIcon1.Icon = res.icon2;
                    pictureBox1.Image = res.iconimg64_2;
                }
            }
        }

        private void chkRunMacro_CheckedChanged(object sender, EventArgs e) {
            changeMacroMode(chkRunMacro.Checked);
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void 매크로모드실행ToolStripMenuItem_Click(object sender, EventArgs e) {
            changeMacroMode(!isMacroRunning);
        }

        private void changeMacroMode(bool isRun) {
            isMacroRunning = isRun;
            chkRunMacro.Checked = isMacroRunning;
            if(isMacroRunning) {
                tmrLoopWhileMacroOn.Enabled = true;
                groupBox1.Enabled = false;
                매크로모드실행ToolStripMenuItem.Text = "매크로모드 중단";
                btnEditVariable.Enabled = false;
                btnDelVariable.Enabled = false;
                btnAddVariable.Enabled = false;
                btnShowMacroEditView.Enabled = false;
                pictureBox1.Visible = true;
            } else {
                tmrLoopWhileMacroOn.Enabled = false;
                groupBox1.Enabled = true;
                매크로모드실행ToolStripMenuItem.Text = "매크로모드 실행";
                btnEditVariable.Enabled = true;
                btnDelVariable.Enabled = true;
                btnAddVariable.Enabled = true;
                btnShowMacroEditView.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                if(txtTitle.Text == "open sqlite debugger" || txtTitle.Text == "show sqlite debugger") {
                    new FrmDebugDB(sqLite).Show();
                }
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e) {
            열기ToolStripMenuItem_Click(null, null);
        }

        private void listViewMacroList_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if(!initComplete)
                return;

            ListViewItem item = e.Item as ListViewItem;

            if(item != null) {
                Macro? m = item.Tag as Macro;
                if(m != null) {
                    m.power = item.Checked;
                }
            }
        }

        private void btnAddVariable_Click(object sender, EventArgs e) {
            popAddVariable.editVar = null;
            if(sender == btnEditVariable && lstVariableList.SelectedItems != null && lstVariableList.SelectedItems.Count > 0 && lstVariableList.SelectedItems[0].Tag is Variable) {
                LLog.info(lstVariableList.SelectedItems[0].Tag.ToString());
                popAddVariable.editVar = lstVariableList.SelectedItems[0].Tag as Variable;
            }
            popAddVariable.TopMost = chkOptAlwaysTop.Checked;
            popAddVariable.ShowDialog(this);
        }

        private void lstVariableList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            btnEditVariable.Enabled = e.IsSelected;
            btnDelVariable.Enabled = e.IsSelected;
        }

        private void lstVariableList_MouseDoubleClick(object sender, MouseEventArgs e) {
            btnAddVariable_Click(btnEditVariable, null);
        }

        private void btnShowMacroEditView_Click(object sender, EventArgs e) {
            pnlMainSwitch.Hide();
        }

        private void lblHideMacroEditView_Click(object sender, EventArgs e) {
            pnlMainSwitch.Show();
        }

        private void Form1_Shown(object sender, EventArgs e) {
            if(regHelper.getOpt_AutoMacroOn()) {
                changeMacroMode(true);

                if(regHelper.getOpt_AutoMacroOn()) {
                    if(chkMinimizeToTray.Checked) {
                        this.Hide();
                        notifyIcon1.Visible = true;
                    }
                }
            }
        }

        private void cboAction_SelectionChangeCommitted(object sender, EventArgs e) {
            if(cboAction.SelectedItem != null && cboAction.SelectedItem == cboItems.cboActionItems[CboActionItem.RUN_PROGRAM]) {
                popSelectProgram.TopMost = chkOptAlwaysTop.Checked;
                if(isEditMode && listViewMacroList.SelectedItems != null && listViewMacroList.SelectedItems[0].Tag != null && listViewMacroList.SelectedItems[0].Tag is Macro) {
                    Macro m = listViewMacroList.SelectedItems[0].Tag as Macro;
                    popSelectProgram.edtRuninfo = m.runInfo;
                } else {
                    popSelectProgram.edtRuninfo = null;
                }
                popSelectProgram.ShowDialog(this);
                txtPointX.Enabled = false;
                txtPointY.Enabled = false;
            } else {
                txtPointX.Enabled = true;
                txtPointY.Enabled = true;
                lblFilePath.Text = "";
            }
        }
        #endregion

        #region ======================================================= UI State Control =======================================================
        private void initInputValues() {
            //초기 콤보박스의 SelectedIndex 설정
            cboVariable.SelectedIndex = 0;
            cboVariableTo.SelectedIndex = 0;
            cboSWCondition.SelectedIndex = 0;
            cboVariableValueTo.SelectedIndex = 0;
            txtTitle.Text = "";
            txtPointX.Text = "0";
            txtPointY.Text = "0";
            cboSWCondition.SelectedIndex = 0;
            cboVariable.SelectedIndex = 0;
            cboShortCut.SelectedIndex = -1;
            cboAction.SelectedIndex = -1;

            txtPointX.Enabled = true;
            txtPointY.Enabled = true;
            lblFilePath.Text = "";

            cboVariable_SelectionChangeCommitted(cboVariable, null);
        }

        private void updateCboVariablesSubUiState(ComboBox combo) {
            if(combo.SelectedItem != null) {
                if(combo == cboVariable) {
                    if(combo.SelectedItem == cboItems.cboVarItems[CboVariableItem.NOTUSE]) {
                        cboSWCondition.Enabled = false;
                        //} else if(combo.SelectedItem == cboItems.cboVarItems[CboVariableItem.ADDNEW]) {
                        //    cboSWCondition.Enabled = false;
                        //    btnDeleteVariable.Enabled = false;
                        //    popAddVariable.ShowDialog(this);
                    } else {
                        cboSWCondition.Enabled = true;
                    }
                } else if(combo == cboVariableTo) {
                    if(combo.SelectedItem == cboItems.cboVarItems[CboVariableItem.NOTUSE])
                        cboVariableValueTo.Enabled = false;
                    else
                        cboVariableValueTo.Enabled = true;
                }
            }
        }

        private void setEditMode(bool isEditMode) {
            this.isEditMode = isEditMode;
            if(isEditMode) {
                btnAdd.Text = "수정";
                btnRemove.Text = "매크로삭제";
            } else {
                btnAdd.Text = "추가";
                btnRemove.Text = "입력초기화";
            }
        }

        private void updateMacroList() {
            listViewMacroList.Items.Clear();
            macros.Clear();

            var ds = sqLite.SelectAll(SQLitePCH.TB_MACRO);
            foreach(DataRow row in ds.Tables[0].Rows) {
                try {
                    var title = row[SQLitePCH.MACRO_TITLE].ToString();
                    var px = (int)(long)row[SQLitePCH.MACRO_POINTX];
                    var py = (int)(long)row[SQLitePCH.MACRO_POINTY];
                    var ma = (MacroAction)(int)(long)row[SQLitePCH.MACRO_ACTION];
                    var ki = KeyList.getKeyInfo((int)(long)row[SQLitePCH.MACRO_SHORTCUT]);
                    var sw = getSwitch((int)(long)row[SQLitePCH.MACRO_SWITCH]);
                    var ac = (ActivateCondition)(int)(long)row[SQLitePCH.MACRO_SWCONDITION];
                    var rst = System.Boolean.TryParse(row[SQLitePCH.MACRO_POWER]?.ToString(), out var power);
                    var runPath = row[SQLitePCH.MACRO_PROGRAMPATH].ToString();
                    var runArgs = row[SQLitePCH.MACRO_PROGRAMARGS].ToString();

                    RunInfo? runInf = null;
                    if(runPath != null)
                        runInf = new RunInfo(runPath, runArgs);

                    if(!rst)
                        power = true;
                    var switchTo = getSwitch((int)(long)row[SQLitePCH.MACRO_SWITCHTO]);
                    var valueTo = (ActivateCondition)(int)(long)row[SQLitePCH.MACRO_VALUETO];

                    Macro m = new Macro(title, px, py, ma, ki, sw, ac, power, switchTo, valueTo, runInf, (int)(long)row[SQLitePCH.MACRO_Id]);

                    macros.Add(m);
                } catch(Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }

            int i = 0;
            foreach(Macro m in macros) {
                i++;
                ListViewItem item = new ListViewItem(new string[] {
                    i.ToString(),
                    m.title,
                    m.pointX + ", " + m.pointY,
                    m.action.ToString(),
                    m.keyInfo.name,
                    (m.variable != null)? m.variable.ToString() : "-",
                    (m.variable != null)? m.activateCondition.ToString() : "-",
                    (m.changeAfterVar != null)? m.changeAfterVar.ToString() : "-",
                    (m.changeAfterVar != null)? m.changeValueTo.ToString() : "-",
                    m.runInfo != null? m.runInfo.fullPath : "-",
                    m.runInfo != null? m.runInfo.fileName : "-",
                    m.runInfo != null && m.runInfo.arguments != null? m.runInfo.arguments : "-"
                });
                item.Tag = m;
                item.Checked = m.power;
                listViewMacroList.Items.Add(item);
            }
        }

        private void updateCboVariableList() {
            // 신규추가 선택된 경우 index를 임시로 -2로 설정
            int cboVarSelectedIdx = cboVariable.SelectedIndex;
            int cboVarToSelectedIdx = cboVariableTo.SelectedIndex;
            cboVariable.Items.Clear();
            cboVariableTo.Items.Clear();

            foreach(KeyValuePair<string, CboVariableItem> kv in cboItems.cboVarItems) {
                if(kv.Value.name != CboVariableItem.ADDNEW)
                    cboVariableTo.Items.Add(kv.Value);
                cboVariable.Items.Add(kv.Value);
            }

            foreach(Variable s in vars) {
                cboVariable.Items.Add(s);
                cboVariableTo.Items.Add(s);
            }

            cboVariable.SelectedIndex = cboVarSelectedIdx == -2 ? cboVariable.Items.Count - 1 : cboVarSelectedIdx;
            cboVariableTo.SelectedIndex = cboVarToSelectedIdx;
        }

        private void readVariableListFromDB() {
            vars.Clear();

            // sqLite DB로부터 획득
            var ds = sqLite.SelectAll(SQLitePCH.TB_VAR);
            foreach(DataRow row in ds.Tables[0].Rows) {
                try {
                    vars.Add(new Variable((int)(long)row[SQLitePCH.VAR_Id], row[SQLitePCH.VAR_NAME].ToString(), System.Boolean.Parse(row[SQLitePCH.VAR_VALUE].ToString())));
                } catch(Exception ex) {
                    MessageBox.Show("DB데이터가 잘못되어 변수할당에 실패 했습니다." + "\n\n" + ex.ToString());
                }
            }
        }

        private void updateVariableList() {
            lstVariableList.Items.Clear();

            foreach(Variable s in vars) {
                ListViewItem item = new ListViewItem(new string[] {
                    s.id.ToString(), s.name, s.value.ToString()
                });
                item.Tag = s;
                lstVariableList.Items.Add(item);
            }

            updateCboVariableList();
        }

        //private void setProgramPath(string? fullPath) {
        //    if(fullPath != null) {
        //        var splitStr = fullPath.Split('\\');
        //        if(splitStr.Length > 0) {
        //            var fileName = splitStr[splitStr.Length - 1];
        //            lblFilePath.Text = fileName.ToString();
        //        } else {
        //            lblFilePath.Text = fullPath;
        //        }
        //        lblFilePath.Tag = fullPath;
        //    } else {
        //        lblFilePath.Text = "";
        //        lblFilePath.Tag = null;
        //    }
        //}

        private void setProgramPath(RunInfo? runinfo) {
            if(runinfo != null) {
                lblFilePath.Text = runinfo.fileName;
                lblFilePath.Tag = runinfo;
            } else {
                lblFilePath.Text = "";
                lblFilePath.Tag = null;
            }
        }
        #endregion

        #region ======================================================= Global Hook =======================================================
        private void KeyDownHandler(object sender, KeyEventArgs args) {
            Keys key = args.KeyCode;
            if(!isMacroRunning) {
                if(key == Keys.F10) {
                    var pos = gmHook.GetCursorPosition();
                    txtPointX.Text = pos.x.ToString();
                    txtPointY.Text = pos.y.ToString();
                }
                return;
            }

            Debug.WriteLine("Global Hook : " + key.ToString());

            List<Variable> editedVars = new List<Variable>();
            var isVarValueEdited = false;
            foreach(Macro m in macros) {
                if(!m.power)
                    continue;

                if(m.variable != null) {
                    if(m.activateCondition != ActivateCondition.ANY) {
                        if(m.activateCondition == ActivateCondition.ON && !m.variable.value) { continue; }
                        if(m.activateCondition == ActivateCondition.OFF && m.variable.value) { continue; }
                    }
                }

                if(m.keyInfo.key == key) {
                    var action = m.action;
                    gmHook.ForceSetCursor(m.pointX, m.pointY);
                    Thread.Sleep(100);
                    switch(action) {
                        case MacroAction.CLICK:
                            LLog.info("click event");
                            gmHook.ForceLeftClick();
                            break;

                        case MacroAction.L_DOUBLE_CLICK:
                            gmHook.ForceLeftDoubleClick();
                            break;

                        case MacroAction.RIGHT_CLICK:
                            gmHook.ForceRightClick();
                            break;

                        case MacroAction.R_DOUBLE_CLICK:
                            gmHook.ForceRightDoubleClick();
                            break;

                        case MacroAction.M_CLICK:
                            gmHook.ForceMiddleClick();
                            break;

                        case MacroAction.M_DOUBLE_CLICK:
                            gmHook.ForceMiddleDobuleClick();
                            break;

                        case MacroAction.WHEEL_UP:
                            gmHook.ForceWheelUp(40);
                            break;

                        case MacroAction.WHEEL_DOWN:
                            gmHook.ForceWheelDown(40);
                            break;

                        case MacroAction.RUN_PROGRAM:
                            try {
                                if(m.runInfo != null) {
                                    if(m.runInfo.arguments != null)
                                        Process.Start(m.runInfo.fullPath, m.runInfo.arguments);
                                    else
                                        Process.Start(m.runInfo.fullPath);
                                }
                            } catch(Exception e) {
                                MessageBox.Show("프로그램 시작 실패. 경로가 올바르지 않거나 해당 경로에 프로그램이 존재하지 않습니다. \r\n\r\n" + e.ToString());
                            }
                            break;
                    }

                    if(m.changeAfterVar != null) {
                        foreach(var v in vars) {
                            if(v == m.changeAfterVar) {
                                var edtVar = new Variable(v);
                                editedVars.Add(edtVar);
                                edtVar.value = m.changeValueTo == ActivateCondition.ON ? true : false;
                                if(!isVarValueEdited)
                                    isVarValueEdited = true;
                                break;
                            }
                        }
                    }
                }
            }

            if(isVarValueEdited) {
                foreach(var v in vars) {
                    foreach(var ev in editedVars) {
                        if(v.id == ev.id && v.value != ev.value) {
                            v.value = ev.value;
                            break;
                        }
                    }
                }

                updateVariableList();
            }
        }
        #endregion


    }
}
