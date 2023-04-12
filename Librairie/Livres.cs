using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Librairie
{
    public partial class Livres : Form
    {
        Fonctions Con;
        public Livres()
        {
            InitializeComponent();
            Con = new Fonctions();
            AfficherLivres();
            RemplirCat();
            RemplirAuteur();
        }

        private void RemplirCat()
        {
            string Req = "select * from Categorie";
            CatCb.DisplayMember = Con.RecupererDonnees(Req).Columns["CatNom"].ToString();
            CatCb.ValueMember = Con.RecupererDonnees(Req).Columns["CatId"].ToString();
            CatCb.DataSource = Con.RecupererDonnees(Req);
        }


        private void RemplirAuteur()
        {
            string Req = "select * from Auteur";
            AuteurCb.DisplayMember = Con.RecupererDonnees(Req).Columns["AutNom"].ToString();
            AuteurCb.ValueMember = Con.RecupererDonnees(Req).Columns["AutId"].ToString();
            AuteurCb.DataSource = Con.RecupererDonnees(Req);
        }


        private void AfficherLivres()
        {
            string Req = "Select * from Livres";
            ListeLivres.DataSource = Con.RecupererDonnees(Req);
        }

        private void label7_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || AuteurCb.SelectedIndex == -1 || PrixTb.Text == "" || QteTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Données Incomplètes !");
            }
            else
            {
                try
                {
                    string Nom = NomTb.Text;
                    int Auteur = Convert.ToInt32(AuteurCb.SelectedValue.ToString());
                    int Categorie = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Qte = Convert.ToInt32(QteTb.Text);
                    int Prix = Convert.ToInt32(PrixTb.Text);

                    string Req = "update Livres set LNom = '{0}' , LAuteur = '{1}' ,  LCategorie = '{2}' , LQuantite = '{3}' , LPrix = '{4}' where LId = '{5}'";
                    Req = String.Format(Req, Nom, Auteur, Categorie, Qte, Prix, Cle);
                    Con.EnvoyerDonnees(Req);
                    AfficherLivres();
                    MessageBox.Show("Livre Modifié !");
                    NomTb.Text = "";
                    AuteurCb.SelectedIndex = -1;
                    PrixTb.Text = "";
                    QteTb.Text = "";
                    CatCb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EnregistrerBtn_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || AuteurCb.SelectedIndex == -1 || PrixTb.Text == "" || QteTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Données Incomplètes !");
            }
            else
            {
                try
                {
                    string Nom = NomTb.Text;
                    int Auteur = Convert.ToInt32(AuteurCb.SelectedValue.ToString());
                    int Categorie = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Qte = Convert.ToInt32(QteTb.Text);
                    int Prix = Convert.ToInt32(PrixTb.Text);

                    string Req = "insert into Livres values ('{0}' , '{1}' , '{2}' , '{3}' , '{4}')";
                    Req = String.Format(Req, Nom, Auteur, Categorie, Qte, Prix);
                    Con.EnvoyerDonnees(Req);
                    AfficherLivres();
                    MessageBox.Show("Livre Ajouté !");
                    NomTb.Text = "";
                    AuteurCb.SelectedIndex = -1;
                    PrixTb.Text = "";
                    QteTb.Text = "";
                    CatCb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Cle = 0;
        private void ListeLivres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NomTb.Text = ListeLivres.SelectedRows[0].Cells[1].Value.ToString();
            AuteurCb.SelectedValue = ListeLivres.SelectedRows[0].Cells[2].Value.ToString();
            CatCb.SelectedValue = ListeLivres.SelectedRows[0].Cells[3].Value.ToString();
            QteTb.Text = ListeLivres.SelectedRows[0].Cells[4].Value.ToString();
            PrixTb.Text = ListeLivres.SelectedRows[0].Cells[5].Value.ToString();

            if (NomTb.Text == "")
            {
                Cle = 0;
            }
            else
            {
                Cle = Convert.ToInt32(ListeLivres.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            if (NomTb.Text == "" || AuteurCb.SelectedIndex == -1 || PrixTb.Text == "" || QteTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Données Incomplètes !");
            }
            else
            {
                try
                {
                    string Nom = NomTb.Text;
                    int Auteur = Convert.ToInt32(AuteurCb.SelectedValue.ToString());
                    int Categorie = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Qte = Convert.ToInt32(QteTb.Text);
                    int Prix = Convert.ToInt32(PrixTb.Text);

                    string Req = "delete from Livres where LId = '{0}'";
                    Req = String.Format(Req, Cle);
                    Con.EnvoyerDonnees(Req);
                    AfficherLivres();
                    MessageBox.Show("Livre Supprimé !");
                    NomTb.Text = "";
                    AuteurCb.SelectedIndex = -1;
                    PrixTb.Text = "";
                    QteTb.Text = "";
                    CatCb.SelectedIndex = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
