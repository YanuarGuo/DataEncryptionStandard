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
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            TxtIV = new TextBox();
            label5 = new Label();
            CbPadding = new ComboBox();
            BtnConfirmAll = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BtnDecrypt
            // 
            BtnDecrypt.Location = new Point(228, 343);
            BtnDecrypt.Name = "BtnDecrypt";
            BtnDecrypt.Size = new Size(75, 23);
            BtnDecrypt.TabIndex = 8;
            BtnDecrypt.Text = "Decrypt";
            BtnDecrypt.UseVisualStyleBackColor = true;
            BtnDecrypt.Click += BtnDecrypt_Click;
            // 
            // TxtPlain
            // 
            TxtPlain.Location = new Point(12, 252);
            TxtPlain.Name = "TxtPlain";
            TxtPlain.Size = new Size(372, 23);
            TxtPlain.TabIndex = 5;
            // 
            // TxtEncrypted
            // 
            TxtEncrypted.Location = new Point(12, 301);
            TxtEncrypted.Name = "TxtEncrypted";
            TxtEncrypted.Size = new Size(372, 23);
            TxtEncrypted.TabIndex = 7;
            // 
            // BtnEncrypt
            // 
            BtnEncrypt.Location = new Point(309, 343);
            BtnEncrypt.Name = "BtnEncrypt";
            BtnEncrypt.Size = new Size(75, 23);
            BtnEncrypt.TabIndex = 6;
            BtnEncrypt.Text = "Encrypt";
            BtnEncrypt.UseVisualStyleBackColor = true;
            BtnEncrypt.Click += BtnEncrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 231);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Plain Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 283);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "Cipher Text";
            // 
            // TxtKey
            // 
            TxtKey.Location = new Point(12, 33);
            TxtKey.MaxLength = 8;
            TxtKey.Name = "TxtKey";
            TxtKey.Size = new Size(370, 23);
            TxtKey.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonShadow;
            pictureBox1.Location = new Point(9, 207);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(373, 3);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 9;
            label3.Text = "Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 64);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 12;
            label4.Text = "Initialization Vector";
            // 
            // TxtIV
            // 
            TxtIV.Location = new Point(12, 82);
            TxtIV.MaxLength = 8;
            TxtIV.Name = "TxtIV";
            TxtIV.Size = new Size(370, 23);
            TxtIV.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 114);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 13;
            label5.Text = "Padding";
            // 
            // CbPadding
            // 
            CbPadding.FormattingEnabled = true;
            CbPadding.Items.AddRange(new object[] { "PKCS7", "Zero" });
            CbPadding.Location = new Point(12, 132);
            CbPadding.Name = "CbPadding";
            CbPadding.Size = new Size(370, 23);
            CbPadding.TabIndex = 14;
            // 
            // BtnConfirmAll
            // 
            BtnConfirmAll.Location = new Point(309, 168);
            BtnConfirmAll.Name = "BtnConfirmAll";
            BtnConfirmAll.Size = new Size(75, 23);
            BtnConfirmAll.TabIndex = 15;
            BtnConfirmAll.Text = "Confirm";
            BtnConfirmAll.UseVisualStyleBackColor = true;
            BtnConfirmAll.Click += BtnConfirmAll_Click;
            // 
            // DataEncryptionStandard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 383);
            Controls.Add(BtnConfirmAll);
            Controls.Add(CbPadding);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TxtIV);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(TxtKey);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtEncrypted);
            Controls.Add(BtnEncrypt);
            Controls.Add(TxtPlain);
            Controls.Add(BtnDecrypt);
            Name = "DataEncryptionStandard";
            Text = "DataEncryptionStandard";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private TextBox TxtIV;
        private Label label5;
        private ComboBox CbPadding;
        private Button BtnConfirmAll;
    }
}
