using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lectorDatos
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            abrirConexionBaseDatos();
        }

        private void abrirConexionBaseDatos()
        {
            string connStr = "server=localhost;user=root;database=webAppClima;port=3306;password=passwd";
            try
            {
                Program.con = new MySqlConnection(connStr);
                Program.con.Open();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM tblUsuarios WHERE user = @user AND passwd = @passwd";
                using (MySqlCommand cmd = new MySqlCommand(query, Program.con))
                {
                    cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@passwd", txtContrasena.Text);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        this.Hide();
                        frmMain mainForm = new frmMain();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contrasena incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.con != null && Program.con.State == System.Data.ConnectionState.Open)
            {
                Program.con.Close();
                
            }
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
