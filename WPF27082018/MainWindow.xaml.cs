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

namespace WPF27082018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlDataProvider xdp;
        public MainWindow()
        {
            InitializeComponent();
            xdp = (XmlDataProvider)this.FindResource("provider2");
        }

        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = list1.SelectedIndex + 1;
            Binding b = new Binding();
            b.Source = xdp;
            b.XPath = $"student[@gid={k}]";
            list2.SetBinding(ListBox.ItemsSourceProperty, b);
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in panel1.Children)
                if (item is TextBox)
                    (item as TextBox).Clear();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            var elems = panel1.Children;
            List<string> studentInfo = new List<string>();

            foreach (var item in panel1.Children)
                if (item is TextBox)
                    studentInfo.Add((item as TextBox).Text);

            XmlDocument doc = new XmlDocument();
            string path = @"..\..\Data\students.xml";
            doc.Load(path);

            string[] strings = new string[] { "id", "name", "age", "rate", "gid", "gname" };
            XmlElement root = doc.DocumentElement;
            XmlElement node = doc.CreateElement("student");

            XmlAttribute[] attributes = new XmlAttribute[strings.Length];
            for (int i = 0; i < strings.Length; i++)
                 attributes[i] = doc.CreateAttribute(strings[i]);

            XmlText[] texts = new XmlText[strings.Length];
            for (int i = 0; i < strings.Length; i++)
                texts[i] = doc.CreateTextNode(studentInfo[i]);

            for (int i = 0; i < strings.Length; i++)
                attributes[i].AppendChild(texts[i]);

            for (int i = 0; i < strings.Length; i++)
                node.Attributes.Append(attributes[i]);

            root.AppendChild(node);
            doc.Save(path);
            xdp.Document = doc;
        }
    }
}
