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

namespace AnimationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawShapes();
        }

        private void DrawShapes()
        {

            const int N = 5;
            Rectangle[] arr = new Rectangle[N];
            for (int i = 0;i < N;i++)
            {
                arr[i] = new Rectangle();
                arr[i].Width = 50;
                arr[i].Height = 300;
                arr[i].Fill = new SolidColorBrush(Color.FromRgb((byte)(70 * i), (byte)(130 * i), (byte)(300 * i)));
                arr[i].Stroke = Brushes.Red;
                arr[i].StrokeThickness = 3;

                Canvas.SetLeft(arr[i], 50 + i*50);
                Canvas.SetTop(arr[i], 50);

                canvas.Children.Add(arr[i]);
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi!");
        }
    }
}
