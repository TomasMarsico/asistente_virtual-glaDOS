using System;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace glaDOS2
{
    public partial class Asistente : Window
    {
        SpeechSynthesizer asistente = new SpeechSynthesizer();
        SpeechRecognitionEngine reconocedor = new SpeechRecognitionEngine();

        string speech;

        public Asistente()
        {
            InitializeComponent();
            IniciodeGramaticas();

        }


        void IniciodeGramaticas()
        {
            reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"Comandos\Comandos.txt")))));
            reconocedor.RequestRecognizerUpdate();
            reconocedor.SpeechRecognized += Reconocedor_SpeechRecognized;
            asistente.SpeakStarted += Asistente_SpeakStarted;
            asistente.SpeakCompleted += Asistente_SpeakCompleted;
            reconocedor.AudioLevelUpdated += Reconocedor_AudioLevelUpdated;
            reconocedor.SetInputToDefaultAudioDevice();
            reconocedor.RecognizeAsync(RecognizeMode.Multiple);




        }
        int x;
        private void Reconocedor_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            naranja.Opacity = e.AudioLevel * 0.1;
            azul.Opacity = e.AudioLevel * 0.1;
            verde.Opacity = e.AudioLevel * 0.1;
            rojo.Opacity = e.AudioLevel * 0.1;
            amarillo.Opacity = e.AudioLevel * 0.1;
            rosa.Opacity = e.AudioLevel * 0.1;
            violeta.Opacity = e.AudioLevel * 0.1;
            blanco.Opacity = e.AudioLevel * 0.1;
            celeste.Opacity = e.AudioLevel * 0.1;

        }

        private void Asistente_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {

        }

        private void Asistente_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {

        }
        bool desactivado, colorP, apagando, algo;
        char color;
        private void Reconocedor_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            speech = e.Result.Text;

            if ((speech == "Desactivar microfono") && (desactivado == false))
            {
                desactivado = true;
                desactivadoI.Visibility = Visibility.Visible;
                activadoI.Visibility = Visibility.Hidden;
                asistente.SpeakAsync("Microfono desactivado con exito");
                dictado.Content = "Desactivado";

            }
            else if ((speech == "Activar microfono") && (desactivado == true))
            {
                desactivado = false;
                activadoI.Visibility = Visibility.Visible;
                desactivadoI.Visibility = Visibility.Hidden;
                asistente.SpeakAsync("Microfono activado con exito");
                dictado.Content = "Activado";


            }
            if ((apagando == true) && (speech == "Si") && (desactivado == false))
            {
                asistente.SpeakAsync("Genial, cerrando, adiós");
                dictado.Content = "Cerrando..";
                Thread.Sleep(2500);
                Application.Current.Shutdown();

            }
            if ((apagando == true) && (speech == "No") && (desactivado == false))
            {
                apagando = false;
                asistente.SpeakAsync("Continuaré con la aplicación");

            }
            if ((desactivado == false) && (apagando == false))
            {

                if (speech == "Prender luces en rojo")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                        
                            
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }

                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'R';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    rojo.Visibility = Visibility.Visible;
                    // dictado.Content = "";
                    colorP = true;
                }
                if (speech == "Prender luces en verde")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'V';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());

                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    verde.Visibility = Visibility.Visible;

                    Thread.Sleep(1000);
                    colorP = true;
                }
                if (speech == "Prender luces en azul")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'U';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    azul.Visibility = Visibility.Visible;
                    colorP = true;
                }

                if (speech == "Prender luces en violeta")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'X';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    violeta.Visibility = Visibility.Visible;
                    colorP = true;
                }
                if (speech == "Prender luces en blanco")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'Q';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    blanco.Visibility = Visibility.Visible;
                    colorP = true;
                }
                if (speech == "Apagar luz de techo")
                {
                    if (colorP == false)
                        asistente.SpeakAsync("Apagando");
                    Control_Luminico.ConexionSerial.Conectar("COM15", 9600);
                    color = 'A';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();

                }

                if (speech == "Prender luz de techo tres")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM15", 9600);
                    color = 'D';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    //dictado.Content = "";
                    colorP = true;
                }
                if (speech == "Prender luz de techo dos")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM15", 9600);
                    color = 'C';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    //dictado.Content = "";
                    colorP = true;
                }
                if (speech == "Prender luz de techo uno")
                {
                    dictado.Content = "Apagando";
                    Control_Luminico.ConexionSerial.Conectar("COM15", 9600);
                    color = 'F';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    //dictado.Content = "";
                    colorP = true;
                }
                if (speech == "Prender luces en naranja")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'N';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    //dictado.Content = "";
                    colorP = true;
                }
                if (speech == "Prender luces en celeste")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'K';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    celeste.Visibility = Visibility.Visible;
                    colorP = true;
                }
                if (speech == "Prender estands")
                {
                    asistente.SpeakAsync("Prendiendo");
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'E';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    dictado.Content = "Stands on";

                }
                if (speech == "Apagar estands")
                {
                    asistente.SpeakAsync("Apagando");
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = '1';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    dictado.Content = "Stands off";

                }
                if (speech == "Prender modo fiesta")
                {
                    asistente.SpeakAsync("Mandále mecha");
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'H';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    dictado.Content = "Kenai";
                }
                if (speech == "Prender luces en rosa")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'B';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    rosa.Visibility = Visibility.Visible;
                    colorP = true;
                }
                if (speech == "Prender luces en amarillo")
                {
                    if (colorP == false)
                    {
                        asistente.SpeakAsync("Prendiendo");
                        dictado.Content = "Prendiendo..";
                    }
                    else
                    {
                        asistente.SpeakAsync("Cambiando");
                        dictado.Content = "Cambiando..";
                    }
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'Y';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    colores();
                    amarillo.Visibility = Visibility.Visible;
                    colorP = true;
                }
                if (speech == "Prender ventilador")
                {
                    asistente.SpeakAsync("El ventilador esta desconectado");
                    dictado.Content = "Desconectado.";
                    //Control_Luminico.ConexionSerial.Conectar("COM14", 9600);
                    //color = 'A';
                    //Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    //Thread.Sleep(1000);
                    //Control_Luminico.ConexionSerial.Desconectar();
                    //dictado.Content = "";

                }
                if (speech == "Apagar ventilador")
                {
                    asistente.SpeakAsync("El ventilador esta desconectado");
                    dictado.Content = "Desconectado.";
                    //Control_Luminico.ConexionSerial.Conectar("COM14", 9600);
                    //color = 'P';
                    //Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    //Thread.Sleep(1000);
                    //Control_Luminico.ConexionSerial.Desconectar();
                    //dictado.Content = "";

                }

                if (speech == "Apagar luces")
                {
                    asistente.SpeakAsync("Apagando");
                    dictado.Content = "Apagando..";
                    Control_Luminico.ConexionSerial.Conectar("COM11", 9600);
                    color = 'A';
                    Control_Luminico.ConexionSerial.Enviar(color.ToString());
                    Thread.Sleep(1000);
                    Control_Luminico.ConexionSerial.Desconectar();
                    //dictado.Content = "";
                    colorP = false;

                }
                if (speech == "Cerrar aplicación")
                {
                    asistente.SpeakAsync("Esta seguro que desea apagar la aplicación?");
                    apagando = true;
                    dictado.Content = "Apagar?";

                }

                if (speech == "Hola")
                {
                    asistente.SpeakAsync("Buenos dias," + Properties.Settings.Default.NombreU);
                    dictado.Content = "Buenos dias.";
                    Thread.Sleep(1000);
                    //dictado.Content = "";
                }
                if (speech == "Como te llamas?")
                {
                    asistente.SpeakAsync("Me llamo " + Properties.Settings.Default.NombreA);
                    dictado.Content = "Buenos dias.";
                    Thread.Sleep(1000);
                    //dictado.Content = "";
                }
                if (speech == "Abrir el Google")
                {
                    System.Diagnostics.Process.Start("chrome.exe", "www.google.com");
                    asistente.SpeakAsync("Abriendo Google, que desea buscar?");
                    dictado.Content = "Que busca?";
                    Thread.Sleep(1000);
                    algo = true;
                    //dictado.Content = "";
                }
                if (speech == "Abre el Instagram")
                {
                    System.Diagnostics.Process.Start("chrome.exe", "www.instagram.com");
                    asistente.SpeakAsync("Abriendo Instagram");
                    dictado.Content = "Abriendo Instagram..";
                    Thread.Sleep(1000);
                    //dictado.Content = "";
                }
                if (speech == "Abre el YouTube")
                {
                    System.Diagnostics.Process.Start("chrome.exe", "www.youtube.com");
                    dictado.Content = "Abriendo Youtube..";
                    asistente.SpeakAsync("Abriendo Youtube");
                    Thread.Sleep(1000);
                    // dictado.Content = "";
                }
                if (speech == "Abre el Clima")
                {
                    System.Diagnostics.Process.Start("chrome.exe", "https://weather.com/es-AR/tiempo/hoy/l/" + Properties.Settings.Default.CodigoC);
                    asistente.SpeakAsync("Abriendo el clima en su ciudad");
                    dictado.Content = "Abriendo clima..";
                    Thread.Sleep(1000);
                    //dictado.Content = "";
                }
                if (speech == "Queres un mate?")
                {
                    asistente.SpeakAsync("Si, yo quiero mate también, , gil");
                    dictado.Content = "Que no?";
                    Thread.Sleep(1000);
                    //dictado.Content = "";
                }
            }
        }



        public void ConfigR_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            Properties.Settings.Default.mnB = true;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Properties.Settings.Default.asiB = true;
            asistente.SelectVoice(Properties.Settings.Default.Voz);
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (desactivado == false)
            {
                desactivado = true;
                desactivadoI.Visibility = Visibility.Visible;
                activadoI.Visibility = Visibility.Hidden;

                asistente.SpeakAsync("Microfono desactivado con exito");

            }
            else if (desactivado == true)
            {
                desactivado = false;
                activadoI.Visibility = Visibility.Visible;
                desactivadoI.Visibility = Visibility.Hidden;

                asistente.SpeakAsync("Microfono activado con exito");

            }
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void colores()
        {
            naranja.Visibility = Visibility.Hidden;
            azul.Visibility = Visibility.Hidden;
            verde.Visibility = Visibility.Hidden;
            rojo.Visibility = Visibility.Hidden;
            amarillo.Visibility = Visibility.Hidden;
            rosa.Visibility = Visibility.Hidden;
            violeta.Visibility = Visibility.Hidden;
            blanco.Visibility = Visibility.Hidden;
            celeste.Visibility = Visibility.Hidden;
        }




























































        private void Window_Initialized(object sender, EventArgs e)
        {
            colores();
            naranja.Visibility = Visibility.Visible;
            Properties.Settings.Default.mnB = false;
            Properties.Settings.Default.arB = false;
        }

        private void Fondo_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }



        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void ConfigR_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void ConfigR_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RadioButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void RadioButton_MouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.arB = true;
            Window1 menu = new Window1();
            menu.Show();

        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

            if (Properties.Settings.Default.mnB == true)
            {
                MessageBox.Show("La pestaña de configuración sigue abierta", "Cierre la pestaña y vuelva a intentar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (Properties.Settings.Default.arB == true)
            {
                MessageBox.Show("La pestaña menú de Arduino sigue abierta", "Cierre la pestaña y vuelva a intentar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                Application.Current.Shutdown();
            }

        }
    }
}
