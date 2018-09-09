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
using System.Xml;

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            int category_id = categoriesComboBox.SelectedIndex;
            int producer_id = manufacturersComboBox.SelectedIndex;

            XmlDataProvider xdp = (XmlDataProvider)FindResource("goodsProvider");
            Binding binding = new Binding();
            binding.Source = xdp;

            if (category_id > 0 && producer_id == 0)
                binding.XPath = $"product[@categoryID={category_id}]";
            else if (category_id == 0 && producer_id > 0)
                binding.XPath = $"product[@ManufacturerId={producer_id}]";
            else if (category_id > 0 && producer_id > 0)
                binding.XPath = $"product[@categoryID={category_id} and @ManufacturerId={producer_id}]";
            else
                binding.XPath = "product";

            goodsListView.SetBinding(ListView.ItemsSourceProperty, binding);
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please select a good!");
            }
            else
            {
                MessageBox.Show("Your order:" + Environment.NewLine + nameLabel.Content + " " + nameTextBox.Text + Environment.NewLine
                    + manufacturerLabel.Content + " " + manufacturerTextBox.Text + Environment.NewLine
                     + amountLabel.Content + " " + amountTextBox.Text + Environment.NewLine
                     + "Total " + priceLabel.Content + " " + (Int32.Parse(priceTextBox.Text) * Int32.Parse(amountTextBox.Text)).ToString()
                     );
            }
        }

        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow adw = new AddingWindow();
            if(adw.ShowDialog() == true)
            {
                XmlDataProvider xdp = (XmlDataProvider)FindResource("categoriesProvider");
                XmlDocument xd = new XmlDocument();
                xd.Load(@"..\..\Data\Categories.xml");
                xdp.Document = xd;
            }
            categoriesComboBox.SelectedIndex = 0;
        }

        private void removeCategory_Click(object sender, RoutedEventArgs e)
        {
            RemovingWindow adw = new RemovingWindow();
            if (adw.ShowDialog() == true)
            {
                XmlDataProvider xdp = (XmlDataProvider)FindResource("categoriesProvider");
                XmlDocument xd = new XmlDocument();
                xd.Load(@"..\..\Data\Categories.xml");
                xdp.Document = xd;
            }
            categoriesComboBox.SelectedIndex = 0;
        }
    }
}
