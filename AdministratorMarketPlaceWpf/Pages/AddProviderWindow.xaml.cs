using AdministratorMarketPlaceWpf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using System.Windows.Shapes;

namespace AdministratorMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProviderWindow.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        public Provider contextProvider;
        
        public AddProviderWindow(Provider provider)
        {
            InitializeComponent();
            contextProvider = provider;
            DataContext = contextProvider;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextProvider.Title))
            {
                MessageBox.Show("Fill in the name");
                return;
            }
            else if (string.IsNullOrEmpty(contextProvider.Adress))
            {
                MessageBox.Show("Fill in the address");
                return;
            }
            else if (string.IsNullOrEmpty(contextProvider.Lodin))
            {
                MessageBox.Show("Fill in login");
                return;
            }
            else if (string.IsNullOrEmpty(contextProvider.Password))
            {
                MessageBox.Show("Fill in the password");
            }
            else if (string.IsNullOrEmpty(contextProvider.Descriprion))
            {
                MessageBox.Show("Fill in the description");
                return;
            }
            else 
            {

                if (contextProvider.Id == 0)
                {
                    App.db.Provider.Add(contextProvider);
                }
                MessageBox.Show("yes");
                App.db.SaveChanges();

            }
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
