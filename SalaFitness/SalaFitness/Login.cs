using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace SalaFitness
{
    public partial class Login : Form
    {
        OracleCommand cmd;
        OracleConnection con;
        public Login(OracleCommand cm,OracleConnection co)        
        {
            InitializeComponent();
            cmd = cm;
            con = co;
            con.Open();

        }

        Logare login = new Logare("ailenei", "razvan");


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string user = textBoxUsername.Text;
            string pass = textBoxPassword.Text;

            if (login.IsLoggedIn(user, pass))
            {
                MessageBox.Show("Te-ai logat cu succes");
                this.Hide();
                MeniuPrincipal sistema = new MeniuPrincipal(cmd, con, this);
                sistema.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show("Eroare de logare! Incercati din nou");
            }
        }

        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
    }
}
