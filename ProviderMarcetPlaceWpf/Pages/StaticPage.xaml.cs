﻿using ProviderMarcetPlaceWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mainChart = System.Windows.Forms.DataVisualization.Charting;
using System.Xaml;

namespace ProviderMarcetPlaceWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaticPage.xaml
    /// </summary>
    public partial class StaticPage : Page
    {
        public StaticPage()
        {
            InitializeComponent();
            var area = MainChart.ChartAreas.Add("MainAreal");
            var legent = MainChart.Legends.Add("legeng");
            area.AxisX.Interval = 1;
            area.AxisY.Interval = 1;
         CbType.ItemsSource = Enum.GetValues(typeof(System.Windows.Forms.DataVisualization.Charting.SeriesChartType)).Cast<System.Windows.Forms.DataVisualization.Charting.SeriesChartType>().ToList();
        }

        private void Generetbtn_Click(object sender, RoutedEventArgs e)
        {
          var selectchat = (mainChart.SeriesChartType)CbType.SelectedItem;

            var starts = StartDp.SelectedDate;
            var end = EndDp.SelectedDate;
            if (!starts.HasValue)
            {
                System.Windows.MessageBox.Show("ni");
                return;

            }
            MainChart.Series.Clear();

            foreach (var products in App.db.Product.Where(x => x.ProviderId == HelpClass.AutoUser.Id))
            {
              
                var serias = MainChart.Series.Add($"{products.Id} {products.Title}");
                var chertdate = products.ProductOrder.Where(x => x.Product.ProviderId == HelpClass.AutoUser.Id ).Select(z => z.Order).ToList()
                    .Where(z => z.Date >= starts.Value && z.Date <= end)
                    .GroupBy(x => x.Date).ToDictionary(x => x.Key, vaule => vaule.Count());
          //      var chartdate = users..ToList().Where(z => z.Date >= starts && z.Date <= end &&)
                                                    //.GroupBy(x => x.Date)
                                                    //.ToDictionary(key => key.Key, vaule => vaule.Count());
         serias.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
               serias.Points.DataBindXY(chertdate.Keys,chertdate.Values);
                serias.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                serias.BorderWidth = 5;
              //  serias.Points.DataBindXY(chertdate.Keys, chertdate.Values);

            }
        }
    }
}
