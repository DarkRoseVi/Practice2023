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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            var contextorders = App.db.Order;
            OrderLw.ItemsSource = contextorders.ToList();
        }


        public void Reshres() 
        {
            OrderLw.ItemsSource = App.db.Order.ToList();
        }
        private void EditStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            var ord = (sender as Button).DataContext as Order;
            var dialog = new EditOrderPageWindow(ord).ShowDialog();
            if(dialog.HasValue && dialog.Value)
                Reshres();
               
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var em = (sender as Button).DataContext as Order;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.Order.Remove(em);
            App.db.SaveChanges();
            Reshres();
        }
    }
}
