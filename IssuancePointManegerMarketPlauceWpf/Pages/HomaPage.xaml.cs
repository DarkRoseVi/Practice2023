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

namespace IssuancePointManegerMarketPlauceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomaPage.xaml
    /// </summary>
    public partial class HomaPage : Page
    {
        public HomaPage()
        {
            InitializeComponent();
            MyFrame.NavigationService.Navigate(new OrdersPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }

        private void Orderbtn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new OrdersPage());
        }

        private void GivOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            new GivOrderWindow().ShowDialog();  
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            new ReturnProductWindow().ShowDialog(); 
        }
    }
}
