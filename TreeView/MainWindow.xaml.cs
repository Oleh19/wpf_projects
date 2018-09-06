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

namespace TreeView
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

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = tv1.SelectedItem as TreeViewItem;

            MessageBox.Show(item.Header.ToString());
        }

        private void TreeView_SelectedItemChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            String name = tv2.SelectedValue.ToString();
            MessageBox.Show(name);
        }
    }
}
