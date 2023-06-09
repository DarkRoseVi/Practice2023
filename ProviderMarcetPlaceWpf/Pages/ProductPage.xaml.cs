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

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.Product.Remove(product);
            }
            App.db.SaveChanges();
        }
       public void Reshres()
        {
            IEnumerable<Product> prodcutlist = App.db.Product.Where(x=>x.ProviderId == HelpClass.AutoUser.Id).ToList();
            if (SortCb.SelectedIndex != 0)
            {
                TypeProduct selettypeprod = (TypeProduct)SortCb.SelectedItem;
                prodcutlist = prodcutlist.Where(x => x.TypeProductId == selettypeprod.Id).ToList();

            }

            if (PoisTb.Text == null)
                return;

            if (PoisTb.Text.Length > 0)
            {
                prodcutlist = App.db.Product.Where(x => x.ProviderId == HelpClass.AutoUser.Id
                && x.Title.ToLower().StartsWith(PoisTb.Text.Trim())).ToList();
            }
            ProdLw.ItemsSource = prodcutlist.ToList();
        }
        private void EditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            NavigationService.Navigate(new EditInfoPage(prod));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditInfoPage(new Product()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }

     


        private void SortCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Reshres();
        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {

            Reshres();
        }

        private void ReviewBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
           new ReviewProductWindow(prod).ShowDialog();

        }

   
    }
}
