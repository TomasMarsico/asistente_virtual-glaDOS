using System;
using System.IO.Ports;
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

namespace Control_Luminico
{
    class ConexionSerial
    {
        public static SerialPort serial;
        public static bool Conectado = false;

        public static void RefrescarPuertos(ComboBox cBox)
        {
            string[] PuertosDisponibles = SerialPort.GetPortNames();
            cBox.Items.Clear();
            foreach (string puertos in PuertosDisponibles)
            {
                cBox.Items.Add(puertos);
            }
        }

        public static void Conectar(string COM, int BaudRate)
        {
            serial = new SerialPort(COM)
            {
                BaudRate = BaudRate,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                PortName = COM
            };

            try
            {
                    serial.Open();
                    Conectado = serial.IsOpen;
                    Conectado = true;
            }
            catch (FormatException)
            {
                throw;
            }
        }

        public static void Desconectar()
        {
            serial.Close();
            Conectado = false;
        }

        public static void Enviar(string color)
        {
            try
            {
                serial.DiscardInBuffer();
                serial.Write(color);
            }
            catch (FormatException)
            {
                throw;
            }
        }
    }
}
