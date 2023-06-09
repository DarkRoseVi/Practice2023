using IssuancePointManegerMarketPlauceWpf.Models;
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

namespace IssuancePointManegerMarketPlauceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditStatysWindow.xaml
    /// </summary>
    public partial class EditStatysWindow : Window
    {
        public ProductOrder contextProductOrder;
        public EditStatysWindow(ProductOrder productorders)
        {
            InitializeComponent();
            StatusCb.ItemsSource = App.db.StatysOrder.Where(x=>x.Id == 5 || x.Id == 4).ToList();
            contextProductOrder = productorders;
            DataContext = contextProductOrder;

        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            if (StatusCb.SelectedItem == null)
            {
                if (QuantitiTb.Text.Length > 0)
                {
                    MessageBox.Show("Saved");
                    App.db.SaveChanges();

                }
                else MessageBox.Show("Fill in the quantity");

            }
            else MessageBox.Show("Check out the status");
            DialogResult = true;

        }

        private void QuantitiTb_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
