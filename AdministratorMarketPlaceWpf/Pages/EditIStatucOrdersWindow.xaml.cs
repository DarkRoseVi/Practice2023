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
    /// Логика взаимодействия для EditIStatucOrdersWindow.xaml
    /// </summary>
    public partial class EditIStatucOrdersWindow : Window
    {
        public ProductOrder contextProductOrder;
        public EditIStatucOrdersWindow(ProductOrder productorders)
        {
            InitializeComponent();
            StatusCb.ItemsSource = App.db.StatysOrder.ToList();
            contextProductOrder = productorders;
            DataContext = contextProductOrder;
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
