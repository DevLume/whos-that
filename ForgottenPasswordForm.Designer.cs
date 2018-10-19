namespace Whos_that
{
    partial class ForgottenPasswordForm
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
            this.components = new System.ComponentModel.Container();
            this.forgottenPasword = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.forgottenPasswordPanel = new System.Windows.Forms.Panel();
            this.forgottenPaswordSubmt = new System.Windows.Forms.Button();
            this.BackToLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // forgottenPasword
            // 
            this.forgottenPasword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.forgottenPasword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.forgottenPasword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgottenPasword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.forgottenPasword.Location = new System.Drawing.Point(50, 41);
            this.forgottenPasword.Name = "forgottenPasword";
            this.forgottenPasword.Size = new System.Drawing.Size(199, 21);
            this.forgottenPasword.TabIndex = 0;
            this.forgottenPasword.Text = "Enter your email";
            this.forgottenPasword.TextChanged += new System.EventHandler(this.forgottenPasword_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // forgottenPasswordPanel
            // 
            this.forgottenPasswordPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.forgottenPasswordPanel.Location = new System.Drawing.Point(50, 68);
            this.forgottenPasswordPanel.Name = "forgottenPasswordPanel";
            this.forgottenPasswordPanel.Size = new System.Drawing.Size(200, 1);
            this.forgottenPasswordPanel.TabIndex = 1;
            // 
            // forgottenPaswordSubmt
            // 
            this.forgottenPaswordSubmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forgottenPaswordSubmt.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.forgottenPaswordSubmt.Location = new System.Drawing.Point(50, 126);
            this.forgottenPaswordSubmt.Name = "forgottenPaswordSubmt";
            this.forgottenPaswordSubmt.Size = new System.Drawing.Size(200, 34);
            this.forgottenPaswordSubmt.TabIndex = 2;
            this.forgottenPaswordSubmt.Text = "Submit";
            this.forgottenPaswordSubmt.UseVisualStyleBackColor = true;
            this.forgottenPaswordSubmt.Click += new System.EventHandler(this.forgottenPaswordSubmt_Click);
            // 
            // BackToLoginButton
            // 
            this.BackToLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BackToLoginButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.BackToLoginButton.FlatAppearance.BorderSize = 0;
            this.BackToLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackToLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToLoginButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BackToLoginButton.Location = new System.Drawing.Point(263, 1);
            this.BackToLoginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackToLoginButton.Name = "BackToLoginButton";
            this.BackToLoginButton.Size = new System.Drawing.Size(20, 33);
            this.BackToLoginButton.TabIndex = 23;
            this.BackToLoginButton.Text = "x";
            this.BackToLoginButton.UseVisualStyleBackColor = false;
            this.BackToLoginButton.Click += new System.EventHandler(this.BackToLoginButton_Click);
            // 
            // ForgottenPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(295, 218);
            this.Controls.Add(this.BackToLoginButton);
            this.Controls.Add(this.forgottenPaswordSubmt);
            this.Controls.Add(this.forgottenPasswordPanel);
            this.Controls.Add(this.forgottenPasword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ForgottenPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "u";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox forgottenPasword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel forgottenPasswordPanel;
        private System.Windows.Forms.Button forgottenPaswordSubmt;
        private System.Windows.Forms.Button BackToLoginButton;
    }
}