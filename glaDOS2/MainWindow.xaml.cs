using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Speech.Synthesis;
using glaDOS2.Properties;


namespace glaDOS2
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cargar_voz();
            Cargar_archivos();

            
           
        }

        SpeechSynthesizer asistente = new SpeechSynthesizer(); 

        void Cargar_voz()
        {
            foreach (InstalledVoice voces in asistente.GetInstalledVoices())
            {
                cbVasi.Items.Add(voces.VoiceInfo.Name);
            }
        }

        void Cargar_archivos()
        {
            cbVasi.Text= Settings.Default.Voz;
            usu.Text = Settings.Default.NombreU;
            asi.Text = Settings.Default.NombreA;
            ciu.Text = Settings.Default.CodigoC;
            opa.Value = Settings.Default.Opacidad;
            confi.Value = Settings.Default.Confidencia;
        }


































































































        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Settings.Default.mnB = false;
            this.Close();
            
        }













        bool minimized;
        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if(minimized==false)
            {
                WindowState = WindowState.Maximized;
                minimized = true;
            }
            else
            {
                WindowState = WindowState.Normal;
                minimized = false;
            }
        }

        private void Image_TouchDown(object sender, TouchEventArgs e)
        {

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CiudadB_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Confidencia = 0.2;
            Settings.Default.Save();
            System.Diagnostics.Process.Start("https://www.weather.com/");
        }

        private void CbVasi_DropDownClosed(object sender, EventArgs e)
        {
            if(cbVasi.Text != Settings.Default.Voz)
            {
                Settings.Default.Voz = cbVasi.Text;
                asistente.SelectVoice(cbVasi.Text);
                asistente.SpeakAsync("Voz" + cbVasi.Text + "seleccionada con exito");
            }
            
        }

        private void Opa_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
    }
}
