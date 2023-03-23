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
    public partial class Persoana : Form
    {
        OracleCommand cmd;
        OracleConnection con;
        MeniuPrincipal meniu;

        public Persoana(OracleCommand cm, OracleConnection co, MeniuPrincipal menu)
        {
            InitializeComponent();
            cmd = cm;
            con = co;
            meniu = menu;
            updateDataGrid();

        }
        private void updateDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select ID_PERSOANA, NUME, PRENUME, TELEFON, SEX, VARSTA,EMAIL " +
                             "from PERSOANA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt.DefaultView;
            dataGridView1.Columns[0].Visible = false;
            dr.Close();
        }
        private void ClearData()
        {
            textBoxID_Persoana.Text = "";
            textBoxNume.Text = "";
            textBoxPrenume.Text = "";
            textBoxTelefon.Text = "";
            textBoxVarsta.Text = "";
            textBoxEmail.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            String sex;
            if(radioButton1.Checked==true)
            {
                sex = radioButton1.Text;
            }
            else
            {
                sex = radioButton2.Text;
            }
            cmd.CommandText = "INSERT INTO PERSOANA (ID_PERSOANA,NUME, PRENUME, TELEFON, SEX, VARSTA, EMAIL) VALUES ('" + textBoxID_Persoana.Text + "','" + textBoxNume.Text + "' , '" + textBoxPrenume.Text + "'  ,   '"+textBoxTelefon.Text+"'  ,'"+sex+"' ,      '"+Int32.Parse(textBoxVarsta.Text)+"' , '" + textBoxEmail.Text + "'  )";
            cmd.ExecuteNonQuery();
            updateDataGrid();
            ClearData();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            meniu.Show();
            this.Close();
        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "DELETE FROM PERSOANA WHERE ID_PERSOANA=" + textBoxID_Persoana.Text;
            cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBoxID_Persoana.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNume.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxPrenume.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Masculin")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            if(dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Feminin")
            {
                
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            textBoxVarsta.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBoxEmail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            String sex;
            if (radioButton1.Checked == true)
            {
                sex = radioButton1.Text;
            }
            else
            {
                sex = radioButton2.Text; 
            }
            cmd.CommandText = "UPDATE PERSOANA SET NUME='" + textBoxNume.Text + "',PRENUME='" + textBoxPrenume.Text + "',TELEFON='" + textBoxTelefon.Text + "',SEX='" + sex + "',VARSTA='" + textBoxVarsta.Text +  "',EMAIL='" + textBoxEmail.Text + "' WHERE ID_PERSOANA='" + textBoxID_Persoana.Text + "'";
            cmd.ExecuteNonQuery();
            updateDataGrid();          
        }

        private void Persoana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxID_Persoana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxNume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPrenume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxVarsta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
