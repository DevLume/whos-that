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
            this.loginPanel = new System.Windows.Forms.Panel();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.emailText = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.BackToLoginButton = new System.Windows.Forms.Button();
            this.registerRegisterButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.registerPassword = new System.Windows.Forms.TextBox();
            this.registerUsername = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.forgotPasswordLabel = new System.Windows.Forms.LinkLabel();
            this.registerButton = new System.Windows.Forms.Button();
            this.signInButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.facebookPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginPanel.SuspendLayout();
            this.registerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.loginPanel.Controls.Add(this.registerPanel);
            this.loginPanel.Controls.Add(this.forgotPasswordLabel);
            this.loginPanel.Controls.Add(this.registerButton);
            this.loginPanel.Controls.Add(this.signInButton);
            this.loginPanel.Controls.Add(this.panel2);
            this.loginPanel.Controls.Add(this.panel1);
            this.loginPanel.Controls.Add(this.passwordText);
            this.loginPanel.Controls.Add(this.usernameText);
            this.loginPanel.Controls.Add(this.pictureBox4);
            this.loginPanel.Controls.Add(this.pictureBox3);
            this.loginPanel.Controls.Add(this.facebookPicture);
            this.loginPanel.Controls.Add(this.pictureBox1);
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(300, 447);
            this.loginPanel.TabIndex = 0;
            // 
            // registerPanel
            // 
            this.registerPanel.Controls.Add(this.panel6);
            this.registerPanel.Controls.Add(this.emailText);
            this.registerPanel.Controls.Add(this.pictureBox6);
            this.registerPanel.Controls.Add(this.BackToLoginButton);
            this.registerPanel.Controls.Add(this.registerRegisterButton);
            this.registerPanel.Controls.Add(this.panel4);
            this.registerPanel.Controls.Add(this.panel5);
            this.registerPanel.Controls.Add(this.registerPassword);
            this.registerPanel.Controls.Add(this.registerUsername);
            this.registerPanel.Controls.Add(this.pictureBox2);
            this.registerPanel.Controls.Add(this.pictureBox5);
            this.registerPanel.Controls.Add(this.pictureBox7);
            this.registerPanel.Location = new System.Drawing.Point(0, 0);
            this.registerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(300, 445);
            this.registerPanel.TabIndex = 12;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Location = new System.Drawing.Point(30, 236);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(240, 1);
            this.panel6.TabIndex = 25;
            // 
            // emailText
            // 
            this.emailText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.emailText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.emailText.Location = new System.Drawing.Point(49, 221);
            this.emailText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(188, 16);
            this.emailText.TabIndex = 24;
            this.emailText.Text = "Email";
            this.emailText.Click += new System.EventHandler(this.emailText_TextChanged);
            this.emailText.TextChanged += new System.EventHandler(this.emailText_TextChanged_1);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(26, 215);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 29);
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
            // 
            // BackToLoginButton
            // 
            this.BackToLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BackToLoginButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.BackToLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToLoginButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BackToLoginButton.Location = new System.Drawing.Point(26, 317);
            this.BackToLoginButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BackToLoginButton.Name = "BackToLoginButton";
            this.BackToLoginButton.Size = new System.Drawing.Size(244, 33);
            this.BackToLoginButton.TabIndex = 22;
            this.BackToLoginButton.Text = "Back";
            this.BackToLoginButton.UseVisualStyleBackColor = false;
            this.BackToLoginButton.Click += new System.EventHandler(this.backToLogin_Click);
            // 
            // registerRegisterButton
            // 
            this.registerRegisterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.registerRegisterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerRegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerRegisterButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.registerRegisterButton.Location = new System.Drawing.Point(26, 268);
            this.registerRegisterButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerRegisterButton.Name = "registerRegisterButton";
            this.registerRegisterButton.Size = new System.Drawing.Size(244, 33);
            this.registerRegisterButton.TabIndex = 21;
            this.registerRegisterButton.Text = "Register";
            this.registerRegisterButton.UseVisualStyleBackColor = false;
            this.registerRegisterButton.Click += new System.EventHandler(this.registerRegisterButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Location = new System.Drawing.Point(30, 177);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 1);
            this.panel4.TabIndex = 20;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Location = new System.Drawing.Point(30, 124);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 1);
            this.panel5.TabIndex = 19;
            // 
            // registerPassword
            // 
            this.registerPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.registerPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.registerPassword.Location = new System.Drawing.Point(49, 162);
            this.registerPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerPassword.Name = "registerPassword";
            this.registerPassword.Size = new System.Drawing.Size(188, 16);
            this.registerPassword.TabIndex = 18;
            this.registerPassword.Text = "Password";
            this.registerPassword.Click += new System.EventHandler(this.registerPassword_TextChanged);
            this.registerPassword.TextChanged += new System.EventHandler(this.registerPassword_TextChanged_1);
            // 
            // registerUsername
            // 
            this.registerUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.registerUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.registerUsername.Location = new System.Drawing.Point(49, 109);
            this.registerUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerUsername.Name = "registerUsername";
            this.registerUsername.Size = new System.Drawing.Size(188, 16);
            this.registerUsername.TabIndex = 17;
            this.registerUsername.Text = "Username";
            this.registerUsername.Click += new System.EventHandler(this.registerUsername_TextChanged);
            this.registerUsername.TextChanged += new System.EventHandler(this.registerUsername_TextChanged_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(26, 156);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 32);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(26, 102);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 31);
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(125, 10);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(68, 81);
            this.pictureBox7.TabIndex = 13;
            this.pictureBox7.TabStop = false;
            // 
            // forgotPasswordLabel
            // 
            this.forgotPasswordLabel.AutoSize = true;
            this.forgotPasswordLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.forgotPasswordLabel.Location = new System.Drawing.Point(86, 317);
            this.forgotPasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forgotPasswordLabel.Name = "forgotPasswordLabel";
            this.forgotPasswordLabel.Size = new System.Drawing.Size(114, 13);
            this.forgotPasswordLabel.TabIndex = 14;
            this.forgotPasswordLabel.TabStop = true;
            this.forgotPasswordLabel.Text = "Forgot your password?";
            this.forgotPasswordLabel.VisitedLinkColor = System.Drawing.Color.WhiteSmoke;
            this.forgotPasswordLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgotPasswordLabel_LinkClicked);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.registerButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.registerButton.Location = new System.Drawing.Point(26, 268);
            this.registerButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(244, 33);
            this.registerButton.TabIndex = 11;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.signInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.signInButton.Location = new System.Drawing.Point(26, 211);
            this.signInButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(244, 33);
            this.signInButton.TabIndex = 10;
            this.signInButton.Text = "Sign in";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(30, 177);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 1);
            this.panel2.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(30, 124);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 1);
            this.panel1.TabIndex = 8;
            // 
            // passwordText
            // 
            this.passwordText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.passwordText.Location = new System.Drawing.Point(49, 162);
            this.passwordText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(188, 16);
            this.passwordText.TabIndex = 7;
            this.passwordText.Text = "Password";
            this.passwordText.Click += new System.EventHandler(this.passwordText_Click);
            this.passwordText.TextChanged += new System.EventHandler(this.passwordText_TextChanged);
            // 
            // usernameText
            // 
            this.usernameText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.usernameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.usernameText.Location = new System.Drawing.Point(49, 109);
            this.usernameText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(188, 16);
            this.usernameText.TabIndex = 6;
            this.usernameText.Text = "Username";
            this.usernameText.Click += new System.EventHandler(this.usernameText_Click);
            this.usernameText.TextChanged += new System.EventHandler(this.usernameText_TextChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(26, 156);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 32);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(26, 102);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 31);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // facebookPicture
            // 
            this.facebookPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facebookPicture.Image = ((System.Drawing.Image)(resources.GetObject("facebookPicture.Image")));
            this.facebookPicture.Location = new System.Drawing.Point(118, 361);
            this.facebookPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.facebookPicture.Name = "facebookPicture";
            this.facebookPicture.Size = new System.Drawing.Size(76, 75);
            this.facebookPicture.TabIndex = 2;
            this.facebookPicture.TabStop = false;
            this.facebookPicture.Click += new System.EventHandler(this.facebookPicture_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(125, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 81);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 447);
            this.Controls.Add(this.loginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.PictureBox facebookPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Panel registerPanel;
        private System.Windows.Forms.Button BackToLoginButton;
        private System.Windows.Forms.Button registerRegisterButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox registerPassword;
        private System.Windows.Forms.TextBox registerUsername;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.LinkLabel forgotPasswordLabel;
    }
}
