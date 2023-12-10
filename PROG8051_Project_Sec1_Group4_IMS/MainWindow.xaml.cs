using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
using System.Xml.Linq;

namespace PROG8051_Project_Sec1_Group4_IMS
{
    
  
    public partial class MainWindow : Window
    {
       SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");

        public MainWindow()
        {
            InitializeComponent();

                      
        }
               
        public void InsertValuesIntoGAStatistics(string User_Name, string Password, 
            string Role, string Full_Name, string Contact_No)
        {

            try
            {

              //  SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");

              /*  SqlCommand command = new SqlCommand($"INSERT INTO TBL_Login (User_Name, Password, Role, Full_Name, Contact_No) Values ('" + User_Name + "', '" + Password + "', '" + Role + "', '" + Full_Name + "', '" + Contact_No + "')", connection);

                connection.Open();
                command.ExecuteReader();
                connection.Close();*/
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

             
            

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {

            string username = TextBox_userName.Text;
            string password = TextBox_password.Password;
            bool isAdmin = RadioButton_Admin.IsChecked ?? false;

            // Validate inputs

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || (!RadioButton_Admin.IsChecked.HasValue && !RadioButton_Employee.IsChecked.HasValue))
            {
                MessageBox.Show("Please enter a username, password, and select a user type.");
                return;
            }

            if (AuthenticateUser(username, password, isAdmin))
            {
                MessageBox.Show("Login successful!");

                string userType = isAdmin ? "A" : "E";

                AdminDashboard aDashboard = new AdminDashboard(userType);
                Products pro = new Products(userType);
                aDashboard.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }

        private bool AuthenticateUser(string username, string password, bool isAdmin)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True"))
            {
                try
                {
                    connection.Open();

                    string userType = isAdmin ? "A" : "E";

                    string query = $"SELECT COUNT(*) FROM  TBL_Login WHERE CONVERT(VARCHAR, User_Name) = @Username AND CONVERT(VARCHAR, Password) = @Password  AND CONVERT(VARCHAR, Role) = @UserType;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@UserType", userType);

                        int count = (int)command.ExecuteScalar();

                        return count > 0; // If count is greater than 0, authentication is successful
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential exceptions (e.g., database connection issues)
                    MessageBox.Show($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        private void RadioButton_Employee_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Admin_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
