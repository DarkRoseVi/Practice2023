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
    /// Логика взаимодействия для ReviewAddWindow.xaml
    /// </summary>
    public partial class ReviewAddWindow : Window
    {
        public Review contextReview;
        public ReviewAddWindow(Review review)
        {
            InitializeComponent();
            ProductCb.ItemsSource = App.db.Product.Where(x=>x.Id == review.Id).ToList();
            contextReview = review;
            DataContext = contextReview;
            FullUserNameTb.Text = contextReview.Useer.Name + contextReview.Useer.Fullname + contextReview.Useer.SurName;
          //  ProductCb.SelectedIndex = contextReview.Product;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (contextReview.Id == 0)
            {
                App.db.Review.Add(contextReview);
            }
            MessageBox.Show("Saved");
            App.db.SaveChanges();
            DialogResult = true;
        }

        //private void ProductCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var ot = ProductCb.SelectedItem as Product;
        //    TitleTb.Text = ot.Title;
        //}
    }
}
