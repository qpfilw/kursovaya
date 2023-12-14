using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2_PaymentInformation.xaml
    /// </summary>
    public partial class Window2_PaymentInformation : Window
    {
        private double operationCost = 5000;
        private double consultationCost = 500;
        private double priemCost = 1000;

        private List<string> information;
        public Window2_PaymentInformation(List<string> data)
        {
            information = data;
            InitializeComponent();
            LoadData();
        }

        private void ToPay(object sender, RoutedEventArgs e)
        {
            string filePath = "policlinics.json";

            string json = File.ReadAllText(filePath);

            List<JObject> hospitals = JsonConvert.DeserializeObject<List<JObject>>(json);

            string hospitalName = Policlinic_PaymentInf.Text.ToString(); 
            string doctorName = Doctor_PaymentInf.Text.ToString();
            string dayToDelete = DateTime_PaymentInf.Text.ToString();

            JObject hospital = hospitals.FirstOrDefault(h => h["Name"].ToString() == hospitalName);
            if (hospital != null)
            {
                JToken doctor = hospital["Doctors"].FirstOrDefault(d => d["NameSpecialization"].ToString() == doctorName);
                if (doctor != null)
                {
                    JArray availableDays = (JArray)doctor["AvailableDays"];
                    if (availableDays != null)
                    {
                        JToken day = availableDays.FirstOrDefault(d => d.ToString() == dayToDelete);
                        if (day != null)
                        {
                            day.Remove();
                        }
                    }
                }
            }

            string updatedJson = JsonConvert.SerializeObject(hospitals, Formatting.Indented);

            File.WriteAllText(filePath, updatedJson);
            MessageBox.Show("Вы успешно записались на прием");
            this.Close();
        }

        private void PatientFullName_PaymentInf_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Service_PaymentInf_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void LoadData()
        {
            PatientFullName_PaymentInf.Text = (string)information[0];
            Policlinic_PaymentInf.Text = (string)information[1];
            Doctor_PaymentInf.Text = (string)information[2];
            Service_PaymentInf.Text = (string)information[3];
            DateTime_PaymentInf.Text = (string)information[4];
            LoadPay();
        }

        private void LoadPay()
        {
            if (information[3] == "Операция")
                FinalSum.Text = operationCost.ToString();
            else if (information[3] == "Консультация")
                FinalSum.Text = consultationCost.ToString();
            else if (information[3] == "Приём")
                FinalSum.Text = priemCost.ToString();
        }


        
    }
}
