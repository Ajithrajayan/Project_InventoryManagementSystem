using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
    /// <summary
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public ObservableCollection<OrderDataItem> DataItems { get; set; }
        string Role;

        private Customer selectedCustomer;
        private Category selectedCategory;
        private DataTable productDataTable;

        public Orders(string userType)
        {
            this.Role = userType;
            InitializeComponent();
            showViews();

            // Load customer names from the database and set as the ComboBox's item source
            List<Customer> customers = LoadCustomersFromDatabase();
            // Add a hint item at the beginning of the list
            customers.Insert(0, new Customer { CustomerID = -1, CustomerName = "Select Customer" });
            customerComboBox.ItemsSource = customers;
            customerComboBox.SelectedIndex = 0; // Set the selected index to display the hint
            customerComboBox.SelectionChanged += CustomerComboBox_SelectionChanged;// Attach the SelectionChanged event handler

            // Load category names from the database and set as the ComboBox's item source
            List<Category> categories = LoadCategoryFromDatabase();
            // Add a hint item at the beginning of the list
            categories.Insert(0, new Category { CategoryID = -1, CategoryName = "Select Category" });
            categoryComboBox.ItemsSource = categories;
            categoryComboBox.SelectedIndex = 0; // Set the selected index to display the hint                               
            categoryComboBox.SelectionChanged += CategoryComboBox_SelectionChanged;// Attach the SelectionChanged event handler

            DataItems = new ObservableCollection<OrderDataItem>();
            DataGrid_OrderData.ItemsSource = DataItems;


        }

        private void showViews()
        {
            switch (Role)
            {
                case "A":
                    

                    employee.Visibility = Visibility.Visible;

                    break;

                case "E":
                    
                    employee.Visibility = Visibility.Hidden;
                    break;
            }
        }


        // Event handler for the SelectionChanged event
        private void CustomerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected customer from the ComboBox
            selectedCustomer = customerComboBox.SelectedItem as Customer;

            // Check if the selected item is not the hint item
            if (selectedCustomer != null && selectedCustomer.CustomerID != -1)
            {
                // Handle the selected customer
                //MessageBox.Show($"Selected Customer: {selectedCustomer.CustomerName} (ID: {selectedCustomer.CustomerID})");
                TextBox_Customer_ID.Text= selectedCustomer.CustomerID.ToString();
                TextBox_Customer_Name.Text= selectedCustomer.CustomerName.ToString();
            }
            else
            {
                // Handle the case where the hint item is selected (optional)
                // MessageBox.Show("Please select a valid customer.");
                TextBox_Customer_ID.Text = string.Empty;
                TextBox_Customer_Name.Text = string.Empty;
            }
        }

        // Event handler for the SelectionChanged event
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected customer from the ComboBox
            selectedCategory = categoryComboBox.SelectedItem as Category;

            // Check if the selected item is not the hint item
            if (selectedCategory != null && selectedCategory.CategoryID != -1)
            {
               
                int categoryID = Convert.ToInt32(selectedCategory.CategoryID);
                string catName = selectedCategory.CategoryName.ToString();
                productDataTable = GetProductDataFromDatabase(categoryID);
                DataGrid_ProductList.ItemsSource = productDataTable.DefaultView;

            }
            else
            {
                // Handle the case where the hint item is selected (optional)
                //MessageBox.Show("Please select a valid category.");
                productDataTable.Rows.Clear();
            }
        }

        private DataTable GetProductDataFromDatabase(int categoryID)
        {
            int cID = categoryID;
            DataTable productDataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True"))
                {
                    connection.Open();

                    string sqlQuery = "Select Product_ID, Product_Name, Product_QTY, Unit_Price, Category_ID from TBL_Product Where Category_ID = '" + cID + "' ";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
                    {
                        adapter.Fill(productDataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return productDataTable;
        }
/*        public void ProductDetails(int categoryID)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");
            int cID = categoryID;
            connection.Open();
            // string readString = "select * from TBL_Product where Category_ID = '" + cID + "' ";
            string readString = "Select Product_ID, Product_Name, Product_QTY, Unit_Price from TBL_Product Where Category_ID = '"+cID+"' ";
            DataTable produProductDetailsctDataTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(readString, connection))
            {
                adapter.Fill(productDataTable);
            }
           // SqlCommand command = new SqlCommand(readString, connection);
            
           // SqlDataReader tableinfo = command.ExecuteReader();
            productDataTable.Load(tableinfo);
            connection.Close();

            DataGrid_ProductList.ItemsSource = productDataTable.DefaultView;
           // DataGrid_EmployeeData.ItemsSource = dataTable.DefaultView;


        }
*/


        private void Button_ProductAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //check if customer is selected
                if (!(selectedCustomer != null && selectedCustomer.CustomerID != -1))
                {
                    MessageBox.Show("Please select a customer.");
                    return;
                }

                //check if category is selected
                else if (!(selectedCategory != null && selectedCategory.CategoryID != -1))
                {
                    MessageBox.Show("Please select a category.");
                    return;
                }

                //check if product is selected from grid
                else if(DataGrid_ProductList.SelectedItem == null)
                {
                    MessageBox.Show("Please select a product.");
                    return;
                }
                // add product to order grid
                else
                {
                    DataRowView dataRowView = (DataRowView)DataGrid_ProductList.SelectedItem;

                    // int ID = Convert.ToInt32(dataRowView.Row[0]);
                    QuantityInputDialog dialog = new QuantityInputDialog(DataItems, dataRowView);
                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        int capturedQuantity = dialog.Quantity;
                        // Use the capturedQuantity as needed

                        int ID = Convert.ToInt32(dataRowView.Row[0]);

                        String Product_Name = dataRowView.Row[1].ToString();

                        int Product_QTY = capturedQuantity;
                        decimal Unit_Price = Convert.ToDecimal(dataRowView.Row[3]);
                        int Category_ID = Convert.ToInt32(dataRowView.Row[4]);


                        // Assuming you have a set of values to add (replace with your actual data)
                        OrderDataItem newData = new OrderDataItem
                        {
                            PID = ID,
                            PName = Product_Name,
                            PQTY = Product_QTY,
                            Uprice = Unit_Price,
                            Amout = Unit_Price * Product_QTY,
                            CategoryName = selectedCategory.CategoryName

                        };


                        DataItems.Add(newData);
                        DataGrid_ProductList.SelectedItem = null;

                        refreshTotalOrderAmount();

                    }
                    else
                    {
                        DataGrid_ProductList.SelectedItem = null;
                    }
                }
                    
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }


        }

        private void refreshTotalOrderAmount()
        {
            decimal totalOrderAmt = 0;
            for (int i = 0; i < DataItems.Count; i++)
            {
                totalOrderAmt = totalOrderAmt + (DataItems[i].PQTY * DataItems[i].Uprice);
            }

            if(totalOrderAmt > 0)
            {
                TextBox_Total_Amount.Text = totalOrderAmt.ToString();
            } else
            {
                TextBox_Total_Amount.Text = string.Empty;
            }
          
        }

        private void Button_ShowPreviousOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_OrderDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid_OrderData.SelectedItem != null)
                {
                    OrderDataItem orderDataItem = (OrderDataItem)DataGrid_OrderData.SelectedItem;
                    int ID = orderDataItem.PID;
                    double Qty = orderDataItem.PQTY;

                    int posToDelete = -1;
                    for (int i = 0; i < DataItems.Count; i++)
                    {
                        if (DataItems[i].PID == ID && DataItems[i].PQTY == Qty) { 
                            posToDelete = i; 
                            break;
                        }
                    }

                    if(posToDelete  > -1)
                    {
                        DataItems.Remove(DataItems[posToDelete]);
                        refreshTotalOrderAmount();
                    }

                }


            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }

        private void Button_ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            if(DataItems.Count > 0)
            {
                //SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");
                saveOrderIntoDatabase();
                
            }
            else
            {
                MessageBox.Show("Please add products to confirm your order.");
            }
        }

        private async void saveOrderIntoDatabase()
        {
            string connectionString = @"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True";

            try
            {
                progressBar.Visibility = Visibility.Visible;
                progressBar.Maximum = DataItems.Count;

                int maxOrderId = GetMaxOrderId(connectionString);
                int currentOrderID = maxOrderId + 1;

                // Insert rows into TBL_OrderLineItems within a loop
                int lineNumber = 1;
                Dictionary<int, decimal> orderedItemIdQtyPair = new Dictionary<int, decimal>();
                foreach (var item in DataItems)
                {
                    await InsertOrderLineItemAsync(connectionString, item, currentOrderID, lineNumber);
                    progressBar.Value++;
                    lineNumber++;

                    //find total qty ordered of each product, this is used to reduce stock
                    if(orderedItemIdQtyPair.ContainsKey(item.PID))
                    {
                        decimal totalQtyOfItem = orderedItemIdQtyPair.GetValueOrDefault(item.PID);
                        totalQtyOfItem = totalQtyOfItem + item.PQTY;
                        orderedItemIdQtyPair[item.PID] = totalQtyOfItem;
                    }
                    else
                    {
                        orderedItemIdQtyPair.Add(item.PID, item.PQTY);
                    }
                }

                // Insert a single row into TBL_Order
                await InsertOrderAsync(connectionString, currentOrderID);

                //update product stock
                await UpdateProductStockAsync(connectionString, orderedItemIdQtyPair);

                // Optionally, update the UI or perform other actions after successful insertion                
                //show order confirmed dialog
                string orderDetails = $"Order ID: {currentOrderID}\nTotal Amount: CAD {TextBox_Total_Amount.Text}";
                int orderID = currentOrderID;
                clearAllData();

                progressBar.Visibility = Visibility.Collapsed;

                OrderConfirmationDialog orderConfirmationDialog = new OrderConfirmationDialog(orderID, orderDetails);
                orderConfirmationDialog.ShowDialog();

         

            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Reset progress bar value
                progressBar.Value = 0;
            }
        }

        private void clearAllData()
        {
            DataItems.Clear();
            customerComboBox.SelectedIndex = 0; // Set the selected index to display the hint
            categoryComboBox.SelectedIndex = 0;
            TextBox_Total_Amount.Text = string.Empty;
        }

        private int GetMaxOrderId(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MAX(Order_ID) FROM TBL_Order";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // ExecuteScalar is used to retrieve a single value (in this case, the maximum Order_ID)
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        // Convert the result to an integer
                        return Convert.ToInt32(result);
                    }
                }
            }

            // If no records or NULL values are found, return a default value (you can change this based on your requirement)
            return 0;
        }

        private async Task InsertOrderLineItemAsync(string connectionString, OrderDataItem item, int currentOrderID, int lineNumber)
        {
            String lineNumberString = lineNumber.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO TBL_OrderLineItems (Order_ID, Line_Number, Product_ID, Product_Name, Category_ID, Category_Name, Unit_Price, QTY, Amount) " +
                    "VALUES (@Order_ID, @Line_Number, @Product_ID, @Product_Name, @Category_ID, @Category_Name, @Unit_Price, @QTY, @Amount)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Order_ID", currentOrderID);
                    command.Parameters.AddWithValue("@Line_Number", lineNumberString);
                    command.Parameters.AddWithValue("@Product_ID", item.PID);
                    command.Parameters.AddWithValue("@Product_Name", item.PName);
                    command.Parameters.AddWithValue("@Category_ID", item.CategoryID);
                    command.Parameters.AddWithValue("@Category_Name", item.CategoryName);
                    command.Parameters.AddWithValue("@Unit_Price", item.Uprice);
                    command.Parameters.AddWithValue("@QTY", item.PQTY);
                    command.Parameters.AddWithValue("@Amount", item.Amout);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task InsertOrderAsync(string connectionString, int currentOrderID)
        {
            int customerID = int.Parse(TextBox_Customer_ID.Text);
            decimal totalAmt = decimal.Parse(TextBox_Total_Amount.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // Insert a single row into TBL_Order
                string orderQuery = "INSERT INTO TBL_Order (Order_ID, Customer_ID, Customer_Name, Total_amount, Creation_date) " +
                    "VALUES (@Order_ID, @Customer_ID, @Customer_Name, @Total_amount, @Creation_date)";
               
                using (SqlCommand orderCommand = new SqlCommand(orderQuery, connection))
                {
                    orderCommand.Parameters.AddWithValue("@Order_ID", currentOrderID); 
                    orderCommand.Parameters.AddWithValue("@Customer_ID", customerID); 
                    orderCommand.Parameters.AddWithValue("@Customer_Name", TextBox_Customer_Name.Text); 
                    orderCommand.Parameters.AddWithValue("@Total_amount", totalAmt); 
                    orderCommand.Parameters.AddWithValue("@Creation_date", GetCurrentDateTime()); 

                    await orderCommand.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task UpdateProductStockAsync(string connectionString, Dictionary<int, decimal> productQuantitiesToUpdate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    foreach (var kvp in productQuantitiesToUpdate)
                    {
                        int productId = kvp.Key;
                        decimal quantityToUpdate = kvp.Value;

                        // Set @QuantityToUpdate to the negative value to subtract from Product_Qty
                        string updateQuery = "UPDATE TBL_Product SET Product_QTY = Product_QTY + @QuantityToUpdate WHERE Product_ID = @ProductId";

                        using (SqlCommand command = new SqlCommand(updateQuery, connection))
                        {
                            // Add parameters to the command
                            command.Parameters.AddWithValue("@QuantityToUpdate", -quantityToUpdate); // Set to the negative value
                            command.Parameters.AddWithValue("@ProductId", productId);

                            // Execute the command asynchronously
                            int rowsAffected = await command.ExecuteNonQueryAsync();

                            if (rowsAffected <= 0)
                            {
                                MessageBox.Show($"Product {productId}: Not found or quantity not updated.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private string GetCurrentDateTime()
        {
            // Get the current date and time
            DateTime currentDateTime = DateTime.Now;

            // Format it in "yyyy-MM-dd HH:mm:ss" format
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            return formattedDateTime;
        }

        private List<Customer> LoadCustomersFromDatabase()
        {
            List<Customer> customers = new List<Customer>();

            // Connection string for your database
            //SqlConnection connection = new SqlConnection(@"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True");
           // string connectionString = "your_connection_string_here";

            // SQL query to select customer ID and name
            string query = "SELECT Customer_ID, Customer_FName, Customer_LName FROM TBL_Customer";

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
                                int customerID = Convert.ToInt32(reader["Customer_ID"]);
                                string customerName = reader["Customer_FName"].ToString() + " " + reader["Customer_LName"].ToString();
                                customers.Add(new Customer { CustomerID = customerID, CustomerName = customerName });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return customers;
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


        // Create a simple Customer class with properties for CustomerID and CustomerName
        private class Customer
        {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
        }
        private class Category 
        {
            public int CategoryID { get; set;}
            public string CategoryName { get; set; }
        }
        public class OrderDataItem  
        {
            public int PID { get; set; }
            public string PName { get; set; }
            public int PQTY { get; set; }
            public decimal Uprice { get; set; }
            public decimal Amout { get; set; }
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }

        private void DataGrid_ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid_ProductList.SelectedItem != null)
            {
                DataRowView dataRowView = (DataRowView)DataGrid_ProductList.SelectedItem;

                int ID = Convert.ToInt32(dataRowView.Row[0]);

                String Product_Name = dataRowView.Row[1].ToString();

                int Product_QTY = Convert.ToInt32(dataRowView.Row[2]); 
                decimal Unit_Price = Convert.ToDecimal(dataRowView.Row[3]); 
                int Category_ID = Convert.ToInt32(dataRowView.Row[4]); 
                

                

                

                // TextBox_Password.Text=String.Empty;

            }
        }

        private void DataGrid_OrderData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void customerComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_Customer_ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

    public class AmountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double Uprice && parameter is int PQTY)
            {
                return Uprice * PQTY;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
