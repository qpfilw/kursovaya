using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp1
{
    internal class Doctor
    {
        public string NameSpecialization { get; set; }

        public List<string> Service { get; set; }

        public List<string> AvailableDays { get; set; }
    }
}
