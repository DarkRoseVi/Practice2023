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
using System.Windows.Navigation;
using ClientMarketPlaceWpf.Models;
using ClientMarketPlaceWpf.Pages;

using System.Windows.Shapes;

namespace ClientMarketPlaceWpf.Pages
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
            listtype.Insert(0,new TypeProduct{ Title = "Все"});

            SortCb.ItemsSource = listtype;
            SortCb.SelectedIndex = 0;
            SortCb.DisplayMemberPath = "Title";
        }
        private void Reshres() 
        {
            IEnumerable<Product> prodcutlist = App.db.Product.ToList();
            if (SortCb.SelectedIndex != 0 )
            {
                TypeProduct selettypeprod = (TypeProduct)SortCb.SelectedItem;
                prodcutlist = prodcutlist.Where(x => x.TypeProductId == selettypeprod.Id).ToList(); 

            }

            if (PoisTb.Text == null)
                return;

            if (PoisTb.Text.Length > 0)
            {
                prodcutlist = prodcutlist.Where(z=>z.Title.StartsWith(PoisTb.Text));   
            }
            ProdLw.ItemsSource = prodcutlist.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }


        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button).DataContext as Product;
            HelpClass.prod.Add(product);
        }

   
        private void MoreBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;
            NavigationService.Navigate(new MorePage(prod));
        }


        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reshres();
        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshres();
        }

        private void ViewReviewsBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = ( sender as Button).DataContext as Product;  
            new ViewRevievwsWindow(prod).ShowDialog();  
        }
    }
}
