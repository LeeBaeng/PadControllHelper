using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PadControlHelper {
    public partial class PopAddVariable : Popup {

        public Variable editVar { get; set; } = null;
        public PopAddVariable(IPopupListener listener) : base(listener) {
            InitializeComponent();
            cboValue.SelectedIndex = 1;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            if(listener != null)
                listener.onPopupCanceled(this);
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if(txtVarName.Text.Trim().Equals("")) {
                MessageBox.Show("변수명이 입력되지 않았습니다만??", "입력실패");
                txtVarName.Focus();
            } else {
                if(listener != null)
                    listener.onPopupConfirmed(this, new Variable(editVar != null? editVar.id : -1, txtVarName.Text, Boolean.Parse(cboValue.Text)));
                this.Close();
            }
        }

        private void PopAddVariable_Load(object sender, EventArgs e) {
            if(editVar != null) {
                cboValue.SelectedIndex = editVar.value ? 0 : 1;
                txtVarName.Text = editVar.name;
                this.Text = "Edit Variable";
            } else {
                cboValue.SelectedIndex = 0;
                txtVarName.Text = "";
                this.Text = "Add Variable";
            }
        }
    }
}