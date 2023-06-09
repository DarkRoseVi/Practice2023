using AdministratorMarketPlaceWpf.Models;
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

namespace AdministratorMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public ProviderPage()
        {
            InitializeComponent();
        }

        public void Reshres()
        {
            IEnumerable<Provider> providerlist = App.db.Provider.ToList() ;
            if (SortBtn.SelectedItem != null)
            {
                switch ((SortBtn.SelectedItem as ComboBoxItem).Tag) 
                {
                    case "1":
                        providerlist = App.db.Provider.ToList() ;
                        break;
                        case "2":
                        providerlist = providerlist.OrderBy(x=>x.Title);
                        break;  
                    case "3":
                        providerlist = providerlist.OrderByDescending(x=>x.Title);
                        break;
                }
            }
            if (PoistTb == null)
                return;
            if (PoistTb.Text.Length > 0)
            {
                providerlist = providerlist.Where(x => x.Title.ToLower().StartsWith(PoistTb.Text) || x.Adress.ToLower().StartsWith(PoistTb.Text));
            }
            ProviderDt.ItemsSource = providerlist.ToList();
        }
        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var provider = (sender as Button).DataContext as Provider;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.Provider.Remove(provider);
            }
            App.db.SaveChanges();
            Reshres();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var pro = (sender as Button).DataContext as Provider;
            var dialof = new AddProviderWindow(pro).ShowDialog();
            if (dialof.Value && dialof.HasValue)
                Reshres();

        }

        private void PoistTb_TextChanged(object sender, TextChangedEventArgs e)
        {
             Reshres();
        }

        private void SortBtn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshres();
        }

        private void AbbBtn_Click(object sender, RoutedEventArgs e)
        {
            var provider = new Provider();
            var dialof = new AddProviderWindow(provider).ShowDialog();
            if (dialof.HasValue && dialof.Value)
                Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }
    }
}
