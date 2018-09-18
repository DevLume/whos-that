namespace Whos_that
{
    partial class RegisterForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.placeholderTextBox3 = new Whos_that.PlaceholderTextBox();
            this.placeholderTextBox2 = new Whos_that.PlaceholderTextBox();
            this.placeholderTextBox1 = new Whos_that.PlaceholderTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.comboBox1.Location = new System.Drawing.Point(85, 286);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // placeholderTextBox3
            // 
            this.placeholderTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeholderTextBox3.ForeColor = System.Drawing.Color.Gray;
            this.placeholderTextBox3.Location = new System.Drawing.Point(85, 250);
            this.placeholderTextBox3.Name = "placeholderTextBox3";
            this.placeholderTextBox3.PlaceholderText = null;
            this.placeholderTextBox3.Size = new System.Drawing.Size(140, 20);
            this.placeholderTextBox3.TabIndex = 2;
            this.placeholderTextBox3.Text = "E-mail";
            this.placeholderTextBox3.TextChanged += new System.EventHandler(this.placeholderTextBox3_TextChanged);
            // 
            // placeholderTextBox2
            // 
            this.placeholderTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeholderTextBox2.ForeColor = System.Drawing.Color.Gray;
            this.placeholderTextBox2.Location = new System.Drawing.Point(85, 200);
            this.placeholderTextBox2.Name = "placeholderTextBox2";
            this.placeholderTextBox2.PlaceholderText = null;
            this.placeholderTextBox2.Size = new System.Drawing.Size(140, 20);
            this.placeholderTextBox2.TabIndex = 1;
            this.placeholderTextBox2.Text = "Password";
            this.placeholderTextBox2.TextChanged += new System.EventHandler(this.placeholderTextBox2_TextChanged);
            // 
            // placeholderTextBox1
            // 
            this.placeholderTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.placeholderTextBox1.ForeColor = System.Drawing.Color.Gray;
            this.placeholderTextBox1.Location = new System.Drawing.Point(85, 150);
            this.placeholderTextBox1.Name = "placeholderTextBox1";
            this.placeholderTextBox1.PlaceholderText = null;
            this.placeholderTextBox1.Size = new System.Drawing.Size(140, 20);
            this.placeholderTextBox1.TabIndex = 0;
            this.placeholderTextBox1.Text = "Username";
            this.placeholderTextBox1.TextChanged += new System.EventHandler(this.placeholderTextBox1_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(82, 411);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(110, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Back to Login Screen";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 511);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.placeholderTextBox3);
            this.Controls.Add(this.placeholderTextBox2);
            this.Controls.Add(this.placeholderTextBox1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PlaceholderTextBox placeholderTextBox1;
        private PlaceholderTextBox placeholderTextBox2;
        private PlaceholderTextBox placeholderTextBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}