using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SalaFitness
{
    [Serializable]
    public class Logare
    {
        public string Username { get; set; }
        public string Userpassword { get; set; }

        public Logare(string user, string pass)
        {
            this.Username = user;
            this.Userpassword = pass;
        }

        private void Stergere(string user, string pass)
        {
            user = string.Empty;
            pass = string.Empty;
        }

        internal bool IsLoggedIn(string user, string pass)
        {
            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("Introduceti numele de utilizator: ");
                return false;
            }

            else
            {
                if (Username != user)
                {
                    MessageBox.Show("Nume de utilizator incorect");
                    Stergere(user, pass);
                    return false;
                }

                if (string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Introduceti parola: ");
                    return false;
                }

                else if (Userpassword != pass)
                {
                    MessageBox.Show("Parola incorecta");
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }
    }
}
