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
            this.sign_in_button = new System.Windows.Forms.Button();
            this.signup_login = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.register_label = new System.Windows.Forms.LinkLabel();
            this.forgot_account_label = new System.Windows.Forms.LinkLabel();
            this.facebook_login_label = new System.Windows.Forms.LinkLabel();
            this.register_panel = new System.Windows.Forms.Panel();
            this.go_back_link = new System.Windows.Forms.LinkLabel();
            this.register_button = new System.Windows.Forms.Button();
            this.gender_combobox = new System.Windows.Forms.ComboBox();
            this.email_register = new Whos_that.PlaceholderTextBox();
            this.password_register = new Whos_that.PlaceholderTextBox();
            this.username_register = new Whos_that.PlaceholderTextBox();
            this.password_login = new Whos_that.PlaceholderTextBox();
            this.username_login = new Whos_that.PlaceholderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.register_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sign_in_button
            // 
            this.sign_in_button.Location = new System.Drawing.Point(127, 326);
            this.sign_in_button.Name = "sign_in_button";
            this.sign_in_button.Size = new System.Drawing.Size(75, 23);
            this.sign_in_button.TabIndex = 0;
            this.sign_in_button.Text = "Sign In";
            this.sign_in_button.UseVisualStyleBackColor = true;
            this.sign_in_button.Click += new System.EventHandler(this.signinButton_Click);
            // 
            // signup_login
            // 
            this.signup_login.Location = new System.Drawing.Point(127, 365);
            this.signup_login.Name = "signup_login";
            this.signup_login.Size = new System.Drawing.Size(75, 23);
            this.signup_login.TabIndex = 1;
            this.signup_login.Text = "Sign Up";
            this.signup_login.UseVisualStyleBackColor = true;
            this.signup_login.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(113, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 94);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // register_label
            // 
            this.register_label.AutoSize = true;
            this.register_label.Location = new System.Drawing.Point(84, 441);
            this.register_label.Name = "register_label";
            this.register_label.Size = new System.Drawing.Size(46, 13);
            this.register_label.TabIndex = 7;
            this.register_label.TabStop = true;
            this.register_label.Text = "Register";
            this.register_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.register_LinkClicked);
            // 
            // forgot_account_label
            // 
            this.forgot_account_label.AutoSize = true;
            this.forgot_account_label.Location = new System.Drawing.Point(84, 410);
            this.forgot_account_label.Name = "forgot_account_label";
            this.forgot_account_label.Size = new System.Drawing.Size(86, 13);
            this.forgot_account_label.TabIndex = 8;
            this.forgot_account_label.TabStop = true;
            this.forgot_account_label.Text = "Forgot Account?";
            this.forgot_account_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.restore_LinkClicked);
            // 
            // facebook_login_label
            // 
            this.facebook_login_label.AutoSize = true;
            this.facebook_login_label.Location = new System.Drawing.Point(84, 471);
            this.facebook_login_label.Name = "facebook_login_label";
            this.facebook_login_label.Size = new System.Drawing.Size(110, 13);
            this.facebook_login_label.TabIndex = 9;
            this.facebook_login_label.TabStop = true;
            this.facebook_login_label.Text = "Log In with Facebook";
            this.facebook_login_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.facebook_LinkClicked);
            // 
            // register_panel
            // 
            this.register_panel.Controls.Add(this.go_back_link);
            this.register_panel.Controls.Add(this.register_button);
            this.register_panel.Controls.Add(this.gender_combobox);
            this.register_panel.Controls.Add(this.email_register);
            this.register_panel.Controls.Add(this.password_register);
            this.register_panel.Controls.Add(this.username_register);
            this.register_panel.Location = new System.Drawing.Point(28, 15);
            this.register_panel.Name = "register_panel";
            this.register_panel.Size = new System.Drawing.Size(277, 484);
            this.register_panel.TabIndex = 10;
            this.register_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // go_back_link
            // 
            this.go_back_link.AutoSize = true;
            this.go_back_link.Location = new System.Drawing.Point(86, 415);
            this.go_back_link.Name = "go_back_link";
            this.go_back_link.Size = new System.Drawing.Size(126, 13);
            this.go_back_link.TabIndex = 5;
            this.go_back_link.TabStop = true;
            this.go_back_link.Text = "Go back to Login Screen";
            this.go_back_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.goBack_LinkClicked);
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(86, 343);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(75, 23);
            this.register_button.TabIndex = 4;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // gender_combobox
            // 
            this.gender_combobox.FormattingEnabled = true;
            this.gender_combobox.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.gender_combobox.Location = new System.Drawing.Point(60, 257);
            this.gender_combobox.Name = "gender_combobox";
            this.gender_combobox.Size = new System.Drawing.Size(67, 21);
            this.gender_combobox.TabIndex = 3;
            this.gender_combobox.SelectedIndexChanged += new System.EventHandler(this.registerGenderCombobox_SelectedIndexChanged);
            // 
            // email_register
            // 
            this.email_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.email_register.ForeColor = System.Drawing.Color.Gray;
            this.email_register.Location = new System.Drawing.Point(60, 210);
            this.email_register.Name = "email_register";
            this.email_register.PlaceholderText = null;
            this.email_register.Size = new System.Drawing.Size(139, 20);
            this.email_register.TabIndex = 2;
            this.email_register.Text = "E-mail";
            this.email_register.TextChanged += new System.EventHandler(this.registerEmail_TextChanged);
            // 
            // password_register
            // 
            this.password_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.password_register.ForeColor = System.Drawing.Color.Gray;
            this.password_register.Location = new System.Drawing.Point(60, 171);
            this.password_register.Name = "password_register";
            this.password_register.PlaceholderText = null;
            this.password_register.Size = new System.Drawing.Size(139, 20);
            this.password_register.TabIndex = 1;
            this.password_register.Text = "Password";
            this.password_register.UseSystemPasswordChar = true;
            this.password_register.TextChanged += new System.EventHandler(this.registerPassword_TextChanged);
            // 
            // username_register
            // 
            this.username_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.username_register.ForeColor = System.Drawing.Color.Gray;
            this.username_register.Location = new System.Drawing.Point(60, 128);
            this.username_register.Name = "username_register";
            this.username_register.PlaceholderText = null;
            this.username_register.Size = new System.Drawing.Size(139, 20);
            this.username_register.TabIndex = 0;
            this.username_register.Text = "Username";
            this.username_register.TextChanged += new System.EventHandler(this.registerUsername_TextChanged);
            // 
            // password_login
            // 
            this.password_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.password_login.ForeColor = System.Drawing.Color.Gray;
            this.password_login.Location = new System.Drawing.Point(87, 270);
            this.password_login.Name = "password_login";
            this.password_login.PlaceholderText = null;
            this.password_login.Size = new System.Drawing.Size(161, 20);
            this.password_login.TabIndex = 6;
            this.password_login.Text = "Password";
            this.password_login.TextChanged += new System.EventHandler(this.loginPassword_TextChanged);
            // 
            // username_login
            // 
            this.username_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.username_login.ForeColor = System.Drawing.Color.Gray;
            this.username_login.Location = new System.Drawing.Point(87, 222);
            this.username_login.Name = "username_login";
            this.username_login.PlaceholderText = null;
            this.username_login.Size = new System.Drawing.Size(161, 20);
            this.username_login.TabIndex = 5;
            this.username_login.Text = "Username";
            this.username_login.TextChanged += new System.EventHandler(this.loginUsername_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 511);
            this.Controls.Add(this.register_panel);
            this.Controls.Add(this.facebook_login_label);
            this.Controls.Add(this.forgot_account_label);
            this.Controls.Add(this.register_label);
            this.Controls.Add(this.password_login);
            this.Controls.Add(this.username_login);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.signup_login);
            this.Controls.Add(this.sign_in_button);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.register_panel.ResumeLayout(false);
            this.register_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sign_in_button;
        private System.Windows.Forms.Button signup_login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private PlaceholderTextBox username_login;
        private PlaceholderTextBox password_login;
        private System.Windows.Forms.LinkLabel register_label;
        private System.Windows.Forms.LinkLabel forgot_account_label;
        private System.Windows.Forms.LinkLabel facebook_login_label;

        private System.Windows.Forms.Panel register_panel;
        private System.Windows.Forms.LinkLabel go_back_link;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.ComboBox gender_combobox;
        private PlaceholderTextBox email_register;
        private PlaceholderTextBox password_register;
        private PlaceholderTextBox username_register;
    }
}

