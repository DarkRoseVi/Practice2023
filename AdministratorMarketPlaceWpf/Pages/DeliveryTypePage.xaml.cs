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
    /// Логика взаимодействия для DeliveryTypePage.xaml
    /// </summary>
    public partial class DeliveryTypePage : Page
    {
        public DeliveryTypePage()
        {
            InitializeComponent();
            TypeProduct.ItemsSource = App.db.DeliveryType.ToList();
        }

        public void Reshres()
        {
            TypeProduct.ItemsSource = App.db.DeliveryType.ToList();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).DataContext as DeliveryType;
            var dialogResult = new AddDeliveryWindow(new DeliveryType()).ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
                Reshres();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as DeliveryType;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.DeliveryType.Remove(em);
            App.db.SaveChanges();
            TypeProduct.ItemsSource = App.db.DeliveryType.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).DataContext as DeliveryType;
            var dialogResult = new AddDeliveryWindow(type).ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
                Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TypeProduct.Items.Refresh();
        }
    }
}
