using AdministratorMarketPlaceWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministratorMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

 

        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Password2TB.Visibility = Visibility.Visible;
            Password2Pb.Visibility = Visibility.Collapsed;

            Password2TB.Text = new NetworkCredential(string.Empty, Password2Pb.SecurePassword).Password;
            Password2TB.Focus();

        }

        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Password2Pb.Visibility = Visibility.Visible;
            Password2TB.Visibility = Visibility.Collapsed;

            Password2TB.Text = "";
            Password2TB.Focus();
        }

        private void EntranceBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = Password2Pb.Password.Trim();
            string password2 = Password2TB.Text.Trim();
            if (login.Length > 0 && password.Length > 0)
            {
                var user = App.db.Useer.Where(x => (x.Login == login && x.Password == password) || (x.Login == login && x.Password == password2)).FirstOrDefault();
                if (user != null && user.RoleId == 1)
                {
                    HelpClass.AutoUser = user;
                    NavigationService.Navigate(new HomePage());
                }
                else MessageBox.Show("You do not have administrator rights");
            }
            else MessageBox.Show("Check completed fields");
        }

        private void Sce_Click(object sender, RoutedEventArgs e)
        {
            ShowPasswordCharsCheckBox.IsChecked = false;
        }

        private void Vid_Click(object sender, RoutedEventArgs e)
        {
            ShowPasswordCharsCheckBox.IsChecked = true;
        }
    }
}
