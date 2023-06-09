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
    /// Логика взаимодействия для Static1Page.xaml
    /// </summary>
    public partial class Static1Page : Page
    {
        public Static1Page()
        {
            InitializeComponent();
            CourierCb.ItemsSource = App.db.Useer.Where(x=>x.RoleId == 2).ToList();
            CourierCb.DisplayMemberPath = "Fullname";
            var are = MainChart.ChartAreas.Add("MainArea");
        }

        private void Generetbtn_Click(object sender, RoutedEventArgs e)
        {
            var courer = CourierCb.SelectedItem as Useer;
            var charDate = App.db.Order.Where(x => x.EmployeeId == courer.Id).GroupBy(x => x.Date).ToDictionary(key => key.Key, vaule => vaule.Count());
            var seria = MainChart.Series.Add("orders seria");
            seria.Points.DataBindXY(charDate.Keys, charDate.Values);
        }
    }
}
