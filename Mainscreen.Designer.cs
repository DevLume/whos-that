﻿namespace Whos_that
{
    partial class Mainscreen
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameLogged = new System.Windows.Forms.Label();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.challengeButton = new System.Windows.Forms.Button();
            this.friendsListButton = new System.Windows.Forms.Button();
            this.guessButton = new System.Windows.Forms.Button();
            this.createTestButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.createTestPanel1 = new System.Windows.Forms.Panel();
            this.textBoxTestName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createTestContinue1 = new System.Windows.Forms.Button();
            this.guessPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.guessUsername = new System.Windows.Forms.TextBox();
            this.guessContinue = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.createTestPanel1.SuspendLayout();
            this.guessPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.panel2.Controls.Add(this.sidePanel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.usernameLogged);
            this.panel2.Controls.Add(this.recognizeButton);
            this.panel2.Controls.Add(this.challengeButton);
            this.panel2.Controls.Add(this.friendsListButton);
            this.panel2.Controls.Add(this.guessButton);
            this.panel2.Controls.Add(this.createTestButton);
            this.panel2.Controls.Add(this.statisticsButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 527);
            this.panel2.TabIndex = 1;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.sidePanel.Location = new System.Drawing.Point(11, 68);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(11, 53);
            this.sidePanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Logged in as";
            // 
            // usernameLogged
            // 
            this.usernameLogged.AutoSize = true;
            this.usernameLogged.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLogged.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.usernameLogged.Location = new System.Drawing.Point(22, 34);
            this.usernameLogged.Name = "usernameLogged";
            this.usernameLogged.Size = new System.Drawing.Size(0, 19);
            this.usernameLogged.TabIndex = 7;
            // 
            // recognizeButton
            // 
            this.recognizeButton.FlatAppearance.BorderSize = 0;
            this.recognizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recognizeButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recognizeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.recognizeButton.Location = new System.Drawing.Point(11, 343);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(128, 53);
            this.recognizeButton.TabIndex = 5;
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Click += new System.EventHandler(this.recognizeButton_Click);
            // 
            // challengeButton
            // 
            this.challengeButton.FlatAppearance.BorderSize = 0;
            this.challengeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.challengeButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.challengeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.challengeButton.Location = new System.Drawing.Point(11, 288);
            this.challengeButton.Name = "challengeButton";
            this.challengeButton.Size = new System.Drawing.Size(128, 53);
            this.challengeButton.TabIndex = 4;
            this.challengeButton.Text = "Challenge a friend";
            this.challengeButton.UseVisualStyleBackColor = true;
            this.challengeButton.Click += new System.EventHandler(this.challengeButton_Click);
            // 
            // friendsListButton
            // 
            this.friendsListButton.FlatAppearance.BorderSize = 0;
            this.friendsListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.friendsListButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendsListButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.friendsListButton.Location = new System.Drawing.Point(11, 233);
            this.friendsListButton.Name = "friendsListButton";
            this.friendsListButton.Size = new System.Drawing.Size(128, 53);
            this.friendsListButton.TabIndex = 3;
            this.friendsListButton.Text = "Friends list";
            this.friendsListButton.UseVisualStyleBackColor = true;
            this.friendsListButton.Click += new System.EventHandler(this.friendsListButton_Click);
            // 
            // guessButton
            // 
            this.guessButton.FlatAppearance.BorderSize = 0;
            this.guessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guessButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guessButton.Location = new System.Drawing.Point(11, 68);
            this.guessButton.Name = "guessButton";
            this.guessButton.Size = new System.Drawing.Size(128, 53);
            this.guessButton.TabIndex = 2;
            this.guessButton.Text = "Guess!";
            this.guessButton.UseVisualStyleBackColor = true;
            this.guessButton.Click += new System.EventHandler(this.guessButton_Click);
            // 
            // createTestButton
            // 
            this.createTestButton.FlatAppearance.BorderSize = 0;
            this.createTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTestButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTestButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.createTestButton.Location = new System.Drawing.Point(11, 123);
            this.createTestButton.Name = "createTestButton";
            this.createTestButton.Size = new System.Drawing.Size(128, 53);
            this.createTestButton.TabIndex = 1;
            this.createTestButton.Text = "Create a test";
            this.createTestButton.UseVisualStyleBackColor = true;
            this.createTestButton.Click += new System.EventHandler(this.createTestButton_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.FlatAppearance.BorderSize = 0;
            this.statisticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.statisticsButton.Location = new System.Drawing.Point(11, 178);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(128, 53);
            this.statisticsButton.TabIndex = 0;
            this.statisticsButton.Text = "Statistics";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(150, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 28);
            this.panel1.TabIndex = 2;
            // 
            // createTestPanel1
            // 
            this.createTestPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.createTestPanel1.Controls.Add(this.guessPanel);
            this.createTestPanel1.Controls.Add(this.textBoxTestName);
            this.createTestPanel1.Controls.Add(this.label1);
            this.createTestPanel1.Controls.Add(this.createTestContinue1);
            this.createTestPanel1.Location = new System.Drawing.Point(156, 34);
            this.createTestPanel1.Name = "createTestPanel1";
            this.createTestPanel1.Size = new System.Drawing.Size(774, 481);
            this.createTestPanel1.TabIndex = 3;
            // 
            // textBoxTestName
            // 
            this.textBoxTestName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.textBoxTestName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTestName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTestName.Location = new System.Drawing.Point(264, 186);
            this.textBoxTestName.Name = "textBoxTestName";
            this.textBoxTestName.Size = new System.Drawing.Size(230, 28);
            this.textBoxTestName.TabIndex = 4;
            this.textBoxTestName.TextChanged += new System.EventHandler(this.textBoxTestName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(257, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name your test";
            // 
            // createTestContinue1
            // 
            this.createTestContinue1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTestContinue1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTestContinue1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.createTestContinue1.Location = new System.Drawing.Point(264, 272);
            this.createTestContinue1.Name = "createTestContinue1";
            this.createTestContinue1.Size = new System.Drawing.Size(230, 34);
            this.createTestContinue1.TabIndex = 0;
            this.createTestContinue1.Text = "Continue";
            this.createTestContinue1.UseVisualStyleBackColor = true;
            this.createTestContinue1.Click += new System.EventHandler(this.createTestContinue1_Click);
            // 
            // guessPanel
            // 
            this.guessPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.guessPanel.Controls.Add(this.label4);
            this.guessPanel.Controls.Add(this.guessUsername);
            this.guessPanel.Controls.Add(this.guessContinue);
            this.guessPanel.Controls.Add(this.label3);
            this.guessPanel.Location = new System.Drawing.Point(0, 0);
            this.guessPanel.Name = "guessPanel";
            this.guessPanel.Size = new System.Drawing.Size(774, 481);
            this.guessPanel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(136, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(482, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "Whose test do you wish to take?";
            // 
            // guessUsername
            // 
            this.guessUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(59)))));
            this.guessUsername.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guessUsername.Location = new System.Drawing.Point(235, 189);
            this.guessUsername.Name = "guessUsername";
            this.guessUsername.Size = new System.Drawing.Size(230, 28);
            this.guessUsername.TabIndex = 6;
            this.guessUsername.TextChanged += new System.EventHandler(this.guessUsername_TextChanged);
            // 
            // guessContinue
            // 
            this.guessContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guessContinue.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessContinue.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guessContinue.Location = new System.Drawing.Point(235, 255);
            this.guessContinue.Name = "guessContinue";
            this.guessContinue.Size = new System.Drawing.Size(230, 34);
            this.guessContinue.TabIndex = 5;
            this.guessContinue.Text = "Continue";
            this.guessContinue.UseVisualStyleBackColor = true;
            this.guessContinue.Click += new System.EventHandler(this.guessContinue_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(272, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Enter their username";
            // 
            // Mainscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(198)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(942, 527);
            this.Controls.Add(this.createTestPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Mainscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainscreen";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.createTestPanel1.ResumeLayout(false);
            this.createTestPanel1.PerformLayout();
            this.guessPanel.ResumeLayout(false);
            this.guessPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button friendsListButton;
        private System.Windows.Forms.Button guessButton;
        private System.Windows.Forms.Button createTestButton;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.Button challengeButton;
        private System.Windows.Forms.Label usernameLogged;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel createTestPanel1;
        private System.Windows.Forms.Button createTestContinue1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTestName;
        private System.Windows.Forms.Panel guessPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox guessUsername;
        private System.Windows.Forms.Button guessContinue;
        private System.Windows.Forms.Label label3;
    }
}