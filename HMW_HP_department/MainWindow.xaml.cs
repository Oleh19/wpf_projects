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

namespace HMW_HP_department
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

        private void list1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = list1.SelectedIndex + 1;
            XmlDataProvider xdp = (XmlDataProvider)this.FindResource("provider2");
            Binding b = new Binding();
            b.Source = xdp;
            b.XPath = $"worker[@did={k}]";
            list2.SetBinding(ListBox.ItemsSourceProperty, b);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new WorkerAdding();
            if (addWindow.ShowDialog() == true)
                MessageBox.Show("Worker has beed added.");
        }
    }
}
