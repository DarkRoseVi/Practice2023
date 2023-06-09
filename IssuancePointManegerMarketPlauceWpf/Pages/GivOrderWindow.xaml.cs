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
    /// Логика взаимодействия для GivOrderWindow.xaml
    /// </summary>
    public partial class GivOrderWindow : Window
    {
        public ProductOrder contextproductOrder;
        public GivOrderWindow()
        {
            InitializeComponent();
           
            
        }

        private void ExtraditeBtn_Click(object sender, RoutedEventArgs e)
        {
            var barcoderTb = BarCodeTb.Text.Trim();
            var barcode = App.db.ProductOrder.Where(x => x.BarCode == barcoderTb && x.StatysOrderId == 5).FirstOrDefault();
            barcode.StatysOrderId = 8;
            App.db.SaveChanges();
            MessageBox.Show($"order {barcode.StatysOrder.Title}");
            DialogResult = true;
        }

        private void BarCodeTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BarCodeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var barcoderTb = BarCodeTb.Text.Trim();
            var barcode = App.db.ProductOrder.Where(x => x.BarCode == barcoderTb && x.StatysOrderId == 5).FirstOrDefault();
             if (barcoderTb.Length == 13) 
            {
            
            
            if (barcode != null)
            {
                NumberTb.Text = barcode.Order.Id.ToString();
                ProductTb.Text = barcode.Product.Title.ToString();
                StatysTb.Text = barcode.StatysOrder.Title.ToString();

            }
                else 
                {

                    var productOrder = App.db.ProductOrder.FirstOrDefault(x => x.BarCode == barcoderTb);
                    string status = "";
                    if (productOrder != null)
                    {
                        status = productOrder.StatysOrder.Title.ToString();
                        MessageBox.Show($"The order has a status {status}");
                    }
                    else MessageBox.Show("No such order");
                    //   MessageBox.Show($" Заказ имеет статус {barcode.StatysOrder.Title}");
                    //   MessageBox.Show("shfsjkdfbsjdf");
                }
            }
      

        }
    }
}
