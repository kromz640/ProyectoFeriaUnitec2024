using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace lectorDatos
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start(@"C:\Users\rroqu\OneDrive\Documentos\Proyecto Feria\ServidorClima\bin\Debug\net8.0\ServidorClima.exe");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("ServidorClima");
            if (proc.Length > 0)
            {
                proc[0].Kill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\rroqu\OneDrive\Documentos\Proyecto Feria\ServidorClima\bin\Debug\net8.0\ServidorClima.exe");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
      

        private void btnAppCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnConexionArduino_Click(object sender, EventArgs e)
        {

            frmCheckArduino checkArduinoForm = new frmCheckArduino();


            checkArduinoForm.Show();
        }

        private void btnDetenerArduino_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
            frmAbout aboutForm = new frmAbout();
            aboutForm.Show();

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Salir del Panel de Control?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("ServidorClima");
                if (proc.Length > 0)
                    proc[0].Kill();
                Application.Exit();
            }
        }
            
    }
}

