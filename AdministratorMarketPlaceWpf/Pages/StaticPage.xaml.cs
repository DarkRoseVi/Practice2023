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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministratorMarketPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaticPage.xaml
    /// </summary>
    public partial class StaticPage : Page
    {
        public StaticPage()
        {
            InitializeComponent();
            PointdelTb.ItemsSource = App.db.DeliveryPoint.ToList();
            PointdelTb.DisplayMemberPath = "Adress";
            var are = MainChart.ChartAreas.Add("MainArea");
        }

        private void Generetbtn_Click(object sender, RoutedEventArgs e)
        {
            var poin = PointdelTb.SelectedItem as DeliveryPoint;
            var charDate = App.db.Order.Where(x => x.DeliveryPointId == poin.Id).GroupBy(x => x.Date).ToDictionary(key => key.Key, vaule => vaule.Count());
            var seria = MainChart.Series.Add("orders seria");
            seria.Points.DataBindXY(charDate.Keys, charDate.Values);
        }
    }
}
