using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.Klijent
{
    public partial class Form1 : Form
    {
        private BindingList<Poruka> svePoruke = new BindingList<Poruka>();
        private BindingList<Poruka> pera1 = new BindingList<Poruka>();
        private BindingList<Poruka> pera2 = new BindingList<Poruka>();
        private BindingList<Poruka> pera3 = new BindingList<Poruka>();

        public Form1()
        {
            InitializeComponent();
            gbLogovanje.Visible = true;
            gbSlanjeSvima.Visible = false;
            gbSlanjeOdredjenom.Visible = false;
            gbPrijemSvih.Visible = false;
            gbPrijemOdredjenih.Visible = false;

            try
            {
                Komunikacija.Instanca.Connect();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                Posiljalac = new Korisnik
                {
                    Email = txtUsername.Text,
                    Password = txtPassword.Text
                },
                Operacija = Operacija.Login
            };
            Komunikacija.Instanca.SaljiPoruku(poruka);
            Poruka odgovor = Komunikacija.Instanca.CitajPoruku();
            if(odgovor.Uspesno)
            {
                MessageBox.Show($"Dobrodosli {odgovor.Primalac.Ime} {odgovor.Primalac.Prezime}");
                gbLogovanje.Visible = false;
                gbSlanjeSvima.Visible = true;
                gbSlanjeOdredjenom.Visible = true;
                gbPrijemSvih.Visible = true;
                gbPrijemOdredjenih.Visible = true;
                ObradiZahteve();
            }
            else
            {
                MessageBox.Show(odgovor.Tekst);
            }
        }

       

        private void ObradiZahteve()
        {
            Thread nit = new Thread(SlusajPoruke);
            nit.Start();
        }

        


        private void SlusajPoruke()
        {
            try
            {
                while(true)
                {
                    Poruka odgovor = Komunikacija.Instanca.CitajPoruku();

                    switch (odgovor.Operacija)
                    {
                        case Operacija.Login:
                            Invoke(new Action(() =>
                            {
                                cbKorisnici.DataSource = odgovor.UlogovaniKorisnici;
                                cbIzabraniKorisnik.DataSource = odgovor.UlogovaniKorisnici;
                            }));
                            break;
                        case Operacija.SaljiSvima:
                            Invoke(new Action(() =>
                            {
                                if(svePoruke.Count < 3)
                                {
                                    svePoruke.Add(odgovor);
                                    dgvZadnje3.DataSource = svePoruke;
                                    dgvZadnje3.Columns["Uspesno"].Visible = false;
                                    dgvZadnje3.Columns["Operacija"].Visible = false;
                                    dgvZadnje3.Columns["Vreme"].Visible = false;
                                    ((DataGridViewTextBoxColumn)dgvZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                                }
                                else
                                {
                                    svePoruke.Add(odgovor);
                                    dgvOstale.DataSource = svePoruke.Take(svePoruke.Count - 3).ToList();
                                    dgvZadnje3.DataSource = svePoruke.Except(svePoruke.Take(svePoruke.Count - 3).ToList()).ToList();
                                    dgvZadnje3.Columns["Uspesno"].Visible = false;
                                    dgvZadnje3.Columns["Operacija"].Visible = false;
                                    dgvZadnje3.Columns["Vreme"].Visible = false;
                                    dgvOstale.Columns["Uspesno"].Visible = false;
                                    dgvOstale.Columns["Operacija"].Visible = false;
                                    dgvOstale.Columns["Vreme"].Visible = false;
                                    ((DataGridViewTextBoxColumn)dgvZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                                    ((DataGridViewTextBoxColumn)dgvOstale.Columns["Tekst"]).MaxInputLength = 20;

                                }
                            }));
                            Invoke(new Action(() =>
                            {
                                if (odgovor.Posiljalac.Ime == "Pera 1") pera1.Add(odgovor);
                                if (odgovor.Posiljalac.Ime == "Pera 2") pera2.Add(odgovor);
                                if (odgovor.Posiljalac.Ime == "Pera 3") pera3.Add(odgovor);
                            }));
                            

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaljiSvima_Click(object sender, EventArgs e)
        {
            try
            {
                Poruka poruka = new Poruka
                {
                    Tekst = rtbPorukaZaSve.Text,
                    Operacija = Operacija.SaljiSvima,
                    Vreme = DateTime.Now.ToString("HH:mm:ss"),
                    Primalac = new Korisnik
                    {
                        Ime = "svi korisnici"
                    }
                };
                Komunikacija.Instanca.SaljiPoruku(poruka);

            }
            catch(ServerCommunicationException)
            {
                MessageBox.Show("Prekinuta je veza sa serverom");
                this.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSaljiKorisniku_Click(object sender, EventArgs e)
        {
            Poruka poruka = new Poruka
            {
                Tekst = rtbPorukaZaJednog.Text,
                Operacija = Operacija.SaljiSvima,
                Primalac = (Korisnik)cbKorisnici.SelectedItem,
                Vreme = DateTime.Now.ToString("HH:mm:ss")
            };
            Komunikacija.Instanca.SaljiPoruku(poruka);
        }

        private void btnProcitajPoruku_Click(object sender, EventArgs e)
        {
            if(dgvZadnje3.SelectedRows.Count > 0)
            {
                Poruka poruka = (Poruka)dgvZadnje3.SelectedRows[0].DataBoundItem;
                if (poruka.Tekst.Length <= 20) MessageBox.Show("Poruka ima do 20 karaktera");
                else MessageBox.Show(poruka.Tekst);
            }
            else if (dgvOstale.SelectedRows.Count > 0)
            {
                Poruka poruka = (Poruka)dgvOstale.SelectedRows[0].DataBoundItem;
                if (poruka.Tekst.Length <= 20) MessageBox.Show("Poruka ima do 20 karaktera");
                else MessageBox.Show(poruka.Tekst);
            }
        }

        private void btnVidiPoruke_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                

                if (cbIzabraniKorisnik.Text == "Pera 1")
                {
                    if (pera1.Count < 3)
                    {
                        
                        dgvKorisnikZadnje3.DataSource = pera1;
                        dgvKorisnikZadnje3.Columns["Uspesno"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Operacija"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Vreme"].Visible = false;
                        ((DataGridViewTextBoxColumn)dgvKorisnikZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                    }
                    else
                    {
                        dgvKorisnikOstale.DataSource = pera1.Take(pera1.Count - 3).ToList();
                        dgvKorisnikZadnje3.DataSource = pera1.Except(pera1.Take(pera1.Count - 3).ToList()).ToList();
                        dgvKorisnikZadnje3.Columns["Uspesno"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Operacija"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Vreme"].Visible = false;
                        dgvKorisnikOstale.Columns["Uspesno"].Visible = false;
                        dgvKorisnikOstale.Columns["Operacija"].Visible = false;
                        dgvKorisnikOstale.Columns["Vreme"].Visible = false;
                        ((DataGridViewTextBoxColumn)dgvKorisnikZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                        ((DataGridViewTextBoxColumn)dgvKorisnikOstale.Columns["Tekst"]).MaxInputLength = 20;

                    }
                }
            }));
            Invoke(new Action(() =>
            {
                if (cbIzabraniKorisnik.Text == "Pera 2")
                {
                    if (pera2.Count < 3)
                    {
                        
                        dgvKorisnikZadnje3.DataSource = pera2;
                        dgvKorisnikZadnje3.Columns["Uspesno"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Operacija"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Vreme"].Visible = false;
                        ((DataGridViewTextBoxColumn)dgvKorisnikZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                    }
                    else
                    {
                        
                        dgvKorisnikOstale.DataSource = pera2.Take(pera2.Count - 3).ToList();
                        dgvKorisnikZadnje3.DataSource = pera2.Except(pera2.Take(pera2.Count - 3).ToList()).ToList();
                        dgvKorisnikZadnje3.Columns["Uspesno"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Operacija"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Vreme"].Visible = false;
                        dgvKorisnikOstale.Columns["Uspesno"].Visible = false;
                        dgvKorisnikOstale.Columns["Operacija"].Visible = false;
                        dgvKorisnikOstale.Columns["Vreme"].Visible = false;
                        ((DataGridViewTextBoxColumn)dgvKorisnikZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                        ((DataGridViewTextBoxColumn)dgvKorisnikOstale.Columns["Tekst"]).MaxInputLength = 20;

                    }
                }
            }));
            Invoke(new Action(() =>
            {
                if (cbIzabraniKorisnik.Text == "Pera 3")
                {
                    if (pera3.Count < 3)
                    {

                        dgvKorisnikZadnje3.DataSource = pera3;
                        dgvKorisnikZadnje3.Columns["Uspesno"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Operacija"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Vreme"].Visible = false;
                        ((DataGridViewTextBoxColumn)dgvKorisnikZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                    }
                    else
                    {

                        dgvKorisnikOstale.DataSource = pera3.Take(pera3.Count - 3).ToList();
                        dgvKorisnikZadnje3.DataSource = pera3.Except(pera3.Take(pera3.Count - 3).ToList()).ToList();
                        dgvKorisnikZadnje3.Columns["Uspesno"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Operacija"].Visible = false;
                        dgvKorisnikZadnje3.Columns["Vreme"].Visible = false;
                        dgvKorisnikOstale.Columns["Uspesno"].Visible = false;
                        dgvKorisnikOstale.Columns["Operacija"].Visible = false;
                        dgvKorisnikOstale.Columns["Vreme"].Visible = false;
                        ((DataGridViewTextBoxColumn)dgvKorisnikZadnje3.Columns["Tekst"]).MaxInputLength = 20;
                        ((DataGridViewTextBoxColumn)dgvKorisnikOstale.Columns["Tekst"]).MaxInputLength = 20;

                    }
                }
            }));
        }

        private void btnProcitajOdKorisnika_Click(object sender, EventArgs e)
        {
            if (dgvKorisnikZadnje3.SelectedRows.Count > 0)
            {
                Poruka poruka = (Poruka)dgvKorisnikZadnje3.SelectedRows[0].DataBoundItem;
                if (poruka.Tekst.Length <= 20) MessageBox.Show("Poruka ima do 20 karaktera");
                else MessageBox.Show(poruka.Tekst);
            }
            else if (dgvKorisnikOstale.SelectedRows.Count > 0)
            {
                Poruka poruka = (Poruka)dgvKorisnikOstale.SelectedRows[0].DataBoundItem;
                if (poruka.Tekst.Length <= 20) MessageBox.Show("Poruka ima do 20 karaktera");
                else MessageBox.Show(poruka.Tekst);
            }
        }
    }
}
