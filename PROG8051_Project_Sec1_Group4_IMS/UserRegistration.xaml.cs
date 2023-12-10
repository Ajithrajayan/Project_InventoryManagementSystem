using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace PROG8051_Project_Sec1_Group4_IMS
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");
        int ID;
        string Role;
        public UserRegistration(string userType)
        {
            this.Role = userType;
            InitializeComponent();
            
            EmployeeDetails();
           // Update_Employee();
           
           

        }

        //string UserID, string UserFullName, string ContactNumber
        public void EmployeeDetails() 
        {
            connection.Open();
            string readString = "Select USER_ID, USER_NAME, Password, Role, Full_Name, Contact_No from TBL_Login";
            SqlCommand command = new SqlCommand(readString, connection);
            DataTable dataTable = new DataTable();
            SqlDataReader tableinfo= command.ExecuteReader();
            dataTable.Load(tableinfo);
            connection.Close();
            DataGrid_EmployeeData.ItemsSource = dataTable.DefaultView;


        }

        private void Button_EmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
               
               
               if(!String.IsNullOrEmpty(TextBox_FName.Text) && !String.IsNullOrEmpty(TextBox_CPassword.Text) && !String.IsNullOrEmpty(TextBox_Mobile.Text) 
                    && !String.IsNullOrEmpty(TextBox_Password.Text) && !String.IsNullOrEmpty(TextBox_Role.Text) && !String.IsNullOrEmpty(TextBox_UserName.Text))
               {
                   
                        if (TextBox_Password.Text == TextBox_CPassword.Text) 
                        {

                            SqlCommand command = new SqlCommand($"INSERT INTO TBL_Login (User_Name, Password, Role, Full_Name, Contact_No) Values ('" + TextBox_UserName.Text + "', '" + TextBox_Password.Text + "', '" + TextBox_Role.Text + "', '" + TextBox_FName.Text + "', '" + TextBox_Mobile.Text + "')", connection);
                            
                            connection.Open();
                            command.ExecuteReader();
                            connection.Close();

                            MessageBox.Show("!!! Successfully Registered the new USER !!!");
                            EmployeeDetails();
                             ClearTextBox();


                        }
                 
                   
               }

                else 
                {
                    MessageBox.Show("!!!!! Make sure you entered the same password and fill all fields !!!!");
                }


               
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

       
        private void Button_EmployeeUpdate_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (DataGrid_EmployeeData.SelectedItem != null)
                {
                    DataRowView dataRowView = (DataRowView)DataGrid_EmployeeData.SelectedItem;
                    ID = Convert.ToInt32(dataRowView.Row[0]);
                    String User = TextBox_UserName.Text;
                    String Password = TextBox_Password.Text;
                    String CPassword = TextBox_CPassword.Text;
                    String Role = TextBox_Role.Text;
                    String FName = TextBox_FName.Text;
                    String Contact = TextBox_Mobile.Text;

                    if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(CPassword) || string.IsNullOrEmpty(FName) || string.IsNullOrEmpty(Contact) || string.IsNullOrEmpty(Role))
                    {

                        MessageBox.Show("!!!!! Please Enter Value in all Fields !!!!");
                    }
                    else if (!Password.Equals(CPassword))
                    {
                        MessageBox.Show("!!!!! Password and Confirm Password Must be Same !!!!");
                    }
                    else
                    {

                        SqlCommand command = new SqlCommand($"UPDATE TBL_Login SET User_Name ='" + User + "', Password ='" + Password + "', Role='" + Role + "', Full_Name='" + FName + "', Contact_No='" + Contact + "' Where User_ID = '" + ID + "' ", connection);
                        // SqlCommand command = new SqlCommand("UPDATE TBL_Login SET User_Name = @User, Password = @Password, Role = @Role, Full_Name = @FName, Contact_No = @Contact WHERE User_ID = @ID", connection);
                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();

                        EmployeeDetails();
                        ClearTextBox();
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        private void Button_EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_EmployeeData.SelectedItem!=null) 
            {
                DataRowView dataRowView = (DataRowView) DataGrid_EmployeeData.SelectedItem;
                int ID = Convert.ToInt32(dataRowView.Row[0]);

                SqlCommand command = new SqlCommand($"DELETE FROM TBL_Login where User_ID = '" + ID + "'", connection);

                connection.Open();
                command.ExecuteReader();
                connection.Close();

                EmployeeDetails();
                ClearTextBox();

            }

        }

        private void ClearTextBox()
        {
            TextBox_UserName.Text = string.Empty;
            TextBox_Password.Text = string.Empty;
            TextBox_Mobile.Text = string.Empty;
            TextBox_FName.Text = string.Empty;
            TextBox_Role.Text = string.Empty;
            TextBox_CPassword.Text = string.Empty;

        }

        private void DataGrid_EmployeeData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DataGrid_EmployeeData.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_EmployeeData.SelectedItem;
                ID = Convert.ToInt32(dataRowView.Row[0]);
                String User = dataRowView.Row[1].ToString();
                String Password = dataRowView.Row[2].ToString();
                String Role = dataRowView.Row[3].ToString();
                String FName = dataRowView.Row[4].ToString();
                String Contact = dataRowView.Row[5].ToString();

                TextBox_UserName.Text = User;
                TextBox_Password.Text = Password;
                TextBox_Role.Text = Role;
                TextBox_FName.Text = FName;
                TextBox_Mobile.Text = Contact;

               // TextBox_Password.Text=String.Empty;
                
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem != null)
            {
                switch (menuItem.Name)
                {
                    case "products":
                        Products productsPage = new Products(Role);
                        productsPage.Show();
                        Close();
                        break;
                    case "categories":
                        Categories categoryPage = new Categories(Role);
                        categoryPage.Show();
                        Close();
                        break;
                    case "customer":
                        Customers customersPage = new Customers(Role);
                        customersPage.Show();
                        Close();
                        break;
                    case "order":
                        Orders ordersPage = new Orders(Role);
                        ordersPage.Show();
                        Close();
                        break;
                    case "employee":
                        UserRegistration employee = new UserRegistration(Role);
                        employee.Show();
                        Close();
                        break;
                    case "dashboard":
                        AdminDashboard dashboard = new AdminDashboard(Role);
                        dashboard.Show();
                        Close();
                        break;
                }
            }
        }


    }
}
