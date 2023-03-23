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
    public partial class Sala : Form
    {
        OracleCommand cmd;
        OracleConnection con;
        MeniuPrincipal meniu;
        public Sala(OracleCommand cm, OracleConnection co,MeniuPrincipal menu)
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
            cmd.CommandText = "select ID_SALA, NUME, CAPACITATE, STARE, ADRESA " +
                              "from SALA ";
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
            textBoxID_Sala.Text = "";
            textBoxNume.Text = "";
            textBoxCapacitate.Text = "";
            textBoxAdresa.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            String stare;
            if(radioButton1.Checked==true)
            {
                stare = radioButton1.Text;
            }
            else
            {
                stare = radioButton2.Text;
            }

            cmd.CommandText = "INSERT INTO SALA (ID_SALA,NUME, CAPACITATE, STARE, ADRESA) VALUES ('" + textBoxID_Sala.Text + "','" + textBoxNume.Text + "' , '" + textBoxCapacitate.Text + "', '" + stare + "', '" + textBoxAdresa.Text + "')";
            cmd.ExecuteNonQuery();
            updateDataGrid();
            ClearData();
        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "DELETE FROM SALA WHERE ID_SALA=" + textBoxID_Sala.Text;
            cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBoxID_Sala.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNume.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxCapacitate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Deschis")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            if (dataGridView1.CurrentRow.Cells[3].Value.ToString() == "Inchis")
            {

                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            textBoxAdresa.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            String stare;
            if (radioButton1.Checked == true)
            {
                stare = radioButton1.Text;
            }
            else
            {
                stare = radioButton2.Text;
            }
            cmd.CommandText = "UPDATE SALA SET NUME='" + textBoxNume.Text + "',CAPACITATE='" + textBoxCapacitate.Text + "',STARE='" + stare + "',ADRESA='" + textBoxAdresa.Text + "' WHERE ID_SALA='" + textBoxID_Sala.Text + "'";
            cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void textBoxID_Sala_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxNume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxCapacitate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
