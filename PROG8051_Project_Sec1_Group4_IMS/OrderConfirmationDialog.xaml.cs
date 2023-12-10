using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO.Packaging;
using System.IO;
using System.Linq;
using System.Printing;
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
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.IdentityModel.Tokens.Jwt;
using System.Xaml;
using System.Reflection.Metadata;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Globalization;

namespace PROG8051_Project_Sec1_Group4_IMS
{
    /// <summary>
    /// Interaction logic for OrderConfirmationDialog.xaml
    /// </summary>
    public partial class OrderConfirmationDialog : Window
    {
        public int orderID;
        public string OrderDetails { get; set; }

        public OrderConfirmationDialog(int orderID, string orderDetails)
        {
            InitializeComponent();
            this.orderID = orderID;
            OrderDetails = orderDetails;
            DataContext = this;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the Print button click
            // Implement your printing logic here
           
            String headerContent = getPrintStringFromDB(orderID);
            List<OrderLineItem> lineItems = RetrieveOrderLineItems(orderID);

            // Create a FlowDocument with the order content
            FlowDocument flowDocument = CreateFlowDocument(headerContent.ToString(), lineItems);

            // Print the FlowDocument
            PrintDocument(flowDocument);

            Close();
        }

        private string getPrintStringFromDB(int orderID)
        {
            string rowFormat = "{0,-5} {1,-65} {2,-20} {3,-25} {4,-25}";

            StringBuilder orderContent = new StringBuilder();

            string connectionString = @"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True";

            // SQL query to retrieve data from TBL_Order
            string orderQuery = "SELECT Customer_Name, Creation_Date, Total_amount FROM TBL_Order where Order_ID = " + orderID;

            try
            {
                // Establish a connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand with the first query and connection
                    using (SqlCommand orderCommand = new SqlCommand(orderQuery, connection))
                    {
                        // Execute the command and retrieve the data
                        using (SqlDataReader orderReader = orderCommand.ExecuteReader())
                        {
                            // Process the retrieved order data
                            while (orderReader.Read())
                            {
                                // Access data from TBL_Order
                                string customerName = orderReader.GetString(0);
                                string orderDate = orderReader.GetString(1);
                                decimal orderAmount = orderReader.GetDecimal(2);

                                orderContent.AppendLine("                                                                            Order");
                                orderContent.AppendLine("");
                                orderContent.AppendLine("");
                                orderContent.AppendLine("Customer Name : " + customerName);
                                orderContent.AppendLine("Order Date : " + orderDate);
                                orderContent.AppendLine("Total Amount : CAD " + orderAmount);
                                orderContent.AppendLine("");
                                /* orderContent.AppendLine("------------------------------------------------------------------------------------------------------------");
                                 orderContent.AppendLine(string.Format(rowFormat, "No.", "Product Name", "Quantity", "Unit Price", "Amount"));
                                 orderContent.AppendLine("------------------------------------------------------------------------------------------------------------");

                                 orderContent = RetrieveOrderLineItems(orderID, orderContent);

                                 orderContent.AppendLine("");
                                 orderContent.AppendLine("------------------------------------------------------------------------------------------------------------");
                                 orderContent.AppendLine("");
                                 orderContent.AppendLine("");
                                 orderContent.AppendLine("Total Amount : CAD " + orderAmount);
 */
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, display an error message, etc.)
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return orderContent.ToString();

        }

        private List<OrderLineItem> RetrieveOrderLineItems(int orderId)
        {
            List<OrderLineItem> orderLineItems = new List<OrderLineItem>();

            string rowFormat = "{0,-5} {1,-65} {2,-20} {3,-25} {4,-25}";

            string connectionString = @"Data Source=AJITHRA\SQLEXPRESS;Initial Catalog=IMSdb;Integrated Security=True";

            // SQL query to retrieve data from TBL_OrderLineItems based on OrderID
            string lineItemsQuery = $"SELECT Product_ID, Product_Name, Unit_Price, QTY, Amount FROM TBL_OrderLineItems WHERE Order_ID = {orderId} ";

            try
            {
                // Establish a connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a SqlCommand with the second query and connection
                    using (SqlCommand lineItemsCommand = new SqlCommand(lineItemsQuery, connection))
                    {
                        // Execute the command and retrieve the data
                        using (SqlDataReader lineItemsReader = lineItemsCommand.ExecuteReader())
                        {
                            // Process the retrieved line items data
                            int slNO = 1;
                            while (lineItemsReader.Read())
                            {
                                // Access data from TBL_OrderLineItems
                                int productID = lineItemsReader.GetInt32(0);
                                string productName = lineItemsReader.GetString(1);
                                decimal unitPrice = lineItemsReader.GetDecimal(2);
                                int qty = lineItemsReader.GetInt32(3);
                                decimal amount = lineItemsReader.GetDecimal(4);

                                /* orderContent.AppendLine(string.Format(rowFormat, AppendSpaces(slNO.ToString(), 5), AppendSpaces(productName, 65), 
                                     AppendSpaces(qty.ToString(), 20), AppendSpaces(unitPrice.ToString(), 25), AppendSpaces(amount.ToString(), 25)));*/

                               
                                orderLineItems.Add(new OrderLineItem(slNO.ToString(), productName, unitPrice.ToString(), qty.ToString(), amount.ToString()));

                                slNO += 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, display an error message, etc.)
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return orderLineItems;
        }


        private FlowDocument CreateFlowDocument(string content, List<OrderLineItem> lineItems)
        {
            FlowDocument flowDocument = new FlowDocument(new Paragraph(new Run(content)));

            Table table = new Table();
            table.BorderBrush = Brushes.Black;
            table.BorderThickness = new Thickness(1);

            // Add columns to the table
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());
            table.Columns.Add(new TableColumn());

            // Create a row group to hold the table rows
            TableRowGroup rowGroup = new TableRowGroup();

            // Create the header row
            TableRow headerRow = new TableRow();
            headerRow.Cells.Add(CreateTableCell("No."));
            headerRow.Cells.Add(CreateTableCell("Product Name"));
            headerRow.Cells.Add(CreateTableCell("Unit Price"));
            headerRow.Cells.Add(CreateTableCell("Quantity"));
            headerRow.Cells.Add(CreateTableCell("Amount"));
            rowGroup.Rows.Add(headerRow);

            // Create data rows
            for (int i = 0; i < lineItems.Count; i++)
            {
                TableRow dataRow = new TableRow();
                dataRow.Cells.Add(CreateTableCell(lineItems[i].slNo));
                dataRow.Cells.Add(CreateTableCell(lineItems[i].pdName));
                dataRow.Cells.Add(CreateTableCell(lineItems[i].usp));
                dataRow.Cells.Add(CreateTableCell(lineItems[i].qty));
                dataRow.Cells.Add(CreateTableCell(lineItems[i].amount));
                rowGroup.Rows.Add(dataRow);
            }

            // Add the row group to the table
            table.RowGroups.Add(rowGroup);

            // Add the table to the FlowDocument
            flowDocument.Blocks.Add(table);

            // Set the FlowDocument to a RichTextBox or another container in your WPF application
           // richTextBox.Document = flowDocument;



            return flowDocument;
        }

        private TableCell CreateTableCell(string text)
        {
            TableCell cell = new TableCell(new Paragraph(new Run(text)));
            cell.BorderBrush = Brushes.Black;
            cell.BorderThickness = new Thickness(1);
            return cell;
        }

        private void PrintDocument(FlowDocument document)
        {
            // Clone the source document's content into a new FlowDocument.
            // This is because the pagination for the printer needs to be
            // done differently than the pagination for the displayed page.
            // We print the copy, rather that the original FlowDocument.
            System.IO.MemoryStream s = new System.IO.MemoryStream();
            TextRange source = new TextRange(document.ContentStart, document.ContentEnd);
            source.Save(s, DataFormats.Xaml);
            FlowDocument copy = new FlowDocument();
            TextRange dest = new TextRange(copy.ContentStart, copy.ContentEnd);
            dest.Load(s, DataFormats.Xaml);

            // Create a XpsDocumentWriter object, implicitly opening a Windows common print dialog,
            // and allowing the user to select a printer.

            // get information about the dimensions of the seleted printer+media.
            System.Printing.PrintDocumentImageableArea ia = null;
            System.Windows.Xps.XpsDocumentWriter docWriter = System.Printing.PrintQueue.CreateXpsDocumentWriter(ref ia);

            if (docWriter != null && ia != null)
            {
                DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;

                // Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
                paginator.PageSize = new Size(ia.MediaSizeWidth, ia.MediaSizeHeight);
                Thickness t = new Thickness(72);  // copy.PagePadding;
                copy.PagePadding = new Thickness(
                                 Math.Max(ia.OriginWidth, t.Left),
                                   Math.Max(ia.OriginHeight, t.Top),
                                   Math.Max(ia.MediaSizeWidth - (ia.OriginWidth + ia.ExtentWidth), t.Right),
                                   Math.Max(ia.MediaSizeHeight - (ia.OriginHeight + ia.ExtentHeight), t.Bottom));

                copy.ColumnWidth = double.PositiveInfinity;
                //copy.PageWidth = 528; // allow the page to be the natural with of the output device

                // Send content to the printer.
                docWriter.Write(paginator);
            }
        }



        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle the Cancel button click
            Close();
        }

    }

     class OrderLineItem
    {
        public string slNo { get; set; }
        public string pdName { get; set; }
        public string usp { get; set; }
        public string qty { get; set; }
        public string amount { get; set; }

        public OrderLineItem(string slNo, string pdName, string usp, string qty, string amount)
        {
            this.slNo = slNo;
            this.pdName = pdName;
            this.usp = usp;
            this.qty = qty;
            this.amount = amount;
        }
    } 
}
