using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Window
    {
        string Role;
        SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");

        public Categories(string userType)
        {
            this.Role = userType;
            InitializeComponent();
            showViews();

            CategoryDetails();
           
        }

        private void showViews()
        {
            switch (Role)
            {
                case "A":
                    TextBox_CName.Visibility = Visibility.Visible;
                    TextBox_ID.Visibility = Visibility.Visible;

                    Label_Cname.Visibility = Visibility.Visible;
                    Label_ID.Visibility = Visibility.Visible;

                    Button_Category_ADD.Visibility = Visibility.Visible;
                    Button_Category_Delete.Visibility = Visibility.Visible;
                    Button_Category_Update.Visibility = Visibility.Visible;

                    employee.Visibility = Visibility.Visible;
                    break;

                case "E":
                    TextBox_CName.Visibility = Visibility.Hidden;
                    TextBox_ID.Visibility = Visibility.Hidden;

                    Label_ID.Visibility = Visibility.Hidden;
                    Label_Cname.Visibility = Visibility.Hidden;

                    Button_Category_ADD.Visibility = Visibility.Hidden;
                    Button_Category_Delete.Visibility = Visibility.Hidden;
                    Button_Category_Update.Visibility = Visibility.Hidden;
                    employee.Visibility = Visibility.Hidden;
                    break;
            }
        }

        public void CategoryDetails()
        {
            connection.Open();
            string readString = "select Category_ID, Category_Name from TBL_Category";
            SqlCommand command = new SqlCommand(readString, connection);
            DataTable dataTable = new DataTable();
            SqlDataReader tableinfo = command.ExecuteReader();
            dataTable.Load(tableinfo);
            connection.Close();
            DataGrid_CategoryDetails.ItemsSource = dataTable.DefaultView;


        }

        private void Button_CategoryADD_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (!String.IsNullOrEmpty(TextBox_CName.Text))
                {



                    SqlCommand command = new SqlCommand($"INSERT INTO TBL_Category (Category_Name) Values ('" + TextBox_CName.Text + "')", connection);

                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();

                    MessageBox.Show("!!! Successfully added the new Category !!!");

                    CategoryDetails();
                    ClearTextBox();



                }

                else
                {
                    MessageBox.Show("!!!!! Make sure you entered the Category !!!!");
                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void ClearTextBox()
        {

            TextBox_CName.Text = string.Empty;
            TextBox_ID.Text = string.Empty;
        }
        private void ClearCategoryGrid()
        {
            // DataGrid_CategoryDetails.ClearDetailsVisibilityForItem(this);
        }


        private void Button_CategoryUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid_CategoryDetails.SelectedItem != null)
                {
                    DataRowView dataRowView = (DataRowView)DataGrid_CategoryDetails.SelectedItem;
                    int ID = Convert.ToInt32(dataRowView.Row[0]);
                    String name = TextBox_CName.Text;
                   
                    if (string.IsNullOrEmpty(name) )
                    {

                        MessageBox.Show("!!!!! Please Enter Value in all Fields !!!!");
                    }
                    
                    else
                    {

                        SqlCommand command = new SqlCommand($"UPDATE TBL_Category SET Category_Name ='" + name + "' where Category_ID = '" + ID + "'", connection);
                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();
                        CategoryDetails();

                        ClearTextBox();
                        ClearCategoryGrid();
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Button_CategoryDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_CategoryDetails.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_CategoryDetails.SelectedItem;
                int ID = Convert.ToInt32(dataRowView.Row[0]);

                SqlCommand command = new SqlCommand($"DELETE FROM TBL_Category where Category_ID = '" + ID + "'", connection);

                connection.Open();
                command.ExecuteReader();
                connection.Close();
                CategoryDetails();

                ClearTextBox();
                ClearCategoryGrid();

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

        private void DataGrid_CategoryDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_CategoryDetails.SelectedItem != null)
            {
                if (DataGrid_CategoryDetails.SelectedItem != null)
                {
                    DataRowView dataRowView = (DataRowView)DataGrid_CategoryDetails.SelectedItem;

                    int ID = Convert.ToInt32(dataRowView.Row[0]);

                    String Category_Name = dataRowView.Row[1].ToString();

                    TextBox_ID.Text = ID.ToString();
                    TextBox_CName.Text = Category_Name;

                }
                ProductDetails();

            }


        }
        public void ProductDetails()
        {
            if (DataGrid_CategoryDetails.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_CategoryDetails.SelectedItem;

                int ID = Convert.ToInt32(dataRowView.Row[0]);

                String Category_Name = dataRowView.Row[1].ToString();

                connection.Open();
                string readString = "select Product_ID, Product_Name, Unit_Price, Product_QTY from TBL_Product Where Category_ID = '" + ID + "'";
                SqlCommand command = new SqlCommand(readString, connection);
                DataTable dataTable = new DataTable();
                SqlDataReader tableinfo = command.ExecuteReader();
                dataTable.Load(tableinfo);
                connection.Close();
                DataGrid_Category_Product_List.ItemsSource = dataTable.DefaultView;
            }
        }

       
    }
}
