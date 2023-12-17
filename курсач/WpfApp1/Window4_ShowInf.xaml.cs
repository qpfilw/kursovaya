using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Window4_ShowInf.xaml
    /// </summary>
    public partial class Window4_ShowInf : Window
    {
        public Window4_ShowInf()
        {
            InitializeComponent();
        }

        public void FillTextBoxes(string fullName, string clinic, string doctor, string service, string date)
        {
            PatientFullName_Inf.Text = fullName;
            Policlinic_Inf.Text = clinic;
            Doctor_Inf.Text = doctor;
            Service_Inf.Text = service;
            DateTime_Inf.Text = date;
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
