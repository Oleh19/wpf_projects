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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Editor editor = new Editor();
            if(editor.ShowDialog() == true)
            {
                MessageBox.Show("Album was successfully added!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("All updates will be inforced with next programm executing!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
