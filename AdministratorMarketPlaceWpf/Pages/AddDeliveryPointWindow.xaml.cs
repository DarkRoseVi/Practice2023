using AdministratorMarketPlaceWpf.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для AddDeliveryPointWindow.xaml
    /// </summary>
    public partial class AddDeliveryPointWindow : Window
    {
        public DeliveryPoint contextDeliveryPoint;
        public AddDeliveryPointWindow(DeliveryPoint deliveryPoint)
        {
            InitializeComponent();
            UserCb.ItemsSource = App.db.Useer.Where(x => x.RoleId == 3).ToList();
            UserCb.DisplayMemberPath = "Fullname";
            contextDeliveryPoint = deliveryPoint;
            DataContext = contextDeliveryPoint;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {


            if (AdressTb.Text.Length > 0)
            {
                if (UserCb.SelectedItem == null)
                {
                    if (contextDeliveryPoint.Id == 0)
                    {
                        App.db.DeliveryPoint.Add(contextDeliveryPoint);
                    }
                    MessageBox.Show("Saved");
                    App.db.SaveChanges();
                }

                else MessageBox.Show("Choose the person responsible");
            }
            else 
                MessageBox.Show("Fill in the address");
            DialogResult = true;
        }
    }
}
