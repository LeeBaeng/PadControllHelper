namespace PadControllHelper {
    partial class PopupSelectProgram {
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
            txtFilePath = new TextBox();
            label1 = new Label();
            btnOpenBrowser = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            openFileDialog1 = new OpenFileDialog();
            txtRunArguments = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(169, 15);
            txtFilePath.MaxLength = 500;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(502, 23);
            txtFilePath.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(151, 15);
            label1.TabIndex = 1;
            label1.Text = "실행할 프로그램 경로 입력";
            // 
            // btnOpenBrowser
            // 
            btnOpenBrowser.Location = new Point(677, 15);
            btnOpenBrowser.Name = "btnOpenBrowser";
            btnOpenBrowser.Size = new Size(75, 23);
            btnOpenBrowser.TabIndex = 2;
            btnOpenBrowser.Text = "찾아보기";
            btnOpenBrowser.UseVisualStyleBackColor = true;
            btnOpenBrowser.Click += btnOpenBrowser_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(310, 70);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "확인";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(391, 70);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "취소";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "파일 찾기";
            openFileDialog1.Filter = "실행 파일(*.exe) |*.exe|모든 파일(*.*)|*.*";
            // 
            // txtRunArguments
            // 
            txtRunArguments.Location = new Point(169, 41);
            txtRunArguments.MaxLength = 500;
            txtRunArguments.Name = "txtRunArguments";
            txtRunArguments.Size = new Size(502, 23);
            txtRunArguments.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 45);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 6;
            label2.Text = "실행 Arguments";
            // 
            // PopupSelectProgram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 104);
            Controls.Add(label2);
            Controls.Add(txtRunArguments);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnOpenBrowser);
            Controls.Add(label1);
            Controls.Add(txtFilePath);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PopupSelectProgram";
            Text = "PopupSelectProgram";
            Load += PopupSelectProgram_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFilePath;
        private Label label1;
        private Button btnOpenBrowser;
        private Button btnOK;
        private Button btnCancel;
        private OpenFileDialog openFileDialog1;
        private TextBox txtRunArguments;
        private Label label2;
    }
}