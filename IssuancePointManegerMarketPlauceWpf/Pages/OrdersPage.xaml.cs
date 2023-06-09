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
using IssuancePointManegerMarketPlauceWpf.Models;
using IssuancePointManegerMarketPlauceWpf.Pages;


namespace IssuancePointManegerMarketPlauceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            OrderLw.ItemsSource = App.db.Order.Where(x => x.Useer1.Id == HelpClass.AutoUset.Id).ToList();
           
        
        }

        private void EditStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            var orders = (sender as Button).DataContext as Order;
            new EditOrderWindow(orders).ShowDialog();   
        }
    }
}
