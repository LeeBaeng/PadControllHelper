﻿namespace PadControlHelper {
    partial class PopAddVariable {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            txtVarName = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            cboValue = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 16);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 0;
            label1.Text = "스위치(변수)명 입력";
            // 
            // textBox1
            // 
            txtVarName.Location = new Point(132, 13);
            txtVarName.MaxLength = 20;
            txtVarName.Name = "txtVarName";
            txtVarName.Size = new Size(152, 23);
            txtVarName.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(394, 13);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "확인";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(475, 13);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // comboBox1
            // 
            cboValue.DropDownStyle = ComboBoxStyle.DropDownList;
            cboValue.FormattingEnabled = true;
            cboValue.Items.AddRange(new object[] { "true", "false" });
            cboValue.Location = new Point(290, 13);
            cboValue.Name = "cboValue";
            cboValue.Size = new Size(98, 23);
            cboValue.TabIndex = 2;
            // 
            // PopAddVariable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 53);
            Controls.Add(cboValue);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtVarName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PopAddVariable";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddVariable";
            Load += PopAddVariable_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtVarName;
        private Button btnOK;
        private Button btnCancel;
        private ComboBox cboValue;
    }
}