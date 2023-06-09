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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            Reshres();
        }

        public void Reshres()
        {
            var user = HelpClass.AutoUser.Id;
            var contextorders = App.db.ProductOrder.Where(x => x.Product.ProviderId == user).Select(x => x.Order);
            OrderLw.ItemsSource = contextorders.ToList();
        }
        private void EditStatusBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as ProductOrder;
           var dialog =  new EditStatusProductorderWindow(prod).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
       }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }
    }
}
