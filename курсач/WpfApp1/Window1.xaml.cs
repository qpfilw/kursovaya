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
using System.Xml.Linq;

namespace WpfApp1
{
    public partial class Window1 : Window
    {
        private List<Policlinic> policlinics;
        private List<Doctor> doctors;
        private string timeFile = "time.txt";
        private List<string> availableTimes;
        private User user;

        public Window1()
        {
            InitializeComponent();
            LoadPoliclinics();
            LoadDoctors();
            availableTimes = LoadTimesFromFile();
            UpdateComboBox();
            user = new User();
        }

        private void LoadPoliclinics()
        {
            policlinics = new List<Policlinic>();

            string[] policlinicNames = File.ReadAllLines("policlinic.txt");
            foreach (string policlinicName in policlinicNames)
            {
                policlinics.Add(new Policlinic(policlinicName));
                policlinic.Items.Add(policlinicName);
            }
        }

        private void LoadDoctors()
        {
            doctors = new List<Doctor>();

            string[] doctors1 = File.ReadAllLines("doctors1.txt");
            string[] doctors2 = File.ReadAllLines("doctors2.txt");
            string[] doctors3 = File.ReadAllLines("doctors3.txt");
            string[] doctors4 = File.ReadAllLines("doctors4.txt");
            string[] doctors5 = File.ReadAllLines("doctors5.txt");

            doctors.Add(new Doctor("Doctor 1", doctors1));
            doctors.Add(new Doctor("Doctor 2", doctors2));
            doctors.Add(new Doctor("Doctor 3", doctors3));
            doctors.Add(new Doctor("Doctor 4", doctors4));
            doctors.Add(new Doctor("Doctor 5", doctors5));
        }

        private void policlinic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doctor.Items.Clear();

            int selectedIndex = policlinic.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < policlinics.Count)
            {
                Policlinic selectedPoliclinic = policlinics[selectedIndex];
                string[] doctorNames = selectedPoliclinic.GetDoctorNames();

                foreach (string doctorName in doctorNames)
                {
                    doctor.Items.Add(doctorName);
                }
            }
            else
            {
                MessageBox.Show("Неправильный выбор поликлиники");
            }
        }

        private void doctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            service.Items.Clear();

            int policlinicIndex = policlinic.SelectedIndex;
            int doctorIndex = doctor.SelectedIndex;

            if (policlinicIndex >= 0 && policlinicIndex < policlinics.Count &&
                doctorIndex >= 0 && doctorIndex < doctors.Count)
            {
                Doctor selectedDoctor = doctors[doctorIndex];
                string[] services = selectedDoctor.GetServices();

                foreach (string serviceLine in services)
                {
                    service.Items.Add(serviceLine);
                }
            }
            else
            {
                MessageBox.Show("Неправильный выбор поликлиники или врача");
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
            if (!string.IsNullOrEmpty(patientFullName.Text))
            {
                user.Name = patientFullName.Text;

                Window2_PaymentInformation window2_PaymentInformation = new Window2_PaymentInformation(user);
                window2_PaymentInformation.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите ФИО пользователя");
            }
        }
    }

    public class Policlinic
    {
        public string Name { get; }
        private string[] doctorNames;

        public Policlinic(string name)
        {
            Name = name;
            doctorNames = new string[0];
        }

        public string[] GetDoctorNames()
        {
            return doctorNames;
        }
    }

    public class Doctor
    {
        public string Name { get; }
        private string[] services;

        public Doctor(string name, string[] services)
        {
            Name = name;
            this.services = services;
        }

        public string[] GetServices()
        {
            return services;
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}
