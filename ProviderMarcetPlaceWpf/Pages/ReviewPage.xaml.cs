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
    /// Логика взаимодействия для ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        public ReviewPage()
        {
            InitializeComponent();
            Reshres();
        }
        public void Reshres()
        {
            ReviewLw.ItemsSource = App.db.Review.Where(x => x.Product.ProviderId == HelpClass.AutoUser.Id).ToList();

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
    }
}
