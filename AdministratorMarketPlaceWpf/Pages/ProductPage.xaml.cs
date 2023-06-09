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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            List<TypeProduct> listtype = App.db.TypeProduct.ToList();
            listtype.Insert(0, new TypeProduct { Title = "Все" });

            SortCb.ItemsSource = listtype;
            SortCb.SelectedIndex = 0;
            SortCb.DisplayMemberPath = "Title";
        }
        private void Reshres()
        {
            IEnumerable<Product> prodcutlist = App.db.Product.ToList();
            if (SortCb.SelectedIndex != 0)
            {
                TypeProduct selettypeprod = (TypeProduct)SortCb.SelectedItem;
                prodcutlist = prodcutlist.Where(x => x.TypeProductId == selettypeprod.Id).ToList();

            }

            if (PoisTb.Text == null)
                return;

            if (PoisTb.Text.Length > 0)
            {
                prodcutlist = prodcutlist.Where(z => z.Title.StartsWith(PoisTb.Text));
            }
            ProdLw.ItemsSource = prodcutlist.ToList();
        }

        private void EditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
           NavigationService.Navigate(new EditInfoProductPage(prod));
        }

        private void ViewReviewsBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            new ViewRevievwsWindow(prod).ShowDialog();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.Product.Remove(product);
            }
            App.db.SaveChanges();
            Reshres();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshres();

        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }
    }
}
