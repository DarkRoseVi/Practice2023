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
            ReviewLw.ItemsSource = App.db.Review.Where(x => x.ProductId == contentProduct.Id).ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        public void Reshres()
        {
            ReviewLw.ItemsSource = App.db.Review.ToList();

        }
        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var reviewcont = (sender as Button).DataContext as Review;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.Review.Remove(reviewcont);
            }
            App.db.SaveChanges();
            Reshres();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
           var rew = (sender as Button).DataContext as Review;
            var dialog = new ReviewAddWindow(rew).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }
    }
}
