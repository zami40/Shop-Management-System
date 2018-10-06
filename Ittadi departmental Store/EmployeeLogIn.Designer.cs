namespace Ittadi_departmental_Store
{
    partial class EmployeeLogIn
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
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.btnresister = new System.Windows.Forms.Button();
            this.btn_passwordseen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnlogin.Location = new System.Drawing.Point(211, 168);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(91, 38);
            this.btnlogin.TabIndex = 0;
            this.btnlogin.Text = "Log In";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(163, 58);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(139, 20);
            this.txtusername.TabIndex = 1;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(163, 105);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(139, 20);
            this.txtpassword.TabIndex = 2;
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.Location = new System.Drawing.Point(69, 58);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(82, 18);
            this.lblusername.TabIndex = 3;
            this.lblusername.Text = "Username : ";
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblpassword.Location = new System.Drawing.Point(69, 105);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(74, 18);
            this.lblpassword.TabIndex = 4;
            this.lblpassword.Text = "Password :";
            // 
            // btnresister
            // 
            this.btnresister.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnresister.Location = new System.Drawing.Point(72, 168);
            this.btnresister.Name = "btnresister";
            this.btnresister.Size = new System.Drawing.Size(91, 38);
            this.btnresister.TabIndex = 5;
            this.btnresister.Text = "Resister";
            this.btnresister.UseVisualStyleBackColor = true;
            this.btnresister.Click += new System.EventHandler(this.btnresister_Click);
            // 
            // btn_passwordseen
            // 
            this.btn_passwordseen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_passwordseen.Location = new System.Drawing.Point(278, 107);
            this.btn_passwordseen.Name = "btn_passwordseen";
            this.btn_passwordseen.Size = new System.Drawing.Size(22, 16);
            this.btn_passwordseen.TabIndex = 6;
            this.btn_passwordseen.Text = ">";
            this.btn_passwordseen.UseVisualStyleBackColor = true;
            this.btn_passwordseen.Click += new System.EventHandler(this.btn_passwordseen_Click);
            // 
            // EmployeeLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(426, 275);
            this.Controls.Add(this.btn_passwordseen);
            this.Controls.Add(this.btnresister);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.btnlogin);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "EmployeeLogIn";
            this.Text = "EmployeeLogIn";
            this.Load += new System.EventHandler(this.EmployeeLogIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Button btnresister;
        private System.Windows.Forms.Button btn_passwordseen;
    }
}