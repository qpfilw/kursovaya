using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window5_AddInf.xaml
    /// </summary>
    public partial class Window5_AddInf : Window
    {
        

        public Window5_AddInf()
        {
            InitializeComponent();
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            string selectedPoliclinic = Policlinic_Inf.Text;
            string doctorNameSpecialization = Doctor_Inf.Text;
            string doctorService = Service_Inf.Text;
            string doctorAvailableDay = DateTime_Inf.Text;

            AddInf.AddDoctorInformation(selectedPoliclinic, doctorNameSpecialization, doctorService, doctorAvailableDay);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
