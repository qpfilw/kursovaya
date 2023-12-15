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
        private double viewCost = 1000;
        private double visioncheckCost = 7000;
        private double statementglassesCost = 6000;
        private double eyesurgeryCost = 100000;
        private double otitCost = 4000;
        private double cleanupCost = 1500;
        private double referenceCost = 300;
        private double colonoscopyCost = 7500;  


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
            SaveData(information);
            File.WriteAllText(filePath, updatedJson);
            MessageBox.Show("Вы успешно записались на прием");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
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

        private void SaveData(List<string> information)
        {
            string filePath = "saved.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    string data = string.Empty;
                    for (int i = 0; i < information.Count; i++)
                    {
                        data += information[i];
                        if (i < information.Count - 1)
                        {
                            data += ";";
                        }
                    }
                    writer.WriteLine(data);
                }

                Console.WriteLine("Данные успешно сохранены");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в сохранении информации: {ex.Message}");
            }
        }

        private void LoadPay()
        {
            if (information[3] == "Операция")
                FinalSum.Text = operationCost.ToString();
            else if (information[3] == "Консультация")
                FinalSum.Text = consultationCost.ToString();
            else if (information[3] == "Прием")
                FinalSum.Text = priemCost.ToString();
            else if (information[3] == "Осмотр")
                FinalSum.Text = viewCost.ToString();
            else if (information[3] == "Проверка зрения")
                FinalSum.Text = visioncheckCost.ToString();
            else if (information[3] == "Выписка очков")
                FinalSum.Text = statementglassesCost.ToString();
            else if (information[3] == "Операция на улучшение зрения")
                FinalSum.Text = eyesurgeryCost.ToString();
            else if (information[3] == "Лечение отита")
                FinalSum.Text = otitCost.ToString();
            else if (information[3] == "Чистка ушной серы")
                FinalSum.Text = cleanupCost.ToString();
            else if (information[3] == "Выписка справки")
                FinalSum.Text = referenceCost.ToString();
            else if (information[3] == "Колоноскопия")
                FinalSum.Text = colonoscopyCost.ToString();
        }
    }
}
