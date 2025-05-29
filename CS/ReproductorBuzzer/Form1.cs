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
        Boolean usingLocalMusic = false; // Variable para saber si se está usando música local o no
        private string localMusicPath = null;
        private System.Media.SoundPlayer localPlayer = null; // Para WAV
        // Para MP3, descomenta la siguiente línea y agrega la referencia a Windows Media Player
        // private WMPLib.WindowsMediaPlayer wmpPlayer = null;

        // Inicialiar una variable para guardar las canciones que se tienen en Properties.Resources se deben cargar dinámicamente
        // en el constructor o en el evento Load del formulario, no es necesario declararla aquí.

        public Form1()
        {
            InitializeComponent(); // Solo debe llamarse una vez
            statusTextBox.Text = "No se está reproduciendo nada por el momento";

            arduinoPort = new SerialPort();
            arduinoPort.BaudRate = 9600; // La velocidad debe coincidir con la de Arduino (Serial.begin(9600))
            arduinoPort.PortName = "COM5"; // Establecemos COM5 como el puerto predeterminadoxx
            arduinoPort.DataReceived += ArduinoPort_DataReceived; // Suscribe el evento para cuando Arduino envía datos

            // Deshabilitar botones de control de melodía hasta que estemos conectados
            reproducirButton.Enabled = false;
            pausarButton.Enabled = false;

            // Obtener dinámicamente todas las pistas de audio de Properties.Resources
            var canciones = typeof(Properties.Resources)
                .GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(System.IO.UnmanagedMemoryStream)) // Cambiado aquí
                .Select(p => new { Nombre = p.Name, Datos = (System.IO.UnmanagedMemoryStream)p.GetValue(null, null) })
                .ToList();

            foreach (var cancion in canciones)
            {
                musicComboBox.Items.Add(cancion.Nombre);
            }

            musicComboBox.SelectedIndex = -1; // No seleccionar ninguna canción al inicio
            usingLocalMusic = false; // Inicializar la variable para saber si se está usando música local o no
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
            usingLocalMusic = false; // Asegurarse de que no se está usando música local al intentar conectar a Arduino
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
            if (usingLocalMusic && localMusicPath != null)
            {
                try
                {
                    localPlayer?.Play();
                    // Para MP3: wmpPlayer?.controls.play();
                    statusTextBox.Text = "Reproduciendo música local: " + System.IO.Path.GetFileName(localMusicPath) + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al reproducir música local: " + ex.Message + Environment.NewLine;
                }
            }
            else if (arduinoPort.IsOpen)
            {
                try
                {
                    arduinoPort.Write("P");
                    statusTextBox.Text = "Comando 'P' enviado: Iniciar melodía." + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al enviar comando 'P': " + ex.Message + Environment.NewLine;
                }
            }
            else
            {
                statusTextBox.Text = "No conectado a Arduino. Usando música local" + Environment.NewLine;
                usingLocalMusic = true;
            }
        }

        private void pausarButton_Click(object sender, EventArgs e)
        {
            if (usingLocalMusic && localMusicPath != null)
            {
                try
                {
                    localPlayer?.Stop();
                    // Para MP3: wmpPlayer?.controls.pause();
                    statusTextBox.Text = "Música local pausada." + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al pausar música local: " + ex.Message + Environment.NewLine;
                }
            }
            else if (arduinoPort.IsOpen)
            {
                try
                {
                    arduinoPort.Write("S");
                    statusTextBox.Text = "Comando 'S' enviado: Detener melodía." + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al enviar comando 'S': " + ex.Message + Environment.NewLine;
                }
            }
            else
            {
                statusTextBox.Text = "No conectado a Arduino. Usando música local" + Environment.NewLine;
                usingLocalMusic = true;
            }

            // Mandar al llamar al evento clearButton_Click
            clearButton_Click(sender, e); // Limpiar el TextBox de selección de canción
        }


        // Se ejecuta cuando el formulario se está cerrando
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (arduinoPort.IsOpen)
            {
                arduinoPort.Close(); // Asegúrate de cerrar el puerto serial al cerrar la aplicación
            }
        }

        private void musicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Escribir en el statusTextBox el nombre de la canción seleccionada
            if (musicComboBox.SelectedItem != null)
            {
                string selectedSong = musicComboBox.SelectedItem.ToString();
                statusTextBox.Text = "Canción seleccionada: " + selectedSong + Environment.NewLine;
            }
            else
            {
                statusTextBox.Text = "No se ha seleccionado ninguna canción." + Environment.NewLine;
            }
        }

        private void localMusicButton_Click(object sender, EventArgs e)
        {
            if (musicComboBox.SelectedItem != null)
            {
                // Usar la canción seleccionada del ComboBox (recurso del proyecto)
                string nombreRecurso = musicComboBox.SelectedItem.ToString();
                string tempFile = GuardarRecursoComoArchivoTemporal(nombreRecurso);

                if (tempFile != null)
                {
                    localMusicPath = tempFile;
                    usingLocalMusic = true;
                    statusTextBox.Text = "Música local (recurso) seleccionada: " + nombreRecurso + Environment.NewLine;
                    localPlayer = new System.Media.SoundPlayer(localMusicPath);
                    reproducirButton.Enabled = true;
                    pausarButton.Enabled = true;
                }
                else
                {
                    statusTextBox.Text = "No se pudo cargar el recurso seleccionado." + Environment.NewLine;
                }
            }
            else
            {
                // Si no hay selección, permite elegir un archivo local como antes
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Archivos de audio (*.wav)|*.wav";
                    ofd.Title = "Selecciona una canción local";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        localMusicPath = ofd.FileName;
                        usingLocalMusic = true;
                        statusTextBox.Text = "Música local seleccionada: " + System.IO.Path.GetFileName(localMusicPath) + Environment.NewLine;
                        localPlayer = new System.Media.SoundPlayer(localMusicPath);
                        reproducirButton.Enabled = true;
                        pausarButton.Enabled = true;
                    }
                }
            }
        }


        private string GuardarRecursoComoArchivoTemporal(string nombreRecurso)
        {
            var propiedad = typeof(Properties.Resources)
                .GetProperty(nombreRecurso, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);

            if (propiedad == null)
                return null;

            var stream = propiedad.GetValue(null, null) as System.IO.UnmanagedMemoryStream;
            if (stream == null)
                return null;

            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), nombreRecurso + ".wav");
            using (var fileStream = new System.IO.FileStream(tempPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.Position = 0;
                stream.CopyTo(fileStream);
            }
            return tempPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Escribir un 1 en el songSelectorTextBox
            songSelectorTextBox.AppendText("1" + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Escribir un 2 en el songSelectorTextBox
            songSelectorTextBox.AppendText("2" + Environment.NewLine);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Escribir un 3 en el songSelectorTextBox
            songSelectorTextBox.AppendText("3" + Environment.NewLine);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Escribir un 4 en el songSelectorTextBox
            songSelectorTextBox.AppendText("4" + Environment.NewLine);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Escribir un 5 en el songSelectorTextBox
            songSelectorTextBox.AppendText("5" + Environment.NewLine);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Escribir un 6 en el songSelectorTextBox
            songSelectorTextBox.AppendText("6" + Environment.NewLine);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Escribir un 7 en el songSelectorTextBox
            songSelectorTextBox.AppendText("7" + Environment.NewLine);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Escribir un 8 en el songSelectorTextBox
            songSelectorTextBox.AppendText("8" + Environment.NewLine);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Escribir un 9 en el songSelectorTextBox
            songSelectorTextBox.AppendText("9" + Environment.NewLine);  
        }

        private void button0_Click(object sender, EventArgs e)
        {
            // Escribir un 0 en el songSelectorTextBox
            songSelectorTextBox.AppendText("0" + Environment.NewLine);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Obtener todas las líneas no vacías
            var lines = songSelectorTextBox.Text
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length == 0)
            {
                statusTextBox.Text = "No se ha seleccionado ninguna canción." + Environment.NewLine;
                return;
            }

            // Tomar la última línea no vacía como el número de canción
            string input = lines[lines.Length - 1].Trim();

            int index;
            if (int.TryParse(input, out index))
            {
                // El usuario ingresa 1 para la primera canción, etc.
                if (index >= 1 && index <= musicComboBox.Items.Count)
                {
                    musicComboBox.SelectedIndex = index - 1;
                    statusTextBox.Text = "Canción seleccionada: " + musicComboBox.Items[index - 1].ToString() + Environment.NewLine;
                }
                else
                {
                    statusTextBox.Text = "Índice fuera de rango. Selecciona un número válido." + Environment.NewLine;
                    return;
                }
            }
            else
            {
                statusTextBox.Text = "Entrada inválida. Ingresa solo números." + Environment.NewLine;
                return;
            }

            // Inhabilitar los botones del button0 a button9
            for (int i = 0; i <= 9; i++)
            {
                Button button = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Enabled = false; // Deshabilitar el botón
                    button.BackColor = Color.LightGray;
                }
            }
            // Habilitar el botón de limpiar
            clearButton.Enabled = true; // Habilitar el botón de limpiar
        }



        private void clearButton_Click(object sender, EventArgs e)
        {
            songSelectorTextBox.Text = ""; // Limpiar el TextBox de selección de canción
                                           // Habilitar los botones del button0 a button9
                                           // Inhabilitar los botones del button0 a button9
            for (int i = 0; i <= 9; i++)
            {
                Button button = this.Controls.Find("button" + i, true).FirstOrDefault() as Button;
                if (button != null)
                {
                    button.Enabled = true; // Deshabilitar el botón
                    button.BackColor = SystemColors.Control; // Restaurar el color de fondo original
                }
            }
        }
    }
}