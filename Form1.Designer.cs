namespace techniki_steganografi_lab2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.readHiddenMsgButton = new System.Windows.Forms.Button();
            this.saveModifiedFileButton = new System.Windows.Forms.Button();
            this.msgTextBox = new System.Windows.Forms.TextBox();
            this.msgLabel = new System.Windows.Forms.Label();
            this.encryptionPasswordLbel = new System.Windows.Forms.Label();
            this.steganograficKeyLabel = new System.Windows.Forms.Label();
            this.encryptionPasswordTextBox = new System.Windows.Forms.TextBox();
            this.steganographicKeyTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(673, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 480);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(13, 500);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.loadFileButton.Size = new System.Drawing.Size(110, 37);
            this.loadFileButton.TabIndex = 2;
            this.loadFileButton.Text = "Wczytaj plik";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(129, 500);
            this.insertButton.Name = "insertButton";
            this.insertButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.insertButton.Size = new System.Drawing.Size(110, 37);
            this.insertButton.TabIndex = 3;
            this.insertButton.Text = "Wstaw";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // readHiddenMsgButton
            // 
            this.readHiddenMsgButton.Location = new System.Drawing.Point(245, 500);
            this.readHiddenMsgButton.Name = "readHiddenMsgButton";
            this.readHiddenMsgButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.readHiddenMsgButton.Size = new System.Drawing.Size(110, 37);
            this.readHiddenMsgButton.TabIndex = 4;
            this.readHiddenMsgButton.Text = "Odczytaj ukrytą informację";
            this.readHiddenMsgButton.UseVisualStyleBackColor = true;
            this.readHiddenMsgButton.Click += new System.EventHandler(this.readHiddenMsgButton_Click);
            // 
            // saveModifiedFileButton
            // 
            this.saveModifiedFileButton.Location = new System.Drawing.Point(361, 499);
            this.saveModifiedFileButton.Name = "saveModifiedFileButton";
            this.saveModifiedFileButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveModifiedFileButton.Size = new System.Drawing.Size(110, 37);
            this.saveModifiedFileButton.TabIndex = 5;
            this.saveModifiedFileButton.Text = "Zapisz zmodyfikowany plik";
            this.saveModifiedFileButton.UseVisualStyleBackColor = true;
            this.saveModifiedFileButton.Click += new System.EventHandler(this.saveModifiedFileButton_Click);
            // 
            // msgTextBox
            // 
            this.msgTextBox.Location = new System.Drawing.Point(135, 542);
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.Size = new System.Drawing.Size(226, 20);
            this.msgTextBox.TabIndex = 6;
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Location = new System.Drawing.Point(13, 542);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(103, 13);
            this.msgLabel.TabIndex = 7;
            this.msgLabel.Text = "Tekst do osadzenia:";
            // 
            // encryptionPasswordLbel
            // 
            this.encryptionPasswordLbel.AutoSize = true;
            this.encryptionPasswordLbel.Location = new System.Drawing.Point(16, 569);
            this.encryptionPasswordLbel.Name = "encryptionPasswordLbel";
            this.encryptionPasswordLbel.Size = new System.Drawing.Size(97, 13);
            this.encryptionPasswordLbel.TabIndex = 8;
            this.encryptionPasswordLbel.Text = "Hasło szyfrowania:";
            // 
            // steganograficKeyLabel
            // 
            this.steganograficKeyLabel.AutoSize = true;
            this.steganograficKeyLabel.Location = new System.Drawing.Point(16, 595);
            this.steganograficKeyLabel.Name = "steganograficKeyLabel";
            this.steganograficKeyLabel.Size = new System.Drawing.Size(119, 13);
            this.steganograficKeyLabel.TabIndex = 9;
            this.steganograficKeyLabel.Text = "Klucz steganograficzny:";
            // 
            // encryptionPasswordTextBox
            // 
            this.encryptionPasswordTextBox.Location = new System.Drawing.Point(135, 569);
            this.encryptionPasswordTextBox.Name = "encryptionPasswordTextBox";
            this.encryptionPasswordTextBox.Size = new System.Drawing.Size(226, 20);
            this.encryptionPasswordTextBox.TabIndex = 10;
            // 
            // steganographicKeyTextBox
            // 
            this.steganographicKeyTextBox.Location = new System.Drawing.Point(135, 595);
            this.steganographicKeyTextBox.Name = "steganographicKeyTextBox";
            this.steganographicKeyTextBox.Size = new System.Drawing.Size(226, 20);
            this.steganographicKeyTextBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 628);
            this.Controls.Add(this.steganographicKeyTextBox);
            this.Controls.Add(this.encryptionPasswordTextBox);
            this.Controls.Add(this.steganograficKeyLabel);
            this.Controls.Add(this.encryptionPasswordLbel);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.msgTextBox);
            this.Controls.Add(this.saveModifiedFileButton);
            this.Controls.Add(this.readHiddenMsgButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button readHiddenMsgButton;
        private System.Windows.Forms.Button saveModifiedFileButton;
        private System.Windows.Forms.TextBox msgTextBox;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Label encryptionPasswordLbel;
        private System.Windows.Forms.Label steganograficKeyLabel;
        private System.Windows.Forms.TextBox encryptionPasswordTextBox;
        private System.Windows.Forms.TextBox steganographicKeyTextBox;
    }
}

