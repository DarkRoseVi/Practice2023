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
    /// Логика взаимодействия для AddReviewWindow.xaml
    /// </summary>
    public partial class AddReviewWindow : Window
    {
        public Review contextReview;
        public AddReviewWindow(Review review)
        {
            InitializeComponent();
            ProductCb.ItemsSource = App.db.ProductOrder.Where(x=>x.StatysOrderId == 8 && x.Order.UserId == HelpClass.AutoUset.Id).Select(x => x.Product).ToList();
            contextReview = review;
            DataContext = contextReview;
            FullUserNameTb.Text = HelpClass.AutoUset.LastName + " " + HelpClass.AutoUset.Name + " " + HelpClass.AutoUset.SurName;  
            contextReview.Useer = HelpClass.AutoUset;
            contextReview.Description = ContentTb.Text.Trim();

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (contextReview.Id == 0 )
            {
                App.db.Review.Add(contextReview);
            }
            MessageBox.Show("Saved");
            App.db.SaveChanges();
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ProductCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var ot = ProductCb.SelectedItem as Product;
            TitleTb.Text = ot.Title;
        }
    }
}
