using System;
using System.Collections.Generic;
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

namespace PROG8051_Project_Sec1_Group4_IMS
{
    /// <summary>
    /// Interaction logic for QuantityInputDialog.xaml
    /// </summary>
   
    public partial class QuantityInputDialog : Window
    {
        private System.Collections.ObjectModel.ObservableCollection<Orders.OrderDataItem> allDataItems;
        private System.Data.DataRowView dataRowViewSelected;
        public int Quantity { get; private set; }

        public QuantityInputDialog(System.Collections.ObjectModel.ObservableCollection<Orders.OrderDataItem> dataItems, System.Data.DataRowView dataRowView)
        {
            this.allDataItems = dataItems;
            this.dataRowViewSelected = dataRowView;
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
           // int Product_QTY = Convert.ToInt32(dataRowView.Row[2]);
            if (int.TryParse(quantityTextBox.Text, out int quantity))
            {
                double qtyAlreadyEnteredForSameItem = 0;
                for (int i = 0; i < allDataItems.Count; i++)
                {
                    if (allDataItems[i].PID == Convert.ToInt32(dataRowViewSelected.Row[0]))
                    {
                        qtyAlreadyEnteredForSameItem += allDataItems[i].PQTY;
                    }
                }

                    if ((Convert.ToInt32(quantityTextBox.Text) + + qtyAlreadyEnteredForSameItem) > Convert.ToInt32(dataRowViewSelected.Row[2])) {

                    MessageBox.Show("Entered quantity cannot exceed available stock", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    Quantity = quantity;
                    DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

}
