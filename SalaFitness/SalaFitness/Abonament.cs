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
    public partial class Abonament : Form
    {
        OracleCommand cmd;
        OracleConnection con;
        MeniuPrincipal meniu;
        List<int> id_persoana = new List<int>();
        List<int> id_sala = new List<int>();
        List<int> id_categorie = new List<int>();


        public Abonament(OracleCommand cm, OracleConnection co,MeniuPrincipal menu)
        {
            InitializeComponent();
            cmd = cm;
            con = co;
            meniu = menu;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            updateDataGrid();

            cmd.CommandText = "select nume, ID_PERSOANA FROM PERSOANA";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxIDPersoana.Items.Add(dr.GetString(0));
                id_persoana.Add(Int32.Parse(dr.GetString(1)));
            }
            cmd.CommandText = "select nume, ID_SALA FROM SALA";
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxIDSala.Items.Add(dr.GetString(0));
                id_sala.Add(Int32.Parse(dr.GetString(1)));
            }
            cmd.CommandText = "select TIP, ID_CATEGORIE FROM CATEGORIE";
            cmd.CommandType = CommandType.Text;
             dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxIDCategorie.Items.Add(dr.GetString(0));
                id_categorie.Add(Int32.Parse(dr.GetString(1)));
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            meniu.Show();
            this.Close();
        }

        private void updateDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select a.ID_ABONAMENT, p.nume, s.nume, c.tip, a.NUME_ABONAMENT, a.DATA, a.STARE, a.ACTIVITATE " +
                              "from ABONAMENT a, PERSOANA p, CATEGORIE c,SALA s " +
                              "WHERE a.ID_PERSOANA=p.ID_PERSOANA AND a.ID_SALA=s.ID_SALA AND a.ID_CATEGORIE=c.ID_CATEGORIE ";
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
            comboBoxIDPersoana.SelectedIndex = -1;
            comboBoxIDCategorie.SelectedIndex = -1;
            comboBoxIDSala.SelectedIndex = -1;
            textBoxNumeAbonament.Text = "";
            dateTimePicker1.Text = "";  
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            String stare,activitate;
            if (radioButton1.Checked == true)
            {
                stare = radioButton1.Text;
            }
            else
            {
                stare = radioButton2.Text;
            }
            if(radioButton3.Checked==true)
            {
                activitate = radioButton3.Text;
            }
            else
            {
                activitate = radioButton4.Text;
            }

            cmd.CommandText = "INSERT INTO ABONAMENT (ID_PERSOANA,ID_SALA,ID_CATEGORIE,NUME_ABONAMENT, DATA, STARE, ACTIVITATE) " +
                              "VALUES ('" + id_persoana[comboBoxIDPersoana.SelectedIndex] + "','" + id_sala[comboBoxIDSala.SelectedIndex] + "', '" + id_categorie[comboBoxIDCategorie.SelectedIndex] + "','" + textBoxNumeAbonament.Text + "' , to_date('" + dateTimePicker1.Text + "','DD-MM-YYYY'), '" + stare + "', '" + activitate + "')";
            cmd.ExecuteNonQuery();
            updateDataGrid();
            ClearData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CurrentRow.Selected = true;
            comboBoxIDPersoana.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxIDSala.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBoxIDCategorie.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxNumeAbonament.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Valid")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Expirat")
            {

                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "Fitness")
            {
                radioButton3.Checked = true;
                radioButton4.Checked = false;
            }
            else
            if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "Sala de forta")
            {

                radioButton3.Checked = false;
                radioButton4.Checked = true;
            }
        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "DELETE FROM ABONAMENT WHERE ID_ABONAMENT=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            String stare, activitate;
            if (radioButton1.Checked == true)
            {
                stare = radioButton1.Text;
            }
            else
            {
                stare = radioButton2.Text;
            }
            if (radioButton3.Checked == true)
            {
                activitate = radioButton3.Text;
            }
            else
            {
                activitate = radioButton4.Text;
            }
            cmd.CommandText = "UPDATE ABONAMENT SET NUME_ABONAMENT='" + textBoxNumeAbonament.Text + "',DATA= to_date('" + dateTimePicker1.Text + "','DD-MM-YYYY'),STARE='" + stare +"',ACTIVITATE='" + activitate + "' WHERE ID_ABONAMENT='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void textBoxNumeAbonament_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
    }
}
