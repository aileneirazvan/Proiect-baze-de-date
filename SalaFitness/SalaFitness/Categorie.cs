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
    public partial class Categorie : Form
    {
        OracleCommand cmd;
        OracleConnection con;
        MeniuPrincipal meniu;
        public Categorie(OracleCommand cm, OracleConnection co,MeniuPrincipal menu)
        {
            InitializeComponent();
            cmd = cm;
            con = co;
            meniu = menu;
            updateDataGrid();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            meniu.Show();
            this.Close();
        }
        private void updateDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select ID_CATEGORIE, TIP, PRET" +
                             " from CATEGORIE ";
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
            textBoxID_Categorie.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBoxPret.Text = "";
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            String tip;
            if (radioButton1.Checked == true)
            {
                tip = radioButton1.Text;
            }
            else
            {
                tip = radioButton2.Text;
            }
            cmd.CommandText = "INSERT INTO CATEGORIE (ID_CATEGORIE,TIP, PRET) VALUES ('" + textBoxID_Categorie.Text + "','" + tip + "' , '" + textBoxPret.Text + "')";
            cmd.ExecuteNonQuery();
            updateDataGrid();
            ClearData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBoxID_Categorie.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Standard")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
             if (dataGridView1.CurrentRow.Cells[1].Value.ToString() == "Premium")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            textBoxPret.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
            
        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "DELETE FROM CATEGORIE WHERE ID_CATEGORIE=" + textBoxID_Categorie.Text;
            cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            String tip;
            if (radioButton1.Checked == true)
            {
                tip = radioButton1.Text;
            }
            else
            {
                tip = radioButton2.Text;
            }
            cmd.CommandText = "UPDATE CATEGORIE SET TIP='" + tip + "',PRET='" + textBoxPret.Text + "' WHERE ID_CATEGORIE='" + textBoxID_Categorie.Text + "'";
            cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void textBoxID_Categorie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
