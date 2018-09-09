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
    /// Interaction logic for RemovingWindow.xaml
    /// </summary>
    public partial class RemovingWindow : Window
    {
        XDocument doc;
        string path = @"..\..\Data\Categories.xml";

        public RemovingWindow()
        {
            InitializeComponent();
            doc = XDocument.Load(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var elements = doc.Element("root").Elements("category").Where(b => b.Attribute("name").Value == name.Text);
            if (elements.Count() > 0)
            {

                foreach (var node in elements)
                    node.Remove();

                MessageBox.Show("Category has been removed!");
                this.DialogResult = true;

                doc.Save(path);
            }
            else
                MessageBox.Show("There is no such a category");
        }
    }
}
