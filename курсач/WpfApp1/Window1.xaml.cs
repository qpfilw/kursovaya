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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string[] policlinicsName;
        string[] doctorsName;
        //string[] timeDate;

        private string timeFile = "C:\\Users\\user\\OneDrive\\Рабочий стол\\kursovaya\\курсач\\time.txt";
        private List<string> availableTimes;

        public Window1()
        {
            InitializeComponent();
            policlinicsName = File.ReadAllLines("C:\\Users\\user\\OneDrive\\Рабочий стол\\kursovaya\\курсач\\policlinic\\policlinic.txt");

            foreach (string policlinics in policlinicsName)
            {
                policlinic.Items.Add(policlinics);
            }

            availableTimes = LoadTimesFromFile();
            UpdateComboBox();
        }

        private void policlinic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doctor.Items.Clear();

            switch (policlinic.SelectedIndex)
            {
                case 0:
                    doctorsName = File.ReadAllLines(@"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\doctors\doctors1.txt");
                    break;
                case 1:
                    doctorsName = File.ReadAllLines(@"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\doctors\doctors2.txt");
                    break;
                case 2:
                    doctorsName = File.ReadAllLines(@"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\doctors\doctors3.txt");
                    break;
                case 3:
                    doctorsName = File.ReadAllLines(@"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\doctors\doctors4.txt");
                    break;
                case 4:
                    doctorsName = File.ReadAllLines(@"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\doctors\doctors5.txt");
                    break;
                default:
                    MessageBox.Show("Неправильный выбор поликлиники");
                    return;
            }
            foreach (string doctors in doctorsName)
            {
                doctor.Items.Add(doctors);
            }
        }

        private void doctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            service.Items.Clear();

            string selectedDoctorFile = "";

            switch (policlinic.SelectedIndex)
            {
                case 0:
                    selectedDoctorFile = @"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\service.txt";
                    break;
                case 1:
                    selectedDoctorFile = @"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\service.txt";
                    break;
                case 2:
                    selectedDoctorFile = @"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\service.txt";
                    break;
                case 3:
                    selectedDoctorFile = @"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\service.txt";
                    break;
                case 4:
                    selectedDoctorFile = @"C:\Users\user\OneDrive\Рабочий стол\kursovaya\курсач\service.txt";
                    break;
                default:
                    MessageBox.Show("Неправильный выбор поликлиники");
                    return;
            }

            if (File.Exists(selectedDoctorFile))
            {
                string[] services = File.ReadAllLines(selectedDoctorFile);
                foreach (string serviceLine in services)
                {
                    service.Items.Add(serviceLine);
                }
            }
            else
            {
                MessageBox.Show("Файл с услугами врача не найден");
            }
        }

        private List<string> LoadTimesFromFile()
        {
            List<string> times = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(timeFile);
                times.AddRange(lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при чтении файла: " + ex.Message);
            }
            return times;
        }

        private void UpdateComboBox()
        {
            time.ItemsSource = availableTimes;
        }

        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (time.SelectedItem != null)
            {
                string selectedTime = time.SelectedItem.ToString();
                availableTimes.Remove(selectedTime);
                UpdateComboBox();
                SaveTimesToFile();
            }
        }

        private void SaveTimesToFile()
        {
            try
            {
                string[] timesArray = availableTimes.ToArray();
                File.WriteAllLines(timeFile, timesArray);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при записи файла: " + ex.Message);
            }
        }

        private void PaymentButton(object sender, RoutedEventArgs e)
        {
            Window2_PaymentInformation window2_PaymentInformation = new Window2_PaymentInformation();
            window2_PaymentInformation.Show();
            this.Close();
        }


    }
}


