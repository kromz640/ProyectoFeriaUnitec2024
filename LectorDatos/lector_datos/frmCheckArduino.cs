using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace lectorDatos
{
    public partial class frmCheckArduino : Form
    {
        private SerialPort serialPort;
        private int elapsedTime;

        public frmCheckArduino()
        {
            InitializeComponent();
        }

        private void frmCheckArduino_Load(object sender, EventArgs e)
        {
            
            /*serialPort = new SerialPort("COM5", 9600);
            serialPort.ReadTimeout = 1000; */
            progressBar.Value = 0;
            elapsedTime = 0;
            timerCheck.Start();
            
            System.Diagnostics.Process.Start(@"C:\Users\rroqu\OneDrive\Documentos\Proyecto Feria\ArduinoChecker\x64\Debug\ArduinoChecker.exe");
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            elapsedTime += timerCheck.Interval;

            // Actualizar la barra de progreso
            progressBar.Value = (int)((elapsedTime / 3500.0) * 100);

            if (elapsedTime >= 3500)
            {
                timerCheck.Stop();
               // CheckArduinoConnection();
            }
        }

        private void CheckArduinoConnection()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                }

                // Enviar un comando al Arduino para obtener el modelo de la placa
                serialPort.WriteLine("GET_MODEL");

                // Leer la respuesta del Arduino
                string response = serialPort.ReadLine();

                //si response no es nulo, mostrar un mensaje con la placa conectada, si no, mostrar un mensaje de error
                if (response != null) 
                    MessageBox.Show("Placa conectada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Placa no conectada Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timerCheck.Stop();
            /*if (serialPort.IsOpen)
            {
                serialPort.Close();
            }*/
            this.Close();
        }
    }
}
