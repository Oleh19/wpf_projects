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
    /// Interaction logic for RemovingGoodWindow.xaml
    /// </summary>
    public partial class RemovingGoodWindow : Window
    {
        XDocument doc;
        string path = @"..\..\Data\Goods.xml";

        public RemovingGoodWindow()
        {
            InitializeComponent();
            doc = XDocument.Load(path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var elements = doc.Element("root").Elements("product").Where(b => b.Attribute("id").Value == name.Text);
            if (elements.Count() > 0)
            {
                elements.Remove();

                MessageBox.Show("Good has been removed!");
                this.DialogResult = true;

                doc.Save(path);
            }
            else
                MessageBox.Show("There is no such a good");
        }
    }
}
