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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProviderMarcetPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Static1Page.xaml
    /// </summary>
    public partial class Static1Page : Page
    {
        public Static1Page()
        {
            InitializeComponent();
            var area = MainChart.ChartAreas.Add("MainArea");
        }

        private void Generetbtn_Click(object sender, RoutedEventArgs e)
        {
            var chartDate = App.db.ProductOrder.Where(x => x.Product.ProviderId == HelpClass.AutoUser.Id).Select(x => x.Order).ToList();
       
            var seria = MainChart.Series.Add("orders  sum");
            seria.Points.DataBindXY(chartDate, chartDate);
        }
    }
}
