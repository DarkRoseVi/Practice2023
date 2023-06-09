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
using System.Windows.Shapes;

namespace AdministratorMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditOrderPageWindow.xaml
    /// </summary>
    public partial class EditOrderPageWindow : Window
    {
        public Order contextOrder;
        public EditOrderPageWindow(Order orders)
        {
            InitializeComponent();
            DeliveryTypeCb.ItemsSource = App.db.DeliveryType.ToList();
            TypePaymentCb.ItemsSource = App.db.TypePayment.ToList();
            EmployeedelCb.ItemsSource = App.db.Useer.Where(x => x.RoleId == 2).ToList();

            DeliveryPointCb.ItemsSource = App.db.DeliveryPoint.ToList();
            List<StatysOrder> statys = App.db.StatysOrder.ToList();

            contextOrder = orders;
            DataContext = contextOrder;
            ProductLw.ItemsSource = App.db.ProductOrder.Where(x => x.OrderId == contextOrder.Id).ToList();
        }

         public void Reshres() 
        {
            ProductLw.ItemsSource = App.db.ProductOrder.Where(x => x.OrderId == contextOrder.Id).ToList();
        }

        private void DeliveryTypeCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = (DeliveryTypeCb.SelectedItem as DeliveryType).Id;
            if (v == 1)
            {
                DelSt.Visibility = Visibility.Collapsed;
                PointSt.Visibility = Visibility.Visible;
            }
            else if (v == 2)
            {
                DelSt.Visibility = Visibility.Visible;

                PointSt.Visibility = Visibility.Collapsed;
            }
        }

        private void DeliveryPointCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var poin = DeliveryPointCb.SelectedItem as DeliveryPoint;
            FullName.Text = poin.Useer.Name + " " + poin.Useer.LastName;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var poin = DeliveryPointCb.SelectedItem as DeliveryPoint;
            var pro = (sender as Button).DataContext as ProductOrder;
          var dialog =  new EditIStatucOrdersWindow(pro).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();


        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            var poin = DeliveryPointCb.SelectedItem as DeliveryPoint;
            int v = (DeliveryTypeCb.SelectedItem as DeliveryType).Id;
            var em = EmployeedelCb.SelectedItem as Useer;
            if (v == 1)
            {
                contextOrder.EmployeeId = poin.UserId;
            }
            else if (v == 2)
            {
                contextOrder.EmployeeId = em.Id;
            }
            App.db.SaveChanges();
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
