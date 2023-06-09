using ClientMarketPlaceWpf.Models;
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
using ClientMarketPlaceWpf.Pages;
using ClientMarketPlaceWpf.Models;

namespace ClientMarketPlaceWpf.Pages
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
            if (NameTb.Text.Length > 0)
            {

                if (LastNameTb.Text.Length>0)
                {
                    if (SurnameTb.Text.Length>0) 
                    {
                        if (LoginTb.Text.Length>0 )
                        {
                            if (PasswordTb.Password.Length > 0 )
                            {
                                if (PasswordTb2.Password.Length > 0 )
                                {

                                    string login = LoginTb.Text.Trim();
                                    string password = PasswordTb.Password.Trim();
                                    string password2 = PasswordTb2.Password.Trim();

                                    if (password == password2)
                                    {
                                        if (App.db.Useer.Local.Any(x => x.Login == login && x.Password == password && x.Password == password2))
                                        {
                                            MessageBox.Show("such user exists");
                                        }
                                        else
                                        {
                                            App.db.Useer.Add(new Useer
                                            {
                                                Password = password,
                                                Login = login,
                                                Name = NameTb.Text.Trim(),
                                                LastName = LastNameTb.Text.Trim(),
                                                SurName = SurnameTb.Text.Trim(),
                                            });
                                            App.db.SaveChanges();
                                            MessageBox.Show("Welcome");
                                            NavigationService.Navigate(new AutoPage());
                                        }
                                    }
                                    else MessageBox.Show("Password mismatch");
                     
                                }
                                else MessageBox.Show("Fill in the Password 2 field");
                            }
                            else MessageBox.Show("Fill in the Password field");
                        }
                        else MessageBox.Show("Fill in the Login field");
                    }
                    else MessageBox.Show("Fill in the Surname field");
                }
                else MessageBox.Show("Fill in the Last Name field");
            }
            else MessageBox.Show("Fill in the Name field");

        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void LastNameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void SurnameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
