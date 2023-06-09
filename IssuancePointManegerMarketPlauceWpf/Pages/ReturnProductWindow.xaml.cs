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
    /// Логика взаимодействия для ReturnProductWindow.xaml
    /// </summary>
    public partial class ReturnProductWindow : Window
    {
        public ReturnProductWindow()
        {
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
          
            var barcode = BarcodeTb.Text.Trim();
            if (barcode.Length > 0)
            {
                var barcodebd = App.db.ProductOrder.Where(z=>z.BarCode == barcode && z.StatysOrderId == 8).FirstOrDefault();
                barcodebd.StatysOrderId = 7;
                MessageBox.Show("Product returned due to customer's refusal");
                App.db.SaveChanges();

            }
            else MessageBox.Show("Fill in the  barcode field");
            DialogResult = true;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BarcodeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var barcode = BarcodeTb.Text.Trim();
            var barcodebd = App.db.ProductOrder.Where(z => z.BarCode == barcode && z.StatysOrderId == 8).FirstOrDefault();
                if (barcode.Length == 13)
            {


                if (barcodebd != null)
                {
                    NumberBtn.Text = barcodebd.OrderId.ToString();
                    UserBtn.Text = barcodebd.Order.Useer.Name.ToString() + " " + barcodebd.Order.Useer.LastName.ToString();
                    NameTb.Text = barcodebd.Product.Title.ToString();
                    if (barcodebd.Order.Check != null)
                    {
                        var us = App.db.Chek.FirstOrDefault(x => x.UserId == barcodebd.Order.Useer.Id);
                        us.Balance += barcodebd.Product.Cost;
                    }


                }
                else
                {

                    var productOrder = App.db.ProductOrder.FirstOrDefault(x => x.BarCode == barcode);
                    string status = "";
                    if (productOrder != null)
                    {
                        status = productOrder.StatysOrder.Title.ToString();
                        MessageBox.Show($"The order has a status {status}");
                    }
                    else MessageBox.Show("No such order");
                }
            }
 
        }

        private void BarcodeTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}

