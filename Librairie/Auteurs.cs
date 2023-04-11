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
    public partial class Auteurs : Form
    {
        Fonctions Con;
        public Auteurs()
        {
            InitializeComponent();
            Con = new Fonctions();
            AfficherAuteurs();
        }
        private void AfficherAuteurs()
        {
            string Req = "Select * from Auteur";
            ListeAuteurs.DataSource = Con.RecupererDonnees(Req);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void EnregistrerBtn_Click(object sender, EventArgs e)
        {
            if (AutNomTb.Text == "" || GenCb.SelectedIndex == -1 || PaysTb.Text == "")
            {
                MessageBox.Show("Données Incomplètes !");
            } else
            {
                try
                {
                    string Nom = AutNomTb.Text;
                    string Genre = GenCb.SelectedItem.ToString();
                    string Pays = PaysTb.Text;
                    string Req = "insert into Auteur values ('{0}','{1}','{2}')";
                    Req = String.Format(Req, Nom, Genre, Pays);
                    Con.EnvoyerDonnees(Req);
                    AfficherAuteurs();
                    MessageBox.Show("Auteur Ajouté !");
                    AutNomTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    PaysTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ListeAuteurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        int Cle = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AutNomTb.Text = ListeAuteurs.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = ListeAuteurs.SelectedRows[0].Cells[2].Value.ToString();
            PaysTb.Text = ListeAuteurs.SelectedRows[0].Cells[3].Value.ToString();
            if (AutNomTb.Text == "")
            {
                Cle = 0;
            }else
            {
                Cle = Convert.ToInt32(ListeAuteurs.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void ModifierBtn_Click(object sender, EventArgs e)
        {
            if (AutNomTb.Text == "" || GenCb.SelectedIndex == -1 || PaysTb.Text == "")
            {
                MessageBox.Show("Données Incomplètes !");
            }
            else
            {
                try
                {
                    string Nom = AutNomTb.Text;
                    string Genre = GenCb.SelectedItem.ToString();
                    string Pays = PaysTb.Text;
                    string Req = "Update Auteur set AutNom = '{0}' ,AutGenre = '{1}' ,AutPays = '{2}' where AutId = '{3}'";
                    Req = String.Format(Req, Nom, Genre, Pays, Cle);
                    Con.EnvoyerDonnees(Req);
                    AfficherAuteurs();
                    MessageBox.Show("Auteur Modifié !");
                    AutNomTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    PaysTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void SupprimerBtn_Click(object sender, EventArgs e)
        {
            if (AutNomTb.Text == "" || GenCb.SelectedIndex == -1 || PaysTb.Text == "")
            {
                MessageBox.Show("Selectionnez un Auteur !");
            }
            else
            {
                try
                {
                    string Nom = AutNomTb.Text;
                    string Genre = GenCb.SelectedItem.ToString();
                    string Pays = PaysTb.Text;
                    string Req = "delete from Auteur where AutId = {0}";
                    Req = String.Format(Req, Cle);
                    Con.EnvoyerDonnees(Req);
                    AfficherAuteurs();
                    MessageBox.Show("Auteur Supprimé !");
                    AutNomTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    PaysTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
