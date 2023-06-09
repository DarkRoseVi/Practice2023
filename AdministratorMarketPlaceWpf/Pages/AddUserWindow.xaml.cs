using AdministratorMarketPlaceWpf.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace AdministratorMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public Useer contextUser;
        public AddUserWindow(Useer users)
        {
            InitializeComponent();
            RoleCb.ItemsSource = App.db.Role.ToList();
            contextUser = users;
            DataContext = contextUser;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextUser.Photo = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextUser;
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextUser.Name))
            {
                MessageBox.Show("Fill in the Name field");
            }
            else if (string.IsNullOrEmpty(contextUser.LastName))
                MessageBox.Show("Fill in the Last Name field");
            else if (string.IsNullOrEmpty(contextUser.SurName))
                MessageBox.Show("fill in the Surname field");
            else if (string.IsNullOrEmpty(contextUser.Login))
                MessageBox.Show("Fill in the Login field");
            else if (string.IsNullOrEmpty(contextUser.Password))
                MessageBox.Show("Fill in the Password field");
            else if (contextUser.Role == null)
                MessageBox.Show("Choose a role");
            else
            {
                if (contextUser.Id == 0)
                {

                    App.db.Useer.Add(contextUser);
                }
                MessageBox.Show("Saved");
                App.db.SaveChanges();
                DialogResult = true;
            }
         
        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text,0)) 
            {
                e.Handled = true;
            }
        }

     

        private void NameTb_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SurNameTb_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) 
            {
                e.Handled = true;
            }
        }
    }
    
}
