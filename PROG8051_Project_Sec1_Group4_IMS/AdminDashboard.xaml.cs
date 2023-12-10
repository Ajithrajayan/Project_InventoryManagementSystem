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

namespace PROG8051_Project_Sec1_Group4_IMS
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        String Role;

       
        MainWindow login = new MainWindow();
      
        public AdminDashboard(string userType)
        {
            this.Role = userType;
            InitializeComponent();
            showViews();


        }

        private void showViews()
        {
            switch (Role)
            {
                case "A":
                    Button_Dashboard_Employee.Visibility = Visibility.Visible;
                    break;

                case "E":
                    Button_Dashboard_Employee.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void Button_DashboardProduct_Click(object sender, RoutedEventArgs e)
        {
            Products products = new Products(Role);
            products.Show();
            Close();

        }

        private void Button_DashboardCategories_Click(object sender, RoutedEventArgs e)
        {
            Categories categories = new Categories(Role);
            categories.Show();
            Close();
        }

        private void Button_DashboardCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers(Role);
            customers.Show();
            Close();
        }

        private void Button_DashboardOrders_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders(Role);
            orders.Show();
            Close();
        }

        private void Button_DashboardEmployee_Click(object sender, RoutedEventArgs e)
        {
            UserRegistration employeeRegistration = new UserRegistration(Role);
            employeeRegistration.Show();
            Close();
        }

        private void Button_DashboardLogout_Click(object sender, RoutedEventArgs e)
        {
            login.Show();
            Close();
        }
    }
}
