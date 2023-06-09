using AdministratorMarketPlaceWpf.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditInfoProductPage.xaml
    /// </summary>
    public partial class EditInfoProductPage : Page
    {
        public Product contextproduct;
        public EditInfoProductPage(Product product)
        {
            InitializeComponent();
            TypeCb.ItemsSource = App.db.TypeProduct.ToList();
            ProviderTb.ItemsSource = App.db.Provider.ToList();
            contextproduct = product;
            DataContext = contextproduct;
            ImageLW.ItemsSource = contextproduct.ProductPhoto.ToList();

            int id = Convert.ToInt32(contextproduct.Id);



            ImageLW.ItemsSource = contextproduct.ProductPhoto.ToList();
        }
        private void Reshres()
        {
            ImageLW.ItemsSource = contextproduct.ProductPhoto.ToList();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(contextproduct.Title))
            {
                MessageBox.Show("Title is null");
                return;
            }
            else if (string.IsNullOrEmpty(contextproduct.Descriprion))
            {
                MessageBox.Show("Descriprion is null");
                return;
            }
            else if (contextproduct.Cost == null)
            {
                MessageBox.Show("Cost is null");
                return;
            }
            else if (contextproduct.Provider == null)
            {
                MessageBox.Show("Provider is null");
                return;
            }
            else if (contextproduct.TypeProduct == null)
            {
                MessageBox.Show("Type product is null");
                return;
            }
   
            else
            {

                if (contextproduct.Id == 0)
                {
                    App.db.Product.Add(contextproduct);
                }
                MessageBox.Show("yes");
                App.db.SaveChanges();
                NavigationService.Navigate(new ProductPage());

            }

        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            var dialor = new OpenFileDialog() { Multiselect = true };
            if (dialor.ShowDialog().GetValueOrDefault())
            {
                foreach (var item in dialor.FileNames)
                {
                    contextproduct.ProductPhoto.Add(new ProductPhoto()
                    {
                        Photo = File.ReadAllBytes(item),
                        Product = contextproduct,
                    });


                }
                Reshres();
                DataContext = null;
                DataContext = contextproduct;


            }

        }

        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && (e.Text != ","))
            {
                e.Handled = true;
            }
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
         
            var product = (sender as Button).DataContext as ProductPhoto;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
             App.db.ProductPhoto.Remove(product);
            }
            App.db.SaveChanges();
            Reshres();
        }
    }
}
