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
using System.Xml;
using System.Xml.Linq;

namespace Shop
{
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        XDocument doc;
        string path = @"..\..\Data\Categories.xml";

        public AddingWindow()
        {
            InitializeComponent();
            doc = XDocument.Load(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var categories = doc.Element("root").Elements("category").ToList();
            int count = categories.Count;

            string k = "1";
            if (categories != null && count > 0)
                k = count.ToString();

            XElement elem = new XElement("category",
                new XAttribute("id", k),
                new XAttribute("name", name.Text));

            doc.Element("root").Add(elem);
            doc.Save(path);

            MessageBox.Show("Category has been added!");

            this.DialogResult = true;
        }
    }
}
