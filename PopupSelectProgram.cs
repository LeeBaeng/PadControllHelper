using PadControlHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PadControllHelper {
    public partial class PopupSelectProgram : Popup {
        public PopupSelectProgram(IPopupListener listener) : base(listener) {
            InitializeComponent();
        }

        private void btnOpenBrowser_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog();

            if(dr == DialogResult.OK) {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            if(txtFilePath.Text.Trim().Equals("")) {
                MessageBox.Show("파일경로가 입력되지 않았습니다만??", "입력실패");
                txtFilePath.Focus();
            } else {
                if(listener != null)
                    listener.onPopupConfirmed(this, txtFilePath.Text);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            listener.onPopupCanceled(this);
            this.Close();
        }

        private void PopupSelectProgram_Load(object sender, EventArgs e) {
            txtFilePath.Text = "";
        }
    }
}
