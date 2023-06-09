using ClientMarketPlaceWpf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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

namespace ClientMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReviewsPage.xaml
    /// </summary>
    public partial class ReviewsPage : Page
    {
        public ReviewsPage()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var rew = (sender as Button).DataContext as Review;
            var dialog = new AddReviewWindow(rew).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }


        public void Reshres() 
        {
            ReviewLw.ItemsSource = App.db.Review.ToList();    

           }
        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {
            //var reviewcont = (sender as Button).DataContext as Review;
            //if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //{
            //    App.db.Review.Remove(reviewcont);
            //}
            //App.db.SaveChanges();
            //Reshres();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddReviewWindow(new Review()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshres();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshres();
        }
    }
}
