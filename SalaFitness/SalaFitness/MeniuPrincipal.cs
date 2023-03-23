using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace SalaFitness
{
    public partial class MeniuPrincipal : Form
    {
        OracleCommand cmd;
        OracleConnection con;
        Login log;
        public MeniuPrincipal(OracleCommand cm, OracleConnection co,Login lo )
        {
            InitializeComponent();
            cmd = cm;
            con = co;
            log = lo;
        }

        private void buttonAbonament_Click(object sender, EventArgs e)
        {
            Abonament abonament = new Abonament(cmd, con,this);
            this.Hide();
            abonament.ShowDialog();
            
        }

        private void buttonPersoana_Click(object sender, EventArgs e)
        {
            Persoana persoana = new Persoana(cmd, con,this);
            this.Hide();
            persoana.ShowDialog();
            
        }

        private void buttonSala_Click(object sender, EventArgs e)
        {
            Sala sala = new Sala(cmd, con,this);
            this.Hide();
            sala.ShowDialog();
            
        }

        private void buttonCategorie_Click(object sender, EventArgs e)
        {
            Categorie categorie = new Categorie(cmd, con,this);
            this.Hide();
            categorie.ShowDialog();
            
        }
    }
}
