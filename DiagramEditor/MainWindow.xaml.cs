using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;

namespace DiagramEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XDocument doc;
        string path = @"..\..\Data.xml";

        public MainWindow()
        {
            InitializeComponent();
            doc = XDocument.Load(path);
        }

        private void addButt_Click(object sender, RoutedEventArgs e)
        {
            var elements = doc.Element("root").Elements("element").ToList();
            int count = elements.Count;

            string k = "1";
            if (elements != null && count > 0)
                k = (count + 1).ToString();

            XElement elem = new XElement("element",
                 new XAttribute("id", k),
                new XAttribute("legend", legendTb.Text),
                new XAttribute("value", valueTb.Text)
                );
            doc.Element("root").Add(elem);
            doc.Save(path);

            RefreshData();
        }

        private void buildButt_Click(object sender, RoutedEventArgs e)
        {
            if (dataList.Items.Count == 0)
                return;

            coordinatesFiled.Children.Clear();

            legendTb.Text = (dataList.Items[0] as XmlElement).Attributes[0].Value.ToString();

            List<Rectangle> rectangleList = new List<Rectangle>();
            XmlElement elem;

            List<int> heightsList = new List<int>();
            int x, y;

            for (int i = 0; i < dataList.Items.Count; i++)
            {
                elem = (dataList.Items[i] as XmlElement);
                rectangleList.Add(new Rectangle());
                rectangleList[i].Width = 50;
                rectangleList[i].Height = 0;
                heightsList.Add(Int32.Parse(elem.GetAttribute("value")) / 10);
                rectangleList[i].Fill = new SolidColorBrush(Color.FromRgb((byte)(70 * i), (byte)(130 * i), (byte)(300 * i)));
                rectangleList[i].Stroke = Brushes.Red;
                rectangleList[i].StrokeThickness = 3;

                x = 50 + i * 50;
                y = 150;
                Canvas.SetLeft(rectangleList[i], x);
                Canvas.SetBottom(rectangleList[i], y);

                coordinatesFiled.Children.Add(rectangleList[i]);

                Label legend = new Label();
                legend.FontSize = 16;
                legend.Width = 220;
                legend.HorizontalContentAlignment = HorizontalAlignment.Right;
                legend.Content = elem.GetAttribute("legend");
                legend.LayoutTransform = new RotateTransform(-90);

                Canvas.SetLeft(legend, x);
                Canvas.SetBottom(legend, y - 220);

                coordinatesFiled.Children.Add(legend);
            }

            var timer = new DispatcherTimer();
            timer.Tick += (o, p) =>
            {
                for(int i = 0;i < rectangleList.Count;i++)
                {
                    if (rectangleList[i].Height == heightsList[i])
                    {
                        rectangleList.RemoveAt(i);
                        heightsList.RemoveAt(i);
                    }
                    else
                        rectangleList[i].Height++;
                }
                if (rectangleList.Count == 0)
                    timer.Stop();
            };
            timer.Interval = new TimeSpan(10000);
            timer.Start();
        }

        private void RefreshData()
        {
            XmlDataProvider xdp = (XmlDataProvider)FindResource("dataProvider");
            XmlDocument xd = new XmlDocument();
            xd.Load(@"..\..\Data.xml");
            xdp.Document = xd;
        }

        private void removeButt_Click(object sender, RoutedEventArgs e)
        {
            if (dataList.Items.Count == 0 || dataList.SelectedItem == null)
                return;

            string selectedID = dataList.SelectedValue.ToString();

            var elements = doc.Element("root").Elements("element").ToList();

            for(int i = 0;i < elements.Count();i++)
            {
                if(elements.ElementAt(i).Attribute("id").Value == selectedID)
                {
                    elements.ElementAt(i).Remove();
                    elements.Remove(elements[i]);
                    for(int j = i;j < elements.Count();j++)
                    {
                        elements.ElementAt(j).Attribute("id").Value = (j + 1).ToString();
                    }
                    break;
                }
            }

            doc.Save(path);
            RefreshData();
        }

        private void clearButt_Click(object sender, RoutedEventArgs e)
        {
            if (dataList.Items.Count == 0)
                return;

            doc.Element("root").Elements("element").Remove();

            doc.Save(path);
            RefreshData();
        }
    }
}
