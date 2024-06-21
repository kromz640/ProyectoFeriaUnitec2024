using System;
using System.IO.Ports;
using System.Threading;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "server=localhost;uid=root;pwd=passwd;database=Webappclima;";
        string portName = "COM5";
        int baudRate = 9600;

        using (SerialPort serialPort = new SerialPort(portName, baudRate))
        {
            serialPort.Open();

            while (true)
            {
                try
                {
                    // Leer datos del puerto serie
                    string data = serialPort.ReadLine();
                    string[] sensorValues = data.Split(',');

                    if (sensorValues.Length == 3)
                    {
                        float temperatura = float.Parse(sensorValues[0]);
                        float presion = float.Parse(sensorValues[1]);
                        float altitud = float.Parse(sensorValues[2]);
                        DateTime fechaHora = DateTime.Now;

                        // Insertar datos en la base de datos
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "INSERT INTO tbllecturas (fecha_hora, temperatura, presion, altitud) VALUES (@fechaHora, @temperatura, @presion, @altitud)";
                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@fechaHora", fechaHora);
                                cmd.Parameters.AddWithValue("@temperatura", temperatura);
                                cmd.Parameters.AddWithValue("@presion", presion);
                                cmd.Parameters.AddWithValue("@altitud", altitud);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Esperar 10 milisegundos antes de la siguiente lectura
                        Thread.Sleep(10);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
