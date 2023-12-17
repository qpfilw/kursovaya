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

