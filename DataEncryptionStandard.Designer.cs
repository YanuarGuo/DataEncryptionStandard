namespace DataEncryptionStandard
{
    partial class DataEncryptionStandard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnDecrypt = new Button();
            TxtPlain = new TextBox();
            TxtEncrypted = new TextBox();
            BtnEncrypt = new Button();
            label1 = new Label();
            label2 = new Label();
            TxtKey = new TextBox();
            label3 = new Label();
            label4 = new Label();
            TxtIVEnc = new TextBox();
            label5 = new Label();
            CbPadding = new ComboBox();
            BtnConfirmAll = new Button();
            label7 = new Label();
            TxtIVDec = new TextBox();
            label10 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            BtnClearEnc = new Button();
            label6 = new Label();
            CbOutputFormat = new ComboBox();
            groupBox3 = new GroupBox();
            BtnClearDec = new Button();
            label8 = new Label();
            CbInputFormat = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // BtnDecrypt
            // 
            BtnDecrypt.Location = new Point(170, 249);
            BtnDecrypt.Name = "BtnDecrypt";
            BtnDecrypt.Size = new Size(75, 23);
            BtnDecrypt.TabIndex = 11;
            BtnDecrypt.Text = "Decrypt";
            BtnDecrypt.UseVisualStyleBackColor = true;
            BtnDecrypt.Click += BtnDecrypt_Click;
            // 
            // TxtPlain
            // 
            TxtPlain.Location = new Point(13, 57);
            TxtPlain.Multiline = true;
            TxtPlain.Name = "TxtPlain";
            TxtPlain.Size = new Size(229, 104);
            TxtPlain.TabIndex = 4;
            // 
            // TxtEncrypted
            // 
            TxtEncrypted.Location = new Point(16, 57);
            TxtEncrypted.Multiline = true;
            TxtEncrypted.Name = "TxtEncrypted";
            TxtEncrypted.Size = new Size(229, 104);
            TxtEncrypted.TabIndex = 8;
            // 
            // BtnEncrypt
            // 
            BtnEncrypt.Location = new Point(15, 250);
            BtnEncrypt.Name = "BtnEncrypt";
            BtnEncrypt.Size = new Size(75, 23);
            BtnEncrypt.TabIndex = 7;
            BtnEncrypt.Text = "Encrypt";
            BtnEncrypt.UseVisualStyleBackColor = true;
            BtnEncrypt.Click += BtnEncrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 36);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Plain Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 39);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "Cipher Text";
            // 
            // TxtKey
            // 
            TxtKey.Location = new Point(13, 42);
            TxtKey.MaxLength = 8;
            TxtKey.Name = "TxtKey";
            TxtKey.Size = new Size(503, 23);
            TxtKey.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 24);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 9;
            label3.Text = "Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 185);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 12;
            label4.Text = "Initialization Vector";
            // 
            // TxtIVEnc
            // 
            TxtIVEnc.Location = new Point(13, 203);
            TxtIVEnc.MaxLength = 8;
            TxtIVEnc.Name = "TxtIVEnc";
            TxtIVEnc.Size = new Size(229, 23);
            TxtIVEnc.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 77);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 13;
            label5.Text = "Padding";
            // 
            // CbPadding
            // 
            CbPadding.DropDownStyle = ComboBoxStyle.DropDownList;
            CbPadding.FormattingEnabled = true;
            CbPadding.Items.AddRange(new object[] { "PKCS7", "ZeroPadding" });
            CbPadding.Location = new Point(13, 95);
            CbPadding.Name = "CbPadding";
            CbPadding.Size = new Size(503, 23);
            CbPadding.TabIndex = 2;
            // 
            // BtnConfirmAll
            // 
            BtnConfirmAll.Location = new Point(441, 136);
            BtnConfirmAll.Name = "BtnConfirmAll";
            BtnConfirmAll.Size = new Size(75, 23);
            BtnConfirmAll.TabIndex = 3;
            BtnConfirmAll.Text = "Confirm";
            BtnConfirmAll.UseVisualStyleBackColor = true;
            BtnConfirmAll.Click += BtnConfirmAll_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(141, 185);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 20;
            label7.Text = "Initialization Vector";
            // 
            // TxtIVDec
            // 
            TxtIVDec.Location = new Point(16, 203);
            TxtIVDec.MaxLength = 8;
            TxtIVDec.Name = "TxtIVDec";
            TxtIVDec.Size = new Size(229, 23);
            TxtIVDec.TabIndex = 9;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(429, 9);
            label10.Name = "label10";
            label10.Size = new Size(0, 15);
            label10.TabIndex = 23;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtKey);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(CbPadding);
            groupBox1.Controls.Add(BtnConfirmAll);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(532, 179);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Key and Padding";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnClearEnc);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(CbOutputFormat);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(TxtPlain);
            groupBox2.Controls.Add(BtnEncrypt);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(TxtIVEnc);
            groupBox2.Location = new Point(12, 210);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(256, 315);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Encryption";
            // 
            // BtnClearEnc
            // 
            BtnClearEnc.Location = new Point(15, 279);
            BtnClearEnc.Name = "BtnClearEnc";
            BtnClearEnc.Size = new Size(75, 23);
            BtnClearEnc.TabIndex = 16;
            BtnClearEnc.Text = "Clear";
            BtnClearEnc.UseVisualStyleBackColor = true;
            BtnClearEnc.Click += BtnClearEnc_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(156, 232);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 15;
            label6.Text = "Output Format";
            // 
            // CbOutputFormat
            // 
            CbOutputFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            CbOutputFormat.FormattingEnabled = true;
            CbOutputFormat.Items.AddRange(new object[] { "Base64", "HEX" });
            CbOutputFormat.Location = new Point(96, 251);
            CbOutputFormat.Name = "CbOutputFormat";
            CbOutputFormat.Size = new Size(146, 23);
            CbOutputFormat.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BtnClearDec);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(CbInputFormat);
            groupBox3.Controls.Add(TxtEncrypted);
            groupBox3.Controls.Add(BtnDecrypt);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(TxtIVDec);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(283, 210);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(261, 315);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Decryption";
            // 
            // BtnClearDec
            // 
            BtnClearDec.Location = new Point(170, 278);
            BtnClearDec.Name = "BtnClearDec";
            BtnClearDec.Size = new Size(75, 23);
            BtnClearDec.TabIndex = 17;
            BtnClearDec.Text = "Clear";
            BtnClearDec.UseVisualStyleBackColor = true;
            BtnClearDec.Click += BtnClearDec_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 232);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 16;
            label8.Text = "Input Format";
            // 
            // CbInputFormat
            // 
            CbInputFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            CbInputFormat.FormattingEnabled = true;
            CbInputFormat.Items.AddRange(new object[] { "Base64", "HEX" });
            CbInputFormat.Location = new Point(16, 250);
            CbInputFormat.Name = "CbInputFormat";
            CbInputFormat.Size = new Size(146, 23);
            CbInputFormat.TabIndex = 10;
            // 
            // DataEncryptionStandard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 537);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label10);
            Name = "DataEncryptionStandard";
            Text = "DataEncryptionStandard";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnDecrypt;
        private TextBox TxtPlain;
        private TextBox TxtEncrypted;
        private Button BtnEncrypt;
        private Label label1;
        private Label label2;
        private TextBox TxtKey;
        private Label label3;
        private Label label4;
        private TextBox TxtIVEnc;
        private Label label5;
        private ComboBox CbPadding;
        private Button BtnConfirmAll;
        private Label label7;
        private TextBox TxtIVDec;
        private Label label10;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label6;
        private ComboBox CbOutputFormat;
        private Label label8;
        private ComboBox CbInputFormat;
        private Button BtnClearEnc;
        private Button BtnClearDec;
    }
}
