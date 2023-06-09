﻿using ClientMarketPlaceWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditInfoWindow.xaml
    /// </summary>
    public partial class EditInfoWindow : Window
    {
        public static Useer contextuser;
        public EditInfoWindow(Useer user)
        {
            InitializeComponent();
            contextuser = user;
            DataContext = contextuser;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
            DialogResult = true;    
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddImageWindow(contextuser).ShowDialog();
      
        }
    }
}
