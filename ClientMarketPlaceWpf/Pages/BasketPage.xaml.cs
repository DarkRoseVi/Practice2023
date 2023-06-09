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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientMarketPlaceWpf.Pages;
using ClientMarketPlaceWpf.Models;

namespace ClientMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public BasketPage()
        {
            InitializeComponent();
            TypedeliveryCb.ItemsSource = App.db.DeliveryType.ToList();
            DeliveryPointCb.ItemsSource = App.db.DeliveryPoint.ToList();
            CheckCb.ItemsSource = App.db.Chek.Where(x => x.UserId == HelpClass.AutoUset.Id).ToList();
            TypePaymentCb.ItemsSource = App.db.TypePayment.ToList();

            ProductLw.ItemsSource = HelpClass.prod;
            UserTb.Text = HelpClass.AutoUset.LastName + " " + HelpClass.AutoUset.Name + " " + HelpClass.AutoUset.SurName;
            SumsTb.Text = HelpClass.prod.Sum(x => x.Count * x.Cost).ToString();
            ChetInfoSt.Visibility = Visibility.Collapsed;
        }

        private void CSV_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TypedeliveryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = (TypedeliveryCb.SelectedItem as DeliveryType).Id;
            if (v == 1)
            {
                AdressSt.Visibility = Visibility.Collapsed;
                DeliveryPointSt.Visibility = Visibility.Visible;
            }
            else if (v == 2)
            {
                AdressSt.Visibility = Visibility.Visible;
                DeliveryPointSt.Visibility = Visibility.Collapsed;
            }
        }

        private void TypePaymentCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int v = (TypePaymentCb.SelectedItem as TypePayment).Id;
            if (v == 1)
            {
                ChekSt.Visibility = Visibility.Visible;
                ChekRB.Visibility = Visibility.Visible;
                CheckCb.Visibility = Visibility.Visible;
            }
            else
            {
                ChekSt.Visibility = Visibility.Collapsed;
                ChekRB.Visibility = Visibility.Collapsed;
                CheckCb.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var chek = CheckCb.SelectedItem as Chek;
            CheckTb.Text = chek.Numger.ToString();
            BankTb.Text = chek.Bank.Title.ToString();
        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }

        }

        private void OrderAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HelpClass.prod != null && HelpClass.prod.Count > 0)
            {

                decimal summa;
                var typePayment = TypePaymentCb.SelectedItem as TypePayment;
                if (typePayment != null)
                {
                    if (typePayment.Id == 1)
                    {
                        var chek = CheckCb.SelectedItem as Chek;
                        var csv = chek.CSV.ToString();
                        if (csv == CVC.Text.Trim())
                        {

                            decimal sum = (decimal)HelpClass.prod.Sum(x => x.Count * x.Cost);
                            if (chek.Balance >= sum)
                            {

                                chek.Balance -= sum;
                                Order orderuser = new Order
                                {
                                    Date = DateTime.Now,
                                    Useer = HelpClass.AutoUset,
                                    TypePayment = TypePaymentCb.SelectedItem as TypePayment,
                                    DeliveryType = TypedeliveryCb.SelectedItem as DeliveryType,
                                    AdressDelivery = AdressDeliveryTb.Text.Trim(),
                                    DeliveryPoint = DeliveryPointCb.SelectedItem as DeliveryPoint,
                                    Check = CheckTb.Text.Trim(),

                                };

                                var random = new Random();

                                var deltype = TypedeliveryCb.SelectedItem as DeliveryType;
                                var userpoint = DeliveryPointCb.SelectedItem as DeliveryPoint;
                                var usercourir = App.db.Useer.FirstOrDefault(z => z.RoleId == 2);
                                if (deltype.Id == 1)
                                {
                                    orderuser.EmployeeId = userpoint.Useer.Id;
                                }
                                else if (deltype.Id == 2)
                                {
                                    orderuser.EmployeeId = 2;
                                }
                                App.db.Order.Add(orderuser);

                                orderuser.Sum = HelpClass.prod.Sum(x => x.Count * x.Cost);
                                foreach (Product product in HelpClass.prod)
                                {
                                    string randinstring = new string(Enumerable.Repeat("1234567890", 13).Select(s => s[random.Next(s.Length)]).ToArray());

                                    App.db.ProductOrder.Add(new ProductOrder
                                    {
                                        Order = orderuser,
                                        BarCode = randinstring,
                                        Product = product,
                                        StatysOrderId = 1,
                                        Quantity = product.Count,

                                    });
                                }


                                MessageBox.Show("Order created");
                                App.db.SaveChanges();
                            }
                            else MessageBox.Show("Insufficient funds on the card");

                        }
                        else MessageBox.Show("CVC do not match, please check");
                    }
                    else
                    {

                        decimal sum = (decimal)HelpClass.prod.Sum(x => x.Count * x.Cost);

                        Order orderuser = new Order
                        {
                            Date = DateTime.Now,
                            Useer = HelpClass.AutoUset,
                            TypePayment = TypePaymentCb.SelectedItem as TypePayment,
                            DeliveryType = TypedeliveryCb.SelectedItem as DeliveryType,
                            AdressDelivery = AdressDeliveryTb.Text.Trim(),
                            DeliveryPoint = DeliveryPointCb.SelectedItem as DeliveryPoint,
                            Check = CheckTb.Text.Trim(),
                        };

                        var random = new Random();
                        //string randimDigit =co random.Next(10);
                        var deltype = TypedeliveryCb.SelectedItem as DeliveryType;
                        var userpoint = DeliveryPointCb.SelectedItem as DeliveryPoint;
                        var usercourir = App.db.Useer.FirstOrDefault(z => z.RoleId == 2);
                        if (deltype.Id == 1)
                        {
                            orderuser.EmployeeId = userpoint.Useer.Id;
                        }
                        else if (deltype.Id == 2)
                        {
                            orderuser.EmployeeId = 2;
                        }
                        App.db.Order.Add(orderuser);

                        orderuser.Sum = HelpClass.prod.Sum(x => x.Count * x.Cost);

                        foreach (Product product in HelpClass.prod)
                        {
                            string randinstring = new string(Enumerable.Repeat("123456789", 13).Select(s => s[random.Next(s.Length)]).ToArray());

                            App.db.ProductOrder.Add(new ProductOrder
                            {
                                Order = orderuser,
                                BarCode = randinstring,
                                Product = product,
                                StatysOrderId = 1,
                                Quantity = product.Count,

                            });
                        }


                        MessageBox.Show("Order created");
                        App.db.SaveChanges();


                    }
                }
            }
            else MessageBox.Show("Basket is null");
         

        }






        private void DeleBtn_Click(object sender, RoutedEventArgs e)
        {
            var prod = (sender as Button).DataContext as Product;   
            HelpClass.prod.Remove(prod);
            ProductLw.Items.Refresh();
        }
    }
}
