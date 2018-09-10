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
using System.Xml.Linq;

namespace Shop
{
    /// <summary>
    /// Interaction logic for EditingGoodWindow.xaml
    /// </summary>
    public partial class EditingGoodWindow : Window
    {
        XDocument doc;
        string path = @"..\..\Data\Goods.xml";

        public EditingGoodWindow()
        {
            InitializeComponent();
            doc = XDocument.Load(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var goods = doc.Element("root").Elements("product").Where(el => el.Attribute("id").Value == ID.Text);

            XElement elem = new XElement("product",
                    new XAttribute("categoryID", categoryID.Text),
                    new XAttribute("id", ID.Text),
                    new XAttribute("Name", Name.Text),
                    new XAttribute("ManufacturerId", ManufacturerId.Text),
                    new XAttribute("Manufacturer", Manufacturer.Text),
                    new XAttribute("Price", Price.Text),
                    new XAttribute("Amount", Amount.Text)
                );

            goods.ElementAt(0).ReplaceWith(elem);
            doc.Save(path);

            MessageBox.Show("Good has been edited!");

            this.DialogResult = true;
        }
    }
}
