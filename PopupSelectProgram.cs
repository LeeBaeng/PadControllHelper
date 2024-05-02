using PadControlHelper;

namespace PadControllHelper {
    public partial class PopupSelectProgram : Popup {

        public RunInfo? edtRuninfo { get; set; } = null;

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
            } else if(!txtFilePath.Text.Contains("\\") || !new FileInfo(txtFilePath.Text).Exists) {
                MessageBox.Show("파일경로가 정상적이지 않는것 같습니다만?", "입력실패");
                txtFilePath.Focus();
            } else {
                if(listener != null) {
                    listener.onPopupConfirmed(this, new RunInfo(txtFilePath.Text, txtRunArguments.Text));
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            listener.onPopupCanceled(this);
            this.Close();
        }

        private void PopupSelectProgram_Load(object sender, EventArgs e) {
            if(edtRuninfo != null) {
                txtFilePath.Text = edtRuninfo.fullPath;
                txtRunArguments.Text = edtRuninfo.arguments;
            } else {
                txtFilePath.Text = "";
                txtRunArguments.Text = "";
            }
                
        }
    }
}
