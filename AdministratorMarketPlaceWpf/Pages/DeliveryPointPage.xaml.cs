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
    /// Логика взаимодействия для DeliveryPointPage.xaml
    /// </summary>
    public partial class DeliveryPointPage : Page
    {
        public DeliveryPointPage()
        {
            InitializeComponent();
            DeliveryPointDt.ItemsSource = App.db.DeliveryPoint.ToList();
        }

        private void EditDelivpointBtn_Click(object sender, RoutedEventArgs e)
        {
            var point = (sender as Button).DataContext as DeliveryPoint;
            var dialog = new AddDeliveryPointWindow(point).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        private void DeletDeliveryPointBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as DeliveryPoint;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.DeliveryPoint.Remove(em);
            App.db.SaveChanges();
            Reshres();
        }
        public void Reshres()
        {
            IEnumerable<DeliveryPoint> Deliverypoint = App.db.DeliveryPoint.ToList();
            if (PoistTb.Text.Length > 0)
            {
                Deliverypoint = Deliverypoint.Where(z => z.Adress.StartsWith(PoistTb.Text));
            }
            DeliveryPointDt.ItemsSource = Deliverypoint.ToList();
        }
        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDeliveryPointWindow(new DeliveryPoint()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        private void PoistTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }
    }
}
