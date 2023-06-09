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
using System.Windows.Shapes;

namespace ClientMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewRevievwsWindow.xaml
    /// </summary>
    public partial class ViewRevievwsWindow : Window
    {
        public Product contentProduct;

        public ViewRevievwsWindow(Product products)
        {
            InitializeComponent();
            contentProduct = products;
            DataContext = contentProduct;
            ReviewLw.ItemsSource = App.db.Review.Where(x=>x.ProductId == contentProduct.Id).ToList();
           
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
