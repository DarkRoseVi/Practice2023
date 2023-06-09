using IssuancePointManegerMarketPlauceWpf.Models;
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
using System.Windows.Shapes;

namespace IssuancePointManegerMarketPlauceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditOrderWindow.xaml
    /// </summary>
    public partial class EditOrderWindow : Window
    {
        public Order contextOrder;
        public EditOrderWindow(Order orders)
        {
            InitializeComponent();
            contextOrder = orders;
            DataContext = contextOrder;
            ProductLw.ItemsSource = App.db.ProductOrder.Where(x => x.OrderId == contextOrder.Id).ToList();
            if (contextOrder.TypePayment.Id == 1)
            {
                ChetSt.Visibility = Visibility.Visible;
            }
            else ChetSt.Visibility = Visibility.Collapsed;
            if (contextOrder.DeliveryTypeId == 1)
            {
                PointSt.Visibility = Visibility.Visible;
                DelSt.Visibility = Visibility.Collapsed;
            }
            else if(contextOrder.DeliveryTypeId == 2)
            {
                PointSt.Visibility = Visibility.Collapsed;
                DelSt.Visibility = Visibility.Visible;

            }
        }

   

  

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var prodorde = (sender as Button).DataContext as ProductOrder;
            var dialog = new EditStatysWindow(prodorde).ShowDialog();
            //if(dialog.HasValue && dialog.Value)
            //    re
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
