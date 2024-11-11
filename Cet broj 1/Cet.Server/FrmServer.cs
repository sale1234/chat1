using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cet.Server
{
    public partial class FrmServer : Form
    {
        private Server server;
        private BindingList<Poruka> poruke = new BindingList<Poruka>(Konroler.Instanca.VratiPoruke());
        public FrmServer()
        {
            InitializeComponent();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            server = new Server();
            dgvPoruke.DataSource = null;
            try
            {
                server.Start();
                Thread nit = new Thread(server.ObradiKlijente);
                nit.Start();
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
                MessageBox.Show("Server je pokrenut");
                /*System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
                timer.Start();*/
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            dgvPoruke.DataSource = null;
            dgvPoruke.DataSource = poruke;
            ((DataGridViewTextBoxColumn)dgvPoruke.Columns["Tekst"]).MaxInputLength = 20;
            dgvPoruke.Columns["Uspesno"].Visible = false;
            dgvPoruke.Columns["Operacija"].Visible = false;
            
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            try
            {
                server?.Close();
                server = null;
                btnPokreni.Enabled = true;
                btnZaustavi.Enabled = false;
                MessageBox.Show("Server je zaustavljen");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
            }
            //dgvPoruke.DataSource = null;
            dgvPoruke.DataSource = poruke;
            ((DataGridViewTextBoxColumn)dgvPoruke.Columns["Tekst"]).MaxInputLength = 20;
            dgvPoruke.Columns["Uspesno"].Visible = false;
            dgvPoruke.Columns["Operacija"].Visible = false;
        }

        private void btnCItajPoruku_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                if(dgvPoruke.SelectedRows.Count > 0)
                {
                    Poruka poruka = (Poruka)dgvPoruke.SelectedRows[0].DataBoundItem;
                    if (poruka.Tekst.Length <= 20) MessageBox.Show("Poruka ima do 20 karaktera");
                    else MessageBox.Show(poruka.Tekst);
                }

            }));
        }

        private void dgvPoruke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Poruka poruka = (Poruka)dgvPoruke.SelectedRows[0].DataBoundItem;
        }
    }
}
