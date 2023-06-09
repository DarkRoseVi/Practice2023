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
using System.Windows.Shapes;

namespace ProviderMarcetPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditStatusProductorderWindow.xaml
    /// </summary>
    public partial class EditStatusProductorderWindow : Window
    {
        public ProductOrder contextProductOrder;
        public EditStatusProductorderWindow(ProductOrder productorders)
        {
            InitializeComponent();
            StatusCb.ItemsSource = App.db.StatysOrder.Where(x=>x.Id == 3 || x.Id == 6 || x.Id == 2 ).ToList();
            contextProductOrder = productorders;
            DataContext = contextProductOrder;
            StatusTb.Text = contextProductOrder.Statys;


        }

        //private void SaveBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (StatusCb.SelectedItem != null)
        //    {
        //        App.db.SaveChanges();
          
        //    }
        //    else MessageBox.Show("Check out the status");
        //    DialogResult = true;
        //}

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;   
        }
    }
}
