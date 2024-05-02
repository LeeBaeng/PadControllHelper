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
            comboBox1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e) {
            if(listener != null)
                listener.onPopupCanceled(this);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            if(textBox1.Text.Trim().Equals("")) {
                MessageBox.Show("변수명이 입력되지 않았습니다만??", "입력실패");
                textBox1.Focus();
            } else {
                if(listener != null)
                    listener.onPopupConfirmed(this, new Variable(-1, textBox1.Text, Boolean.Parse(comboBox1.Text)));
                this.Close();
            }
        }

        private void PopAddVariable_Load(object sender, EventArgs e) {
            if(editVar != null) {
                comboBox1.SelectedIndex = editVar.value ? 0 : 1;
                textBox1.Text = editVar.name;
                this.Text = "Edit Variable";
            } else {
                comboBox1.SelectedIndex = 0;
                textBox1.Text = "";
                this.Text = "Add Variable";
            }
        }
    }
}