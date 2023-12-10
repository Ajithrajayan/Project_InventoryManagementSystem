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
using System.Xml.Linq;

namespace PROG8051_Project_Sec1_Group4_IMS
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        String Role;
        List<Category> categoryList;
        Category selectedCategory;

        SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");
        int ID;
        public Products(string userType)
        {
            this.Role = userType;
            InitializeComponent();
            showViews();

            ProductsDetails();


            categoryList = LoadCategoryFromDatabase();
            // Add a hint item at the beginning of the list
            categoryList.Insert(0, new Category { CategoryID = -1, CategoryName = "Select Category" });
            ComboBox_Category.ItemsSource = categoryList;
            ComboBox_Category.SelectedIndex = 0; // Set the selected index to display the hint                               
            ComboBox_Category.SelectionChanged += ComboBox_Category_SelectionChanged;// Attach the SelectionChanged event handler

        }
        private void showViews()
        {
            switch (Role)
            {
                case "A":
                    TextBox_Name.Visibility = Visibility.Visible;
                    TextBox_UnitPrice.Visibility = Visibility.Visible;
                    TextBox_Quantity.Visibility = Visibility.Visible;
                    ComboBox_Category.Visibility = Visibility.Visible;

                    Label_Category.Visibility = Visibility.Visible;
                    Label_UnitPrice.Visibility = Visibility.Visible;
                    Label_Name.Visibility = Visibility.Visible;
                    Label_Quantity.Visibility = Visibility.Visible;

                    Button_Product_Add.Visibility = Visibility.Visible;
                    Button_Product_Delete.Visibility = Visibility.Visible;
                    Button_Product_Update.Visibility = Visibility.Visible;

                    employee.Visibility = Visibility.Visible;

                    break;

                case "E":
                    TextBox_Name.Visibility = Visibility.Hidden;
                    TextBox_UnitPrice.Visibility = Visibility.Hidden;
                    TextBox_Quantity.Visibility = Visibility.Hidden;
                    ComboBox_Category.Visibility = Visibility.Hidden;

                    Label_Category.Visibility = Visibility.Hidden;
                    Label_UnitPrice.Visibility = Visibility.Hidden;
                    Label_Name.Visibility = Visibility.Hidden;
                    Label_Quantity.Visibility= Visibility.Hidden;

                    Button_Product_Add.Visibility = Visibility.Hidden;
                    Button_Product_Delete.Visibility = Visibility.Hidden;
                    Button_Product_Update.Visibility = Visibility.Hidden;

                    employee.Visibility = Visibility.Hidden;
                    break;
            }
        }


        // Event handler for the SelectionChanged event
        private void ComboBox_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected customer from the ComboBox
             selectedCategory = ComboBox_Category.SelectedItem as Category;

            // Check if the selected item is not the hint item
            if (selectedCategory != null && selectedCategory.CategoryID != -1)
            {

                int categoryID = Convert.ToInt32(selectedCategory.CategoryID);
                string catName = selectedCategory.CategoryName.ToString();
               // ProductDetails(categoryID);

            }
            
        }

        private List<Category> LoadCategoryFromDatabase()
        {
            List<Category> categories = new List<Category>();


            string query = "SELECT Category_ID, Category_Name FROM TBL_Category";

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int categoryID = Convert.ToInt32(reader["Category_ID"]);
                                string categoryName = reader["Category_Name"].ToString();
                                categories.Add(new Category { CategoryID = categoryID, CategoryName = categoryName });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return categories;
        }


        public void ProductsDetails()
        {
            connection.Open();
            string readString = "Select Product_ID, Product_Name, Product_QTY, Unit_Price, Category_ID from TBL_Product";
            SqlCommand command = new SqlCommand(readString, connection);
            DataTable dataTable = new DataTable();
            SqlDataReader tableinfo = command.ExecuteReader();
            dataTable.Load(tableinfo);
            connection.Close();
            DataGrid_Product_Details.ItemsSource = dataTable.DefaultView;


        }
        private void Button_ProductAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (selectedCategory!=null && selectedCategory.CategoryID!=-1 && !String.IsNullOrEmpty(TextBox_Name.Text) && !String.IsNullOrEmpty(TextBox_UnitPrice.Text)
                     && !String.IsNullOrEmpty(TextBox_Quantity.Text))
                {
                    bool isProductNameAlreadyExists = false;
                    foreach (var item in DataGrid_Product_Details.ItemsSource)
                    {
                        DataRowView dataRowView = (DataRowView) item;
                        String itemName = (string) dataRowView.Row[1];
                        if(itemName.Equals(TextBox_Name.Text))
                        {
                            isProductNameAlreadyExists = true; 
                            break;
                        }
                    }
                    if (!isProductNameAlreadyExists)
                    {

                        SqlCommand command = new SqlCommand($"INSERT INTO TBL_Product (Product_Name, Product_QTY, Unit_Price, Category_ID) Values ('" + TextBox_Name.Text + "', '" + Convert.ToInt32(TextBox_Quantity.Text) + "', '" + Convert.ToDecimal(TextBox_UnitPrice.Text) + "', '" + selectedCategory.CategoryID + "')", connection);
                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();

                        MessageBox.Show("!!! Successfully Added the new Product !!!");
                        ProductsDetails();
                        ClearTextBox();
                    } else
                    {
                        MessageBox.Show("!!!!! Product with same name already exists !!!!");
                    }
                }

                else
                {
                    MessageBox.Show("!!!!! Make sure you entered data in all fields !!!!");
                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

      
        private void Button_ProductUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid_Product_Details.SelectedItem != null)
                {
                    if (selectedCategory != null && selectedCategory.CategoryID != -1 && TextBox_Name.Text!=null && TextBox_UnitPrice.Text!=null &&
                        Convert.ToDecimal(TextBox_UnitPrice.Text) > 0 && TextBox_Quantity.Text != null && Convert.ToInt32(TextBox_Quantity.Text) > 0)
                    {
                        DataRowView dataRowView = (DataRowView)DataGrid_Product_Details.SelectedItem;
                        ID = Convert.ToInt32(dataRowView.Row[0]);
                        String productName = TextBox_Name.Text;
                        decimal uPrice =Convert.ToDecimal(TextBox_UnitPrice.Text);
                        int Quantity = Convert.ToInt32(TextBox_Quantity.Text);
                        int categoryID = Convert.ToInt32(selectedCategory.CategoryID);

                        SqlCommand command = new SqlCommand($"UPDATE TBL_Product SET Product_Name ='" + productName + "', Product_QTY ='" + Quantity + "', Unit_Price='" + uPrice + "', Category_ID='" + categoryID + "' Where Product_ID = '" + ID + "' ", connection);
                        // SqlCommand command = new SqlCommand("UPDATE TBL_Login SET User_Name = @User, Password = @Password, Role = @Role, Full_Name = @FName, Contact_No = @Contact WHERE User_ID = @ID", connection);
                        connection.Open();
                        command.ExecuteReader();
                        connection.Close();

                        ProductsDetails();
                        ClearTextBox();

                    }
                    else { MessageBox.Show("!!! Please enter valid data in all fields !!"); }
                    

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Button_ProductDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_Product_Details.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_Product_Details.SelectedItem;
                int ID = Convert.ToInt32(dataRowView.Row[0]);

                SqlCommand command = new SqlCommand($"DELETE FROM TBL_Product where Product_ID = '" + ID + "'", connection);

                connection.Open();
                command.ExecuteReader();
                connection.Close();

                ProductsDetails();
                ClearTextBox();

            }

        }

        private void ClearTextBox()
        {
            ComboBox_Category.SelectedIndex = 0;
            TextBox_Name.Text = string.Empty;
            TextBox_UnitPrice.Text = string.Empty;
            TextBox_Quantity.Text = string.Empty;
           

        }

        private void DataGrid_Product_Details_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_Product_Details.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_Product_Details.SelectedItem;
                ID = Convert.ToInt32(dataRowView.Row[0]);
                String ProductName = dataRowView.Row[1].ToString();
                int QTY = Convert.ToInt32(dataRowView.Row[2]);
                decimal unitPrice = Convert.ToDecimal(dataRowView.Row[3]);
                int cID = Convert.ToInt32(dataRowView.Row[4]);
                //String Contact = dataRowView.Row[5].ToString();

                int categoryPosition = -1;
                for(int i = 0; i<categoryList.Count; i++)
                {
                    if (categoryList[i].CategoryID == cID)
                    {
                        categoryPosition = i;
                        break;
                    }
                }
                ComboBox_Category.SelectedIndex = categoryPosition;
                TextBox_Name.Text = ProductName;
                TextBox_Quantity.Text = QTY.ToString();
                TextBox_UnitPrice.Text = unitPrice.ToString();
            }
        }

        private class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
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
