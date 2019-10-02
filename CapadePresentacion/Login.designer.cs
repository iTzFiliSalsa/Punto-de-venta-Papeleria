namespace CapadePresentacion
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btncerrar = new System.Windows.Forms.PictureBox();
            this.btnminimizar = new System.Windows.Forms.PictureBox();
            this.btErrorUsuario = new System.Windows.Forms.Label();
            this.btErrorContraseña = new System.Windows.Forms.Label();
            this.btErrorLogin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtuser
            // 
            this.txtuser.BackColor = System.Drawing.Color.White;
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.Location = new System.Drawing.Point(106, 241);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(172, 15);
            this.txtuser.TabIndex = 1;
            this.txtuser.Text = "Usuario";
            this.txtuser.TextChanged += new System.EventHandler(this.txtuser_TextChanged);
            this.txtuser.Enter += new System.EventHandler(this.txtuser_Enter);
            this.txtuser.Leave += new System.EventHandler(this.txtuser_Leave);
            // 
            // txtpass
            // 
            this.txtpass.BackColor = System.Drawing.Color.White;
            this.txtpass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpass.Location = new System.Drawing.Point(106, 317);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(119, 15);
            this.txtpass.TabIndex = 2;
            this.txtpass.Text = "Contraseña";
            this.txtpass.TextChanged += new System.EventHandler(this.txtpass_TextChanged);
            this.txtpass.Enter += new System.EventHandler(this.txtpass_Enter);
            this.txtpass.Leave += new System.EventHandler(this.txtpass_Leave);
            // 
            // btnlogin
            // 
            this.btnlogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnlogin.BackgroundImage")));
            this.btnlogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnlogin.Location = new System.Drawing.Point(76, 387);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(236, 23);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.Location = new System.Drawing.Point(317, 2);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(46, 34);
            this.btncerrar.TabIndex = 3;
            this.btncerrar.TabStop = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnminimizar
            // 
            this.btnminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnminimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnminimizar.Image")));
            this.btnminimizar.Location = new System.Drawing.Point(266, 2);
            this.btnminimizar.Name = "btnminimizar";
            this.btnminimizar.Size = new System.Drawing.Size(45, 34);
            this.btnminimizar.TabIndex = 4;
            this.btnminimizar.TabStop = false;
            this.btnminimizar.Click += new System.EventHandler(this.btnminimizar_Click);
            // 
            // btErrorUsuario
            // 
            this.btErrorUsuario.AutoSize = true;
            this.btErrorUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btErrorUsuario.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btErrorUsuario.Location = new System.Drawing.Point(106, 263);
            this.btErrorUsuario.Name = "btErrorUsuario";
            this.btErrorUsuario.Size = new System.Drawing.Size(43, 13);
            this.btErrorUsuario.TabIndex = 5;
            this.btErrorUsuario.Text = "Usuario";
            this.btErrorUsuario.Visible = false;
            this.btErrorUsuario.Click += new System.EventHandler(this.btErrorUsuario_Click);
            // 
            // btErrorContraseña
            // 
            this.btErrorContraseña.AutoSize = true;
            this.btErrorContraseña.BackColor = System.Drawing.Color.Transparent;
            this.btErrorContraseña.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btErrorContraseña.Location = new System.Drawing.Point(106, 340);
            this.btErrorContraseña.Name = "btErrorContraseña";
            this.btErrorContraseña.Size = new System.Drawing.Size(61, 13);
            this.btErrorContraseña.TabIndex = 6;
            this.btErrorContraseña.Text = "Contraseña";
            this.btErrorContraseña.Visible = false;
            this.btErrorContraseña.Click += new System.EventHandler(this.btErrorContraseña_Click);
            // 
            // btErrorLogin
            // 
            this.btErrorLogin.AutoSize = true;
            this.btErrorLogin.BackColor = System.Drawing.Color.Transparent;
            this.btErrorLogin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btErrorLogin.Location = new System.Drawing.Point(73, 419);
            this.btErrorLogin.Name = "btErrorLogin";
            this.btErrorLogin.Size = new System.Drawing.Size(33, 13);
            this.btErrorLogin.TabIndex = 7;
            this.btErrorLogin.Text = "Login";
            this.btErrorLogin.Visible = false;
            this.btErrorLogin.Click += new System.EventHandler(this.btErrorLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(376, 508);
            this.Controls.Add(this.btErrorLogin);
            this.Controls.Add(this.btErrorContraseña);
            this.Controls.Add(this.btErrorUsuario);
            this.Controls.Add(this.btnminimizar);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuser);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnminimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.PictureBox btncerrar;
        private System.Windows.Forms.PictureBox btnminimizar;
        private System.Windows.Forms.Label btErrorUsuario;
        private System.Windows.Forms.Label btErrorContraseña;
        private System.Windows.Forms.Label btErrorLogin;
    }
}

