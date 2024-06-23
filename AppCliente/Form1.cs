using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVerRegistros_Click(object sender, EventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=webappclima;UID=root;PASSWORD=passwd;";

            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    string query = "SELECT lectura_id, fecha_hora, temperatura, presion, altitud FROM tbllecturas";
                    MySqlCommand cmd = new MySqlCommand(query, cnn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    dataGridView1.DataSource = dt;
                    dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //confirm exit
            if (MessageBox.Show("Salir del programa", "Salir", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                Application.Exit();
            }
            
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicacion cliente para visualizar los registros clima");
        }
    }
}
