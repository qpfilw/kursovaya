using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для Window2_PaymentInformation.xaml
    /// </summary>
    public partial class Window2_PaymentInformation : Window
    {
        public Window2_PaymentInformation()
        {
            InitializeComponent();
        }

        private void ToPay(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы успешно записались на прием");
            this.Close();
        }

        private void PatientFullName_PaymentInf_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Service_PaymentInf_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        
    }
}
