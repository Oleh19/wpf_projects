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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\Data\albums.xml";
            XDocument doc = XDocument.Load(path);

            doc.Element("root").Add(
                new XElement("album", 
                new XAttribute("id", id.Text),
                new XAttribute("title", title.Text),
                new XAttribute("band", band.Text),
                new XAttribute("year", year.Text),
                new XAttribute("rate", rate.Text)
                )
            );
            doc.Save(path);

            this.DialogResult = true;
        }
    }
}
