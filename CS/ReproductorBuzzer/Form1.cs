using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports; // Esta directiva using System.IO.Ports; estaba duplicada, la eliminé
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductorBuzzer
{
    public partial class Form1 : Form
    {
        SerialPort arduinoPort;

        public Form1()
        {
            InitializeComponent(); // Solo debe llamarse una vez
            statusTextBox.Text = "No se está reproduciendo nada por el momento";

            arduinoPort = new SerialPort();
            arduinoPort.BaudRate = 9600; // La velocidad debe coincidir con la de Arduino (Serial.begin(9600))
            arduinoPort.PortName = "COM5"; // Establecemos COM5 como el puerto predeterminado
            arduinoPort.DataReceived += ArduinoPort_DataReceived; // Suscribe el evento para cuando Arduino envía datos

            // Deshabilitar botones de control de melodía hasta que estemos conectados
            reproducirButton.Enabled = false;
            pausarButton.Enabled = false;
        }

        // Si no tienes un botón "Conectar" y quieres autoconectar,
        // podrías añadir esta lógica en el constructor o en Form_Load
        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void conectarButton_Click(object sender, EventArgs e)
        {
            if (arduinoPort.IsOpen)
            {
                try
                {
                    arduinoPort.Close();
                    reproducirButton.Enabled = false;
                    pausarButton.Enabled = false;
                    statusTextBox.Text = "Desconectado del puerto serial." + Environment.NewLine;
                    conectarButton.Text = "Connect";
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al desconectar: " + ex.Message + Environment.NewLine;
                }
            }
            else
            {
                // La lógica de conexión se ha movido a un método separado para posible reuso
                AttemptConnectArduino();
            }
        }

        // Método auxiliar para intentar la conexión a Arduino
        private void AttemptConnectArduino()
        {
            try
            {
                arduinoPort.Open();
                // Asumiendo que btnConnect existe
                // btnConnect.Text = "Desconectar";
                reproducirButton.Enabled = true;
                pausarButton.Enabled = true;
                statusTextBox.Text = "Conectado a " + arduinoPort.PortName + Environment.NewLine;
                conectarButton.Text = "Disconnect";
            }
            catch (Exception ex)
            {
                statusTextBox.Text = "Error al conectar al COM5: " + ex.Message + Environment.NewLine;
                reproducirButton.Enabled = false;
                pausarButton.Enabled = false;
            }
        }


        // Evento que se dispara cuando Arduino envía datos a través del puerto serial
        private void ArduinoPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = arduinoPort.ReadLine(); // Lee una línea completa de datos del Arduino (hasta un '\n')

                // Es CRUCIAL usar Invoke para actualizar la UI desde un hilo secundario
                // El evento DataReceived se ejecuta en un hilo diferente al de la UI principal.
                this.Invoke(new MethodInvoker(delegate
                {
                    statusTextBox.Text = "Arduino: " + data + Environment.NewLine;
                    // Opcional: Auto-scroll al final del TextBox
                    statusTextBox.SelectionStart = statusTextBox.Text.Length;
                    statusTextBox.ScrollToCaret();
                }));
            }
            catch (Exception ex)
            {
                // Manejo de errores durante la lectura (ej. Arduino desconectado inesperadamente)
                this.Invoke(new MethodInvoker(delegate
                {
                    statusTextBox.Text = "Error de lectura: " + ex.Message + Environment.NewLine;
                }));
            }
        }

        private void reproducirButton_Click(object sender, EventArgs e)
        {
            if (arduinoPort.IsOpen)
            {
                try
                {
                    arduinoPort.Write("P"); // Envía el comando 'P' a Arduino (Play)
                    statusTextBox.Text = "Comando 'P' enviado: Iniciar melodía." + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al enviar comando 'P': " + ex.Message + Environment.NewLine;
                }
            }
            else
            {
                statusTextBox.Text = "No conectado a Arduino. Por favor, intenta conectar." + Environment.NewLine;
                AttemptConnectArduino(); // Intenta reconectar si no está conectado
            }
        }

        private void pausarButton_Click(object sender, EventArgs e)
        {
            if (arduinoPort.IsOpen)
            {
                try
                {
                    arduinoPort.Write("S"); // Envía el comando 'S' a Arduino (Stop)
                    statusTextBox.Text = "Comando 'S' enviado: Detener melodía." + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al enviar comando 'S': " + ex.Message + Environment.NewLine;
                }
            }
            else
            {
                statusTextBox.Text = "No conectado a Arduino. Por favor, intenta conectar." + Environment.NewLine;
                AttemptConnectArduino(); // Intenta reconectar si no está conectado
            }
        }

        // Se ejecuta cuando el formulario se está cerrando
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (arduinoPort.IsOpen)
            {
                arduinoPort.Close(); // Asegúrate de cerrar el puerto serial al cerrar la aplicación
            }
        }
    }
}