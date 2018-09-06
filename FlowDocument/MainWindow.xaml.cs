using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void doc1_Click(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\FlowDocument1.xaml";
            reader.Document = (FlowDocument)XamlReader.Load(File.OpenRead(path));
        }

        private void doc2_Click(object sender, RoutedEventArgs e)
        {
            string path = @"..\..\FlowDocument2.xaml";
            reader.Document = (FlowDocument)XamlReader.Load(File.OpenRead(path));
        }
    }
}
