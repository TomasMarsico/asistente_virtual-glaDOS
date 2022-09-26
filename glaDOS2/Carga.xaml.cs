using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace glaDOS2
{
    /// <summary>
    /// Interaction logic for Carga.xaml
    /// </summary>
    public partial class Carga : Window
    {

        BackgroundWorker bw = new BackgroundWorker();

        public Carga()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            bw.WorkerReportsProgress = true;
            bw.DoWork += Bw_DoWork1;
            bw.ProgressChanged += Bw_ProgressChanged1;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted1;
            bw.RunWorkerAsync();
        }

        private void Bw_RunWorkerCompleted1(object sender, RunWorkerCompletedEventArgs e)
        {
            Asistente asi = new Asistente();
            asi.Show();
            this.Close();

        }

        private void Bw_ProgressChanged1(object sender, ProgressChangedEventArgs e)
        {
            Barrita1.Value = e.ProgressPercentage;
            Barrita2.Value = e.ProgressPercentage;
        }

        private void Bw_DoWork1(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 101; i++)
            {
                Thread.Sleep(10);
                bw.ReportProgress(i);
            }
        }
    }
}
