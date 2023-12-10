using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Customers.xaml
    /// </summary>
   

    public partial class Customers : Window
    {
        String Role;
        SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");
        int ID;

        
        public Customers(string userType)
        {
            this.Role = userType;
            InitializeComponent();
            showViews();

            CustomerDetails();
        }

        public void CustomerDetails()
        {
            connection.Open();
            string readString = "select Customer_ID,Customer_Fname,Customer_Lname,Customer_Contact,Customer_Email from TBL_Customer";
            SqlCommand command = new SqlCommand(readString, connection);
            DataTable dataTable = new DataTable();
            SqlDataReader tableinfo = command.ExecuteReader();
            dataTable.Load(tableinfo);
            connection.Close();
            DataGrid_CustomerDetails.ItemsSource = dataTable.DefaultView;


        }

        private void showViews()
        {
            switch (Role)
            {
                case "A":
                    Label_ID.Visibility = Visibility.Visible;
                    Label_FName.Visibility = Visibility.Visible;
                    Label_LName.Visibility = Visibility.Visible;
                    Label_Email.Visibility = Visibility.Visible;
                    Label_Mobile.Visibility = Visibility.Visible;

                    TextBox_ID.Visibility = Visibility.Visible;
                    TextBox_FName.Visibility = Visibility.Visible;
                    TextBox_LName.Visibility = Visibility.Visible;
                    TextBox_Mobile.Visibility = Visibility.Visible;
                    TextBox_Email.Visibility = Visibility.Visible;

                    Button_Customers_Update.Visibility = Visibility.Visible;
                    Button_Customers_Delete.Visibility = Visibility.Visible;
                    Button_Customers_Add.Visibility = Visibility.Visible;

                    employee.Visibility = Visibility.Visible;
                    
                    break;

                case "E":
                    Label_ID.Visibility = Visibility.Hidden;
                    Label_FName.Visibility= Visibility.Hidden;
                    Label_LName.Visibility = Visibility.Hidden;
                    Label_Email.Visibility = Visibility.Hidden;
                    Label_Mobile.Visibility= Visibility.Hidden;

                    TextBox_ID.Visibility= Visibility.Hidden;
                    TextBox_FName.Visibility= Visibility.Hidden;
                    TextBox_LName.Visibility= Visibility.Hidden;
                    TextBox_Mobile.Visibility=Visibility.Hidden;
                    TextBox_Email.Visibility= Visibility.Hidden;

                    Button_Customers_Add.Visibility= Visibility.Hidden;
                    Button_Customers_Delete.Visibility= Visibility.Hidden;
                    Button_Customers_Update.Visibility= Visibility.Hidden;

                    employee.Visibility= Visibility.Hidden;
                    break;
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
                        Products productsPage=new Products(Role);
                        productsPage.Show(); 
                        Close();
                        break;
                    case "categories":
                        Categories categoryPage=new Categories(Role);
                        categoryPage.Show(); 
                        Close();
                        break;
                    case "customer":
                        Customers customersPage=new Customers(Role);
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

        private void Button_Customers_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (!String.IsNullOrEmpty(TextBox_FName.Text) && !String.IsNullOrEmpty(TextBox_LName.Text) && !String.IsNullOrEmpty(TextBox_Mobile.Text)
                     && !String.IsNullOrEmpty(TextBox_Email.Text))
                {

                    

                        SqlCommand command = new SqlCommand($"INSERT INTO TBL_Customer (Customer_Fname, Customer_Lname, Customer_Contact, Customer_Email) Values ('" + TextBox_FName.Text + "', '" + TextBox_LName.Text + "', '" + TextBox_Mobile.Text + "', '" + TextBox_Email.Text + "')", connection);

                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();

                        MessageBox.Show("!!! Successfully Registered the new Customer !!!");
                        CustomerDetails();
                        ClearTextBox();


                }

                else
                {
                    MessageBox.Show("!!!!! Make sure you entered all fields !!!!");
                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void ClearTextBox()
        {
            TextBox_ID.Text = string.Empty;
            TextBox_FName.Text = string.Empty;
            TextBox_LName.Text = string.Empty;
            TextBox_Mobile.Text = string.Empty;
            TextBox_Email.Text = string.Empty;
            
        }

        private void DataGrid_CustomerDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_CustomerDetails.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_CustomerDetails.SelectedItem;

                int ID = Convert.ToInt32(dataRowView.Row[0]);
                string Firstname = dataRowView.Row[1].ToString();
                string Lname = dataRowView.Row[2].ToString();
                string Contact = dataRowView.Row[3].ToString();
                string Email = dataRowView.Row[4].ToString();


                TextBox_ID.Text = ID.ToString();
                TextBox_FName.Text = Firstname;
                TextBox_LName.Text = Lname;
                TextBox_Email.Text = Email;
                TextBox_Mobile.Text = Contact;

            }

           
        }

        private void Button_Customers_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_CustomerDetails.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_CustomerDetails.SelectedItem;
                int ID = Convert.ToInt32(dataRowView.Row[0]);

                SqlCommand command = new SqlCommand($"DELETE FROM TBL_Customer where Customer_ID = '" + ID + "'", connection);

                connection.Open();
                command.ExecuteReader();
                connection.Close();
                CustomerDetails();

                ClearTextBox();
                

            }
        }

        private void Button_Customers_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid_CustomerDetails.SelectedItem != null)
                {
                    DataRowView dataRowView = (DataRowView)DataGrid_CustomerDetails.SelectedItem;
                    int ID = Convert.ToInt32(dataRowView.Row[0]);
                    string name = TextBox_FName.Text;
                    string lname = TextBox_LName.Text;
                    string mobile = TextBox_Mobile.Text;
                    string email = TextBox_Email.Text;


                    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lname)|| string.IsNullOrEmpty(mobile)|| string.IsNullOrEmpty(email))
                    {

                        MessageBox.Show("!!!!! Please Enter Value in all Fields !!!!");
                    }

                    else
                    {

                        SqlCommand command = new SqlCommand($"UPDATE TBL_Customer SET Customer_Fname ='"+name+"',Customer_Lname='"+lname+"', Customer_Contact='"+mobile+"', Customer_Email='"+email+"' where Customer_ID ='"+ID+"'", connection);
                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();
                        CustomerDetails();

                        ClearTextBox();
                        
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Button_Customers_OrderCount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
