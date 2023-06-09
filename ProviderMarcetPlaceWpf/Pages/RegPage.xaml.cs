using ProviderMarcetPlaceWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ProviderMarcetPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
          


            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            string password2 = PasswordTb2.Password.Trim();
            string title = TitleTb.Text.Trim();
            string aress = AdressTb.Text.Trim();
            if (title.Length > 0)
            {
                if (aress.Length > 0)
                {
                    if (login.Length > 0 && password.Length > 0 && password2.Length > 0)
                    {
                        if (password == password2)
                        {
                            if (App.db.Provider.Local.Any(x => x.Lodin == login && x.Password == password && x.Password == password2))
                            {
                                MessageBox.Show("such user exists");
                            }
                            else
                            {
                                App.db.Provider.Add(new Provider
                                {
                                    Password = password,
                                    Lodin = login,
                                    Title = TitleTb.Text.Trim(),
                                    Adress = AdressTb.Text.Trim(),

                                });
                                App.db.SaveChanges();
                                MessageBox.Show("Welcome");
                                NavigationService.Navigate(new AutoPage());
                            }
                        }
                        else MessageBox.Show("Password mismatch");
                    }
                    else MessageBox.Show("fill in the fields");
                }
                else MessageBox.Show("Fill in the address");
            }
            else MessageBox.Show("Fill in the name");
         

        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void LastNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SurnameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
