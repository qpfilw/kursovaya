﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton(object sender, RoutedEventArgs e)
        {
            Window1 registerToTheDoctor = new Window1();
            registerToTheDoctor.Show();
            this.Close();
        }

        private void CheckButton(object sender, RoutedEventArgs e)
        {
            Window3_CheckInf window3_CheckInf = new Window3_CheckInf();
            window3_CheckInf.Show();
            this.Close();
        }

        private void addInf_Click(object sender, RoutedEventArgs e)
        {
            Window5_AddInf window5_AddInf = new Window5_AddInf();
            window5_AddInf.Show();
            this.Close();
        }
    }
}
