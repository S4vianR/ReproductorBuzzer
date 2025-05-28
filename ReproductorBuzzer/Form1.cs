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

            // Al iniciar, intentamos conectar automáticamente al COM5
            // Puedes decidir si quieres que se conecte automáticamente o requiera un botón "Conectar"
            // Si quieres auto-conexión, podrías llamar a una función ConnectPort() aquí.
            // Para mantener la consistencia con el código anterior que tenía un botón "Conectar",
            // lo dejaremos manual, asumiendo que tienes un botón `btnConnect` en tu formulario
            // aunque no esté en el código que mostraste. Si no tienes un botón de conexión,
            // considera añadir la lógica de conexión aquí.
        }

        // Si no tienes un botón "Conectar" y quieres autoconectar,
        // podrías añadir esta lógica en el constructor o en Form_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Opcional: Si quieres que se intente conectar automáticamente al cargar el formulario
            // Sin un botón de conexión explícito, esto hace que la aplicación intente conectarse al inicio.
            // Si tienes un botón de conexión, este método podría quedar vacío o eliminarse.
            // IntentarConectarArduino(); // Llama a una función para intentar la conexión
        }

        /*
         * Si quieres un botón "Conectar" separado, como en la versión anterior,
         * asegúrate de que el botón `btnConnect` esté en tu formulario y su evento
         * `Click` esté vinculado a este método.
         */
        private void conectarButton_Click(object sender, EventArgs e)
        {
            if (arduinoPort.IsOpen)
            {
                try
                {
                    arduinoPort.Close();
                    // Asumiendo que btnConnect existe y es el botón de conexión/desconexión
                    // btnConnect.Text = "Conectar";
                    reproducirButton.Enabled = false;
                    pausarButton.Enabled = false;
                    statusTextBox.AppendText("Desconectado del puerto serial." + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    statusTextBox.AppendText("Error al desconectar: " + ex.Message + Environment.NewLine);
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
                statusTextBox.AppendText("Conectado a " + arduinoPort.PortName + Environment.NewLine);
            }
            catch (Exception ex)
            {
                statusTextBox.AppendText("Error al conectar al COM5: " + ex.Message + Environment.NewLine);
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
                    statusTextBox.AppendText("Arduino: " + data + Environment.NewLine);
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
                    statusTextBox.AppendText("Error de lectura: " + ex.Message + Environment.NewLine);
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
                    statusTextBox.AppendText("Comando 'P' enviado: Iniciar melodía." + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    statusTextBox.AppendText("Error al enviar comando 'P': " + ex.Message + Environment.NewLine);
                }
            }
            else
            {
                statusTextBox.AppendText("No conectado a Arduino. Por favor, intenta conectar." + Environment.NewLine);
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
                    statusTextBox.AppendText("Comando 'S' enviado: Detener melodía." + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    statusTextBox.AppendText("Error al enviar comando 'S': " + ex.Message + Environment.NewLine);
                }
            }
            else
            {
                statusTextBox.AppendText("No conectado a Arduino. Por favor, intenta conectar." + Environment.NewLine);
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