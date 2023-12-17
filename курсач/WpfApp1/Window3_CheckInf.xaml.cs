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
    public partial class Window3_CheckInf : Window
    {
        private TextBox PatientFullName_Inf;
        private TextBox Policlinic_Inf;
        private TextBox Doctor_Inf;
        private TextBox Service_Inf;
        private TextBox DateTime_Inf;

        public Window3_CheckInf()
        {
            InitializeComponent();

            // Инициализация TextBox полей
            PatientFullName_Inf = new TextBox();
            Policlinic_Inf = new TextBox();
            Doctor_Inf = new TextBox();
            Service_Inf = new TextBox();
            DateTime_Inf = new TextBox();
        }

        private void CheckInf_Button_Click(object sender, RoutedEventArgs e)
        {
            string patientLastName = FullName_CheckInf.Text; // Получаем фамилию пациента из TextBox

            DataLoader dataLoader = new DataLoader();
            dataLoader.LoadDataByPatientName(patientLastName, new TextBox[] { PatientFullName_Inf, Policlinic_Inf, Doctor_Inf,
            Service_Inf, DateTime_Inf});

            // Открытие Window4
            Window4_ShowInf window4 = new Window4_ShowInf
            {
                DataContext = this.DataContext // Передача модели представления второй странице
            };

            // Передача данных в Window4
            window4.FillTextBoxes(PatientFullName_Inf.Text, Policlinic_Inf.Text, Doctor_Inf.Text, Service_Inf.Text, DateTime_Inf.Text);

            window4.Show();
            this.Close();
        }
    }    
}


