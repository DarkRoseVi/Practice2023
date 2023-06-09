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
    /// Логика взаимодействия для TypeProdyctPage.xaml
    /// </summary>
    public partial class TypeProdyctPage : Page
    {
        public TypeProdyctPage()
        {
            InitializeComponent();
        }
        public void Reshres()
        {
            TypeProdDt.ItemsSource = App.db.TypeProduct.ToList();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).DataContext as Models.TypeProduct;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.db.TypeProduct.Remove(type);
            }
            App.db.SaveChanges();
            Reshres();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            var type = (sender as Button).DataContext as Models.TypeProduct;
            var dialog = new AddTypeProductWindow(type).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        private void AbbBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddTypeProductWindow(new Models.TypeProduct()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }
    }
}
