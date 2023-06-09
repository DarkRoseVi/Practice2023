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
    /// Логика взаимодействия для AddDeliveryWindow.xaml
    /// </summary>
    public partial class AddDeliveryWindow : Window
    {
        public DeliveryType contextDeliveryType;
        public AddDeliveryWindow(DeliveryType deliveryType)
        {
            InitializeComponent();
            contextDeliveryType = deliveryType;
            DataContext = contextDeliveryType;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTb.Text.Trim().Length > 0)
            {

                if (contextDeliveryType.Id == 0)
                {
                    App.db.DeliveryType.Add(contextDeliveryType);
                }
                MessageBox.Show("Delivery type saved");
                App.db.SaveChanges();

            }
            else MessageBox.Show("Fill in the title");
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;   
        }

        private void TitleTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
