using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librairie
{
    class Fonctions
    {
        private System.Data.SqlClient.SqlConnection Con;
        private System.Data.SqlClient.SqlCommand Cmd;
        private System.Data.DataTable dt;
        private System.Data.SqlClient.SqlDataAdapter sda;
        private string ConStr;
        public Fonctions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\thinh\OneDrive\Documents\LibrairieDB.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new System.Data.SqlClient.SqlConnection(ConStr);
            Cmd = new System.Data.SqlClient.SqlCommand();
            Cmd.Connection = Con;
        }

        public System.Data.DataTable RecupererDonnees(String Req)
        {
            dt = new DataTable();
            sda = new System.Data.SqlClient.SqlDataAdapter(Req, ConStr);
            sda.Fill(dt);
            return dt;
        }
        public int EnvoyerDonnees(string Req)
        {
            int Cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.CommandText = Req;
            Cnt = Cmd.ExecuteNonQuery();
            return Cnt;
        }
     }
}
