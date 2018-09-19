namespace Whos_that
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernamePicture = new System.Windows.Forms.PictureBox();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.usernamePanel = new System.Windows.Forms.Panel();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordPicture = new System.Windows.Forms.PictureBox();
            this.SignInButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.paparazzi = new System.Windows.Forms.PictureBox();
            this.facebookPicture = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usernamePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paparazzi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // usernamePicture
            // 
            this.usernamePicture.Image = ((System.Drawing.Image)(resources.GetObject("usernamePicture.Image")));
            this.usernamePicture.Location = new System.Drawing.Point(40, 116);
            this.usernamePicture.Name = "usernamePicture";
            this.usernamePicture.Size = new System.Drawing.Size(29, 28);
            this.usernamePicture.TabIndex = 1;
            this.usernamePicture.TabStop = false;
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.usernameTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.usernameTextbox.HideSelection = false;
            this.usernameTextbox.Location = new System.Drawing.Point(75, 127);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(164, 20);
            this.usernameTextbox.TabIndex = 3;
            this.usernameTextbox.Text = "Username";
            this.usernameTextbox.Click += new System.EventHandler(this.clickUsername);
            // 
            // usernamePanel
            // 
            this.usernamePanel.BackColor = System.Drawing.Color.White;
            this.usernamePanel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.usernamePanel.Location = new System.Drawing.Point(41, 146);
            this.usernamePanel.Name = "usernamePanel";
            this.usernamePanel.Size = new System.Drawing.Size(320, 1);
            this.usernamePanel.TabIndex = 4;
            // 
            // passwordPanel
            // 
            this.passwordPanel.BackColor = System.Drawing.Color.White;
            this.passwordPanel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.passwordPanel.Location = new System.Drawing.Point(41, 222);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(320, 1);
            this.passwordPanel.TabIndex = 7;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.passwordTextBox.HideSelection = false;
            this.passwordTextBox.Location = new System.Drawing.Point(71, 199);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(164, 20);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Click += new System.EventHandler(this.clickPassword);
            // 
            // passwordPicture
            // 
            this.passwordPicture.Image = ((System.Drawing.Image)(resources.GetObject("passwordPicture.Image")));
            this.passwordPicture.Location = new System.Drawing.Point(42, 194);
            this.passwordPicture.Name = "passwordPicture";
            this.passwordPicture.Size = new System.Drawing.Size(25, 27);
            this.passwordPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordPicture.TabIndex = 5;
            this.passwordPicture.TabStop = false;
            // 
            // SignInButton
            // 
            this.SignInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(186)))));
            this.SignInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.SignInButton.Location = new System.Drawing.Point(41, 259);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(320, 35);
            this.SignInButton.TabIndex = 8;
            this.SignInButton.Text = "Sign in";
            this.SignInButton.UseVisualStyleBackColor = false;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.registerButton.Location = new System.Drawing.Point(41, 309);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(320, 35);
            this.registerButton.TabIndex = 10;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.loginLabel.Location = new System.Drawing.Point(155, 377);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(95, 24);
            this.loginLabel.TabIndex = 11;
            this.loginLabel.Text = "Login with";
            // 
            // paparazzi
            // 
            this.paparazzi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paparazzi.Image = ((System.Drawing.Image)(resources.GetObject("paparazzi.Image")));
            this.paparazzi.Location = new System.Drawing.Point(169, 25);
            this.paparazzi.Name = "paparazzi";
            this.paparazzi.Size = new System.Drawing.Size(65, 77);
            this.paparazzi.TabIndex = 12;
            this.paparazzi.TabStop = false;
            // 
            // facebookPicture
            // 
            this.facebookPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facebookPicture.Image = ((System.Drawing.Image)(resources.GetObject("facebookPicture.Image")));
            this.facebookPicture.Location = new System.Drawing.Point(159, 412);
            this.facebookPicture.Name = "facebookPicture";
            this.facebookPicture.Size = new System.Drawing.Size(87, 76);
            this.facebookPicture.TabIndex = 15;
            this.facebookPicture.TabStop = false;
            this.facebookPicture.Click += new System.EventHandler(this.facebookPicture_Click_1);
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(186)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closeButton.Location = new System.Drawing.Point(369, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(19, 32);
            this.closeButton.TabIndex = 17;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.facebookPicture);
            this.Controls.Add(this.paparazzi);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.passwordPanel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordPicture);
            this.Controls.Add(this.usernamePanel);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.usernamePicture);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usernamePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paparazzi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox usernamePicture;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Panel usernamePanel;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.PictureBox passwordPicture;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.PictureBox paparazzi;
        private System.Windows.Forms.PictureBox facebookPicture;
        private System.Windows.Forms.Button closeButton;
    }
}

