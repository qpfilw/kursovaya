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
    public partial class Window1 : Window
    {
        private List<Policlinic> policlinics;
        private List<Doctor> doctors;
        private List<string> data = new List<string>();
        public Window1()
        {
            InitializeComponent();
            LoadData();
            UpdateComboBoxes();

        }

        private void policlinic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int selectedIndex = policlinicComboBox.SelectedIndex;
            doctorComboBox.Items.Clear();

            if (selectedIndex >= 0 && selectedIndex < policlinics.Count)
            {
                var selectedPoliclinic = policlinics[selectedIndex];
                foreach (var doctor in selectedPoliclinic.Doctors)
                {
                    doctorComboBox.Items.Add(doctor.NameSpecialization);
                }
            }
            else
            {
                MessageBox.Show("Неправильный выбор поликлиники");
            }
        }

        private void doctor_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            serviceComboBox.Items.Clear(); 
            timeComboBox.Items.Clear(); 
            string selectedValue = doctorComboBox.SelectedValue as string;
            foreach (var hospital in policlinics)
            {
                foreach (var doctor in hospital.Doctors)
                {
                    if (doctor.NameSpecialization == selectedValue)
                    {
                        foreach (var val in doctor.Service)
                            serviceComboBox.Items.Add(val);

                        foreach (var val in doctor.AvailableDays)
                            timeComboBox.Items.Add(val);
                    }
                }
            }
        }

        private void PaymentButton(object sender, RoutedEventArgs e)
        {
            string[] str = PatientFullName.Text.Split(' ');
            str = str.Where(val => val != "").ToArray();
            if (str.Length == 3 || (str.Length == 2 && MiddleName.IsChecked == true))
            {
                if (policlinicComboBox.SelectedItem != null && doctorComboBox.SelectedItem != null
                    && serviceComboBox.SelectedItem != null && timeComboBox.SelectedItem != null)
                {
                    DownloadData(PatientFullName.Text);
                    Window2_PaymentInformation pay = new Window2_PaymentInformation(data);
                    pay.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Выберите все данные");
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели все данные");
            }
        }

        private void DownloadData(string fio)
        {
            data.Add(fio);
            data.Add(policlinicComboBox.SelectedValue as string);
            data.Add(doctorComboBox.SelectedValue as string);
            data.Add(serviceComboBox.SelectedValue as string);
            data.Add(timeComboBox.SelectedValue as string);
        }

        private void LoadData()
        {
            try
            {
                string json = File.ReadAllText("policlinics.json");
                policlinics = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Policlinic>>(json);
                
                doctors = new List<Doctor>(); // Создать новый список докторов
                foreach (var policlinic in policlinics)
                {
                    doctors.AddRange(policlinic.Doctors);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void UpdateComboBoxes()
        {
            policlinicComboBox.Items.Clear();
            foreach (var policlinic in policlinics)
            {
                policlinicComboBox.Items.Add(policlinic.Name);
            }
        }
    }
}