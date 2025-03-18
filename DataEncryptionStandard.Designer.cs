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
            BtnKey = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BtnDecrypt
            // 
            BtnDecrypt.Location = new Point(228, 210);
            BtnDecrypt.Name = "BtnDecrypt";
            BtnDecrypt.Size = new Size(75, 23);
            BtnDecrypt.TabIndex = 6;
            BtnDecrypt.Text = "Decrypt";
            BtnDecrypt.UseVisualStyleBackColor = true;
            BtnDecrypt.Click += BtnDecrypt_Click;
            // 
            // TxtPlain
            // 
            TxtPlain.Location = new Point(12, 103);
            TxtPlain.Name = "TxtPlain";
            TxtPlain.Size = new Size(372, 23);
            TxtPlain.TabIndex = 3;
            // 
            // TxtEncrypted
            // 
            TxtEncrypted.Location = new Point(12, 152);
            TxtEncrypted.Name = "TxtEncrypted";
            TxtEncrypted.Size = new Size(372, 23);
            TxtEncrypted.TabIndex = 5;
            // 
            // BtnEncrypt
            // 
            BtnEncrypt.Location = new Point(309, 210);
            BtnEncrypt.Name = "BtnEncrypt";
            BtnEncrypt.Size = new Size(75, 23);
            BtnEncrypt.TabIndex = 4;
            BtnEncrypt.Text = "Encrypt";
            BtnEncrypt.UseVisualStyleBackColor = true;
            BtnEncrypt.Click += BtnEncrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 82);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Plain Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 134);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Encrypted";
            // 
            // TxtKey
            // 
            TxtKey.Location = new Point(12, 33);
            TxtKey.MaxLength = 8;
            TxtKey.Name = "TxtKey";
            TxtKey.Size = new Size(287, 23);
            TxtKey.TabIndex = 1;
            // 
            // BtnKey
            // 
            BtnKey.Location = new Point(309, 33);
            BtnKey.Name = "BtnKey";
            BtnKey.Size = new Size(75, 23);
            BtnKey.TabIndex = 2;
            BtnKey.Text = "Confirm";
            BtnKey.UseVisualStyleBackColor = true;
            BtnKey.Click += BtnKey_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonShadow;
            pictureBox1.Location = new Point(12, 69);
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
            // DataEncryptionStandard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 245);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(BtnKey);
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
        private Button BtnKey;
        private PictureBox pictureBox1;
        private Label label3;
    }
}
