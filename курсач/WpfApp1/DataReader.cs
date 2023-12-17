using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{

    public class DataLoader
    {
        private string filePath = "saved.txt";

        public void LoadDataByPatientName(string patientLastName, TextBox[] textboxes)
        {
            // Чтение данных из файла
            List<string> lines = File.ReadAllLines(filePath).ToList();

            // Поиск соответствующих строк
            List<string> matchingData = lines.Where(line => line.StartsWith(patientLastName)).ToList();

            if (matchingData.Count > 0)
            {
                // Берем первую строку, но вы можете рассмотреть другие варианты
                string patientData = matchingData[0];

                // Разделение данных на поля
                string[] data = patientData.Split(';');

                if (textboxes.Length == data.Length)
                {
                    // Заполнение TextBox'ов значениями из найденных данных
                    for (int i = 0; i < textboxes.Length; i++)
                    {
                        textboxes[i].Text = data[i];
                    }
                }
                else
                {
                    MessageBox.Show("Некорректные данные в файле.");
                }
            }
            else
            {
                MessageBox.Show("Пациент не найден.");
            }
        }
    }
}


    //public class DataLoader
    //{
    //    private string filePath = "saved.txt";

    //    public void LoadDataByPatientName(string patientLastName, ComboBox FullName_CheckInf)
    //    {
    //        try
    //        {
    //            List<string> matchingLines = new List<string>();

    //            using (StreamReader reader = new StreamReader(filePath))
    //            {
    //                string line;

    //                while ((line = reader.ReadLine()) != null)
    //                {
    //                    string[] data = line.Split(';');

    //                    if (data.Length >= 4 && data[0] == patientLastName)
    //                    {
    //                        matchingLines.Add(line);
    //                    }
    //                }
    //            }

    //            FillComboBox(matchingLines, FullName_CheckInf);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"An error occurred while loading the data: {ex.Message}");
    //        }
    //    }

    //    private void FillComboBox(List<string> lines, ComboBox comboBox)
    //    {
    //        comboBox.Items.Clear();

    //        foreach (string line in lines)
    //        {
    //            string[] data = line.Split(';');

    //            if (data.Length >= 6)
    //            {
    //                string fullName = data[0];
    //                string clinic = data[1];
    //                string doctor = data[2];
    //                string service = data[3];
    //                string date = data[4];
    //                string totalAmount = data[5];

    //                string comboBoxItem = $"{fullName}, {clinic}, {doctor}, {service}, {date}, {totalAmount}";
    //                comboBox.Items.Add(comboBoxItem);
    //            }
    //        }
    //    }
    //}

    //internal class DataReader
    //{
    //    private string filePath = "saved.txt";

    //    public DataReader(string filePath)
    //    {
    //        this.filePath = filePath;
    //    }

    //    public List<Dictionary<string, string>> ReadData(string[] value, string fio)
    //    {
    //        List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();


    //        try
    //        {
    //            using (StreamReader reader = new StreamReader(filePath))
    //            {
    //                string line;
    //                Dictionary<string, string> record = null;

    //                while ((line = reader.ReadLine()) != null)
    //                {
    //                    string[] parts = line.Split(';');
    //                    if (parts.Length == 5)
    //                    {
    //                        string key = parts[0].Trim();
    //                        value[0] = parts[1].Trim();
    //                        value[1] = parts[2].Trim();
    //                        value[2] = parts[3].Trim();
    //                        value[3] = parts[4].Trim();

    //                        if (key == fio)
    //                        {
    //                            // Создаем новую запись
    //                            record = new Dictionary<string, string>();
    //                            records.Add(record);
    //                        }

    //                        // Добавляем значения в текущую запись
    //                       /* if (record != null)
    //                        {
    //                            record[key] = value[];
    //                        }*/
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"An error occurred while reading the data: {ex.Message}");
    //        }

    //        return records;
    //    }
    //}
