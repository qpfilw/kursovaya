using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfApp1
{
    public static class AddInf
    {
        private static List<Policlinic> policlinics;
        private const string jsonFilePath = "policlinics.json";

        // Метод для добавления информации о враче и поликлинике
        public static void AddDoctorInformation(string selectedPoliclinic, string doctorNameSpecialization, string doctorService, string doctorAvailableDay)
        {
            // Читаем JSON файл
            string json = File.ReadAllText(jsonFilePath);

            // Десериализуем JSON в список поликлиник
            policlinics = JsonConvert.DeserializeObject<List<Policlinic>>(json);

            // Проверяем, существует ли поликлиника с выбранным названием
            Policlinic existingPoliclinic = policlinics.Find(p => p.Name == selectedPoliclinic);
            if (existingPoliclinic != null)
            {
                // Проверяем, существует ли врач с указанной специализацией
                Doctor existingDoctor = existingPoliclinic.Doctors.Find(d => d.NameSpecialization == doctorNameSpecialization);
                if (existingDoctor != null)
                {
                    // Если врач существует, добавляем новые услуги и доступные даты
                    if (!existingDoctor.Service.Contains(doctorService))
                    {
                        existingDoctor.Service.Add(doctorService);
                    }

                    if (!existingDoctor.AvailableDays.Contains(doctorAvailableDay))
                    {
                        existingDoctor.AvailableDays.Add(doctorAvailableDay);
                    }
                }
                else
                {
                    // Если врач не существует, создаем нового врача и добавляем его в поликлинику
                    Person newDoctor = new Doctor
                    {
                        NameSpecialization = doctorNameSpecialization,
                        Service = new List<string> { doctorService },
                        AvailableDays = new List<string> { doctorAvailableDay }
                    };

                    existingPoliclinic.Doctors.Add((Doctor)newDoctor);
                }
            }
            else
            {
                // Если поликлиника не существует, создаем новую поликлинику и добавляем в нее нового врача
                Policlinic newPoliclinic = new Policlinic
                {
                    Name = selectedPoliclinic,
                    Doctors = new List<Doctor>()
                };

                Doctor newDoctor = new Doctor
                {
                    NameSpecialization = doctorNameSpecialization,
                    Service = new List<string> { doctorService },
                    AvailableDays = new List<string> { doctorAvailableDay }
                };

                newPoliclinic.Doctors.Add(newDoctor);

                policlinics.Add(newPoliclinic);
            }

            // Сериализуем список поликлиник обратно в JSON
            string updatedJson = JsonConvert.SerializeObject(policlinics, Formatting.Indented);

            // Записываем обновленный JSON файл
            File.WriteAllText(jsonFilePath, updatedJson);

            // Показываем сообщение об успешном добавлении информации
            MessageBox.Show("Информация успешно добавлена!");


        }
    }
}
