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
    public partial class Catégories : Form
    {

        Fonctions Con;
        public Catégories()
        {
            InitializeComponent();
            Con = new Fonctions();
            AfficherCategories();
        }

        private void AfficherCategories()
        {
            string Req = "Select * from Categorie";
            ListeCategories.DataSource = Con.RecupererDonnees(Req);
        }
        private void Catégories_Load(object sender, EventArgs e)
        {

        }

        private void EnregistrerBtn_Click(object sender, EventArgs e)
        {
            if (CatNomTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Données Incomplètes !");
            }
            else
            {
                try
                {
                    string Nom = CatNomTb.Text;
                    string Desc = DescTb.Text;
                    string Req = "insert into Categorie values ('{0}','{1}')";
                    Req = String.Format(Req, Nom, Desc);
                    Con.EnvoyerDonnees(Req);
                    AfficherCategories();
                    MessageBox.Show("Catégorie Ajoutée !");
                    CatNomTb.Text = "";
                    DescTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int Cle = 0;
        private void ListeCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatNomTb.Text = ListeCategories.SelectedRows[0].Cells[1].Value.ToString();
            DescTb.Text = ListeCategories.SelectedRows[0].Cells[2].Value.ToString();
            if (CatNomTb.Text == "")
            {
                Cle = 0;
            }
            else
            {
                Cle = Convert.ToInt32(ListeCategories.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void ModifierBtn_Click(object sender, EventArgs e)
        {

            if (CatNomTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Données Incomplètes !");
            }
            else
            {
                try
                {
                    string Nom = CatNomTb.Text;
                    string Desc = DescTb.Text;
                    string Req = "update Categorie set CatNom = '{0}',CatDescription = '{1}' where CatId = '{2}'"; 
                    Req = String.Format(Req, Nom, Desc, Cle);
                    Con.EnvoyerDonnees(Req);
                    AfficherCategories();
                    MessageBox.Show("Catégorie Modifiée !");
                    CatNomTb.Text = "";
                    DescTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            if (CatNomTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Données Incomplètes !");
            }
            else
            {
                try
                {
                    string Nom = CatNomTb.Text;
                    string Desc = DescTb.Text;
                    string Req = "delete from Categorie where CatId = {0}";
                    Req = String.Format(Req, Cle);
                    Con.EnvoyerDonnees(Req);
                    AfficherCategories();
                    MessageBox.Show("Catégorie Supprimée !");
                    CatNomTb.Text = "";
                    DescTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
