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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        Role roles;
        public UserPage()
        {
            InitializeComponent();
            roles = null;
        }
        public void Reshre()
        {
            IEnumerable<Useer> userlist = App.db.Useer.ToList();

            if (PoisTb.Text == null)
                UserDt.ItemsSource = userlist.ToList();
            if (PoisTb.Text.Length > 0)
            {
                userlist = userlist.ToList().Where(x => x.Name.ToLower().StartsWith(PoisTb.Text.Trim()) ||
                   x.LastName.ToLower().StartsWith(PoisTb.Text.Trim()) || x.SurName.ToLower().StartsWith(PoisTb.Text.Trim()));
            }
            if (roles != null)
            {
               
                UserDt.ItemsSource = userlist.Where(x => x.RoleId == roles.Id).ToList();
            }
            else
            {
                 UserDt.ItemsSource = userlist.ToList();
            }
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x=>x.Id ==1);    
            Reshre();
        }

        private void CourierBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x => x.Id == 2);
            Reshre();
        }

        private void EmployeePointBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x => x.Id == 3);
            Reshre();
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            roles = App.db.Role.FirstOrDefault(x => x.Id == 5);
            Reshre();
        }

        private void PoisTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Reshre();
        }

        private void AllBtn_Click(object sender, RoutedEventArgs e)
        {  
            UserDt.ItemsSource = App.db.Useer.ToList();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reshre();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button).DataContext as Useer;
           var dialog = new AddUserWindow(user).ShowDialog();
            roles = null;
            if(dialog.HasValue && dialog.Value)
                Reshre();
        }

        private void DeletBtn_Click(object sender, RoutedEventArgs e)
        {

            var em = (sender as Button).DataContext as Useer;
            if (MessageBox.Show("Вы точно хотите удалить эту запись", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.db.Useer.Remove(em);
            App.db.SaveChanges();
            roles = null;
            Reshre();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddUserWindow(new Useer()).ShowDialog();
            if (dialog.HasValue && dialog.Value)
                Reshre();

        }
    }
}
