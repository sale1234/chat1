
namespace Chat.Klijent
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
            this.gbLogovanje = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSlanjeSvima = new System.Windows.Forms.GroupBox();
            this.btnSaljiSvima = new System.Windows.Forms.Button();
            this.rtbPorukaZaSve = new System.Windows.Forms.RichTextBox();
            this.gbSlanjeOdredjenom = new System.Windows.Forms.GroupBox();
            this.btnSaljiKorisniku = new System.Windows.Forms.Button();
            this.rtbPorukaZaJednog = new System.Windows.Forms.RichTextBox();
            this.cbKorisnici = new System.Windows.Forms.ComboBox();
            this.gbPrijemSvih = new System.Windows.Forms.GroupBox();
            this.btnProcitajPoruku = new System.Windows.Forms.Button();
            this.dgvOstale = new System.Windows.Forms.DataGridView();
            this.dgvZadnje3 = new System.Windows.Forms.DataGridView();
            this.gbPrijemOdredjenih = new System.Windows.Forms.GroupBox();
            this.dgvKorisnikOstale = new System.Windows.Forms.DataGridView();
            this.dgvKorisnikZadnje3 = new System.Windows.Forms.DataGridView();
            this.cbIzabraniKorisnik = new System.Windows.Forms.ComboBox();
            this.btnVidiPoruke = new System.Windows.Forms.Button();
            this.btnProcitajOdKorisnika = new System.Windows.Forms.Button();
            this.gbLogovanje.SuspendLayout();
            this.gbSlanjeSvima.SuspendLayout();
            this.gbSlanjeOdredjenom.SuspendLayout();
            this.gbPrijemSvih.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOstale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZadnje3)).BeginInit();
            this.gbPrijemOdredjenih.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnikOstale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnikZadnje3)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLogovanje
            // 
            this.gbLogovanje.Controls.Add(this.btnLogin);
            this.gbLogovanje.Controls.Add(this.txtPassword);
            this.gbLogovanje.Controls.Add(this.txtUsername);
            this.gbLogovanje.Controls.Add(this.label2);
            this.gbLogovanje.Controls.Add(this.label1);
            this.gbLogovanje.Location = new System.Drawing.Point(53, 39);
            this.gbLogovanje.Name = "gbLogovanje";
            this.gbLogovanje.Size = new System.Drawing.Size(481, 132);
            this.gbLogovanje.TabIndex = 0;
            this.gbLogovanje.TabStop = false;
            this.gbLogovanje.Text = "Logovanje";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(315, 58);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(108, 39);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(120, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(159, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 37);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(159, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // gbSlanjeSvima
            // 
            this.gbSlanjeSvima.Controls.Add(this.btnSaljiSvima);
            this.gbSlanjeSvima.Controls.Add(this.rtbPorukaZaSve);
            this.gbSlanjeSvima.Location = new System.Drawing.Point(53, 186);
            this.gbSlanjeSvima.Name = "gbSlanjeSvima";
            this.gbSlanjeSvima.Size = new System.Drawing.Size(481, 154);
            this.gbSlanjeSvima.TabIndex = 6;
            this.gbSlanjeSvima.TabStop = false;
            this.gbSlanjeSvima.Text = "Slanje poruke svima";
            // 
            // btnSaljiSvima
            // 
            this.btnSaljiSvima.Location = new System.Drawing.Point(232, 63);
            this.btnSaljiSvima.Name = "btnSaljiSvima";
            this.btnSaljiSvima.Size = new System.Drawing.Size(95, 30);
            this.btnSaljiSvima.TabIndex = 1;
            this.btnSaljiSvima.Text = "Salji svima";
            this.btnSaljiSvima.UseVisualStyleBackColor = true;
            this.btnSaljiSvima.Click += new System.EventHandler(this.btnSaljiSvima_Click);
            // 
            // rtbPorukaZaSve
            // 
            this.rtbPorukaZaSve.Location = new System.Drawing.Point(6, 31);
            this.rtbPorukaZaSve.MaxLength = 200;
            this.rtbPorukaZaSve.Name = "rtbPorukaZaSve";
            this.rtbPorukaZaSve.Size = new System.Drawing.Size(203, 96);
            this.rtbPorukaZaSve.TabIndex = 0;
            this.rtbPorukaZaSve.Text = "";
            // 
            // gbSlanjeOdredjenom
            // 
            this.gbSlanjeOdredjenom.Controls.Add(this.btnSaljiKorisniku);
            this.gbSlanjeOdredjenom.Controls.Add(this.rtbPorukaZaJednog);
            this.gbSlanjeOdredjenom.Controls.Add(this.cbKorisnici);
            this.gbSlanjeOdredjenom.Location = new System.Drawing.Point(53, 367);
            this.gbSlanjeOdredjenom.Name = "gbSlanjeOdredjenom";
            this.gbSlanjeOdredjenom.Size = new System.Drawing.Size(481, 216);
            this.gbSlanjeOdredjenom.TabIndex = 6;
            this.gbSlanjeOdredjenom.TabStop = false;
            this.gbSlanjeOdredjenom.Text = "Slanje poruke odredjenom";
            // 
            // btnSaljiKorisniku
            // 
            this.btnSaljiKorisniku.Location = new System.Drawing.Point(232, 120);
            this.btnSaljiKorisniku.Name = "btnSaljiKorisniku";
            this.btnSaljiKorisniku.Size = new System.Drawing.Size(120, 28);
            this.btnSaljiKorisniku.TabIndex = 3;
            this.btnSaljiKorisniku.Text = "Salji korisniku";
            this.btnSaljiKorisniku.UseVisualStyleBackColor = true;
            this.btnSaljiKorisniku.Click += new System.EventHandler(this.btnSaljiKorisniku_Click);
            // 
            // rtbPorukaZaJednog
            // 
            this.rtbPorukaZaJednog.Location = new System.Drawing.Point(6, 89);
            this.rtbPorukaZaJednog.MaxLength = 200;
            this.rtbPorukaZaJednog.Name = "rtbPorukaZaJednog";
            this.rtbPorukaZaJednog.Size = new System.Drawing.Size(203, 96);
            this.rtbPorukaZaJednog.TabIndex = 2;
            this.rtbPorukaZaJednog.Text = "";
            // 
            // cbKorisnici
            // 
            this.cbKorisnici.FormattingEnabled = true;
            this.cbKorisnici.Location = new System.Drawing.Point(6, 31);
            this.cbKorisnici.Name = "cbKorisnici";
            this.cbKorisnici.Size = new System.Drawing.Size(175, 24);
            this.cbKorisnici.TabIndex = 0;
            // 
            // gbPrijemSvih
            // 
            this.gbPrijemSvih.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbPrijemSvih.Controls.Add(this.btnProcitajPoruku);
            this.gbPrijemSvih.Controls.Add(this.dgvOstale);
            this.gbPrijemSvih.Controls.Add(this.dgvZadnje3);
            this.gbPrijemSvih.Location = new System.Drawing.Point(609, 39);
            this.gbPrijemSvih.Name = "gbPrijemSvih";
            this.gbPrijemSvih.Size = new System.Drawing.Size(686, 425);
            this.gbPrijemSvih.TabIndex = 6;
            this.gbPrijemSvih.TabStop = false;
            this.gbPrijemSvih.Text = "Sve poruke";
            // 
            // btnProcitajPoruku
            // 
            this.btnProcitajPoruku.Location = new System.Drawing.Point(29, 359);
            this.btnProcitajPoruku.Name = "btnProcitajPoruku";
            this.btnProcitajPoruku.Size = new System.Drawing.Size(171, 37);
            this.btnProcitajPoruku.TabIndex = 2;
            this.btnProcitajPoruku.Text = "Procitaj poruku";
            this.btnProcitajPoruku.UseVisualStyleBackColor = true;
            this.btnProcitajPoruku.Click += new System.EventHandler(this.btnProcitajPoruku_Click);
            // 
            // dgvOstale
            // 
            this.dgvOstale.AllowUserToAddRows = false;
            this.dgvOstale.AllowUserToDeleteRows = false;
            this.dgvOstale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOstale.Location = new System.Drawing.Point(6, 196);
            this.dgvOstale.Name = "dgvOstale";
            this.dgvOstale.ReadOnly = true;
            this.dgvOstale.RowHeadersWidth = 51;
            this.dgvOstale.RowTemplate.Height = 24;
            this.dgvOstale.Size = new System.Drawing.Size(647, 142);
            this.dgvOstale.TabIndex = 1;
            // 
            // dgvZadnje3
            // 
            this.dgvZadnje3.AllowUserToAddRows = false;
            this.dgvZadnje3.AllowUserToDeleteRows = false;
            this.dgvZadnje3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZadnje3.Location = new System.Drawing.Point(6, 31);
            this.dgvZadnje3.Name = "dgvZadnje3";
            this.dgvZadnje3.ReadOnly = true;
            this.dgvZadnje3.RowHeadersWidth = 51;
            this.dgvZadnje3.RowTemplate.Height = 24;
            this.dgvZadnje3.Size = new System.Drawing.Size(647, 142);
            this.dgvZadnje3.TabIndex = 0;
            // 
            // gbPrijemOdredjenih
            // 
            this.gbPrijemOdredjenih.Controls.Add(this.btnProcitajOdKorisnika);
            this.gbPrijemOdredjenih.Controls.Add(this.btnVidiPoruke);
            this.gbPrijemOdredjenih.Controls.Add(this.dgvKorisnikOstale);
            this.gbPrijemOdredjenih.Controls.Add(this.dgvKorisnikZadnje3);
            this.gbPrijemOdredjenih.Controls.Add(this.cbIzabraniKorisnik);
            this.gbPrijemOdredjenih.Location = new System.Drawing.Point(615, 568);
            this.gbPrijemOdredjenih.Name = "gbPrijemOdredjenih";
            this.gbPrijemOdredjenih.Size = new System.Drawing.Size(680, 464);
            this.gbPrijemOdredjenih.TabIndex = 7;
            this.gbPrijemOdredjenih.TabStop = false;
            this.gbPrijemOdredjenih.Text = "Poruke od odredjenog";
            // 
            // dgvKorisnikOstale
            // 
            this.dgvKorisnikOstale.AllowUserToAddRows = false;
            this.dgvKorisnikOstale.AllowUserToDeleteRows = false;
            this.dgvKorisnikOstale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnikOstale.Location = new System.Drawing.Point(6, 260);
            this.dgvKorisnikOstale.Name = "dgvKorisnikOstale";
            this.dgvKorisnikOstale.ReadOnly = true;
            this.dgvKorisnikOstale.RowHeadersWidth = 51;
            this.dgvKorisnikOstale.RowTemplate.Height = 24;
            this.dgvKorisnikOstale.Size = new System.Drawing.Size(647, 142);
            this.dgvKorisnikOstale.TabIndex = 2;
            // 
            // dgvKorisnikZadnje3
            // 
            this.dgvKorisnikZadnje3.AllowUserToAddRows = false;
            this.dgvKorisnikZadnje3.AllowUserToDeleteRows = false;
            this.dgvKorisnikZadnje3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnikZadnje3.Location = new System.Drawing.Point(6, 83);
            this.dgvKorisnikZadnje3.Name = "dgvKorisnikZadnje3";
            this.dgvKorisnikZadnje3.ReadOnly = true;
            this.dgvKorisnikZadnje3.RowHeadersWidth = 51;
            this.dgvKorisnikZadnje3.RowTemplate.Height = 24;
            this.dgvKorisnikZadnje3.Size = new System.Drawing.Size(647, 142);
            this.dgvKorisnikZadnje3.TabIndex = 1;
            // 
            // cbIzabraniKorisnik
            // 
            this.cbIzabraniKorisnik.FormattingEnabled = true;
            this.cbIzabraniKorisnik.Location = new System.Drawing.Point(6, 37);
            this.cbIzabraniKorisnik.Name = "cbIzabraniKorisnik";
            this.cbIzabraniKorisnik.Size = new System.Drawing.Size(213, 24);
            this.cbIzabraniKorisnik.TabIndex = 0;
            // 
            // btnVidiPoruke
            // 
            this.btnVidiPoruke.Location = new System.Drawing.Point(248, 28);
            this.btnVidiPoruke.Name = "btnVidiPoruke";
            this.btnVidiPoruke.Size = new System.Drawing.Size(123, 40);
            this.btnVidiPoruke.TabIndex = 3;
            this.btnVidiPoruke.Text = "Vidi poruke";
            this.btnVidiPoruke.UseVisualStyleBackColor = true;
            this.btnVidiPoruke.Click += new System.EventHandler(this.btnVidiPoruke_Click);
            // 
            // btnProcitajOdKorisnika
            // 
            this.btnProcitajOdKorisnika.Location = new System.Drawing.Point(396, 28);
            this.btnProcitajOdKorisnika.Name = "btnProcitajOdKorisnika";
            this.btnProcitajOdKorisnika.Size = new System.Drawing.Size(123, 40);
            this.btnProcitajOdKorisnika.TabIndex = 4;
            this.btnProcitajOdKorisnika.Text = "Procitaj poruku";
            this.btnProcitajOdKorisnika.UseVisualStyleBackColor = true;
            this.btnProcitajOdKorisnika.Click += new System.EventHandler(this.btnProcitajOdKorisnika_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 1055);
            this.Controls.Add(this.gbPrijemOdredjenih);
            this.Controls.Add(this.gbPrijemSvih);
            this.Controls.Add(this.gbSlanjeOdredjenom);
            this.Controls.Add(this.gbSlanjeSvima);
            this.Controls.Add(this.gbLogovanje);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbLogovanje.ResumeLayout(false);
            this.gbLogovanje.PerformLayout();
            this.gbSlanjeSvima.ResumeLayout(false);
            this.gbSlanjeOdredjenom.ResumeLayout(false);
            this.gbPrijemSvih.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOstale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZadnje3)).EndInit();
            this.gbPrijemOdredjenih.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnikOstale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnikZadnje3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogovanje;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSlanjeSvima;
        private System.Windows.Forms.GroupBox gbSlanjeOdredjenom;
        private System.Windows.Forms.GroupBox gbPrijemSvih;
        private System.Windows.Forms.GroupBox gbPrijemOdredjenih;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSaljiSvima;
        private System.Windows.Forms.RichTextBox rtbPorukaZaSve;
        private System.Windows.Forms.Button btnSaljiKorisniku;
        private System.Windows.Forms.RichTextBox rtbPorukaZaJednog;
        private System.Windows.Forms.ComboBox cbKorisnici;
        private System.Windows.Forms.DataGridView dgvZadnje3;
        private System.Windows.Forms.DataGridView dgvOstale;
        private System.Windows.Forms.DataGridView dgvKorisnikOstale;
        private System.Windows.Forms.DataGridView dgvKorisnikZadnje3;
        private System.Windows.Forms.ComboBox cbIzabraniKorisnik;
        private System.Windows.Forms.Button btnProcitajPoruku;
        private System.Windows.Forms.Button btnVidiPoruke;
        private System.Windows.Forms.Button btnProcitajOdKorisnika;
    }
}

