using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Form1.xaml
    /// </summary>
    public partial class Form1 : Window
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Java-файл (*.java) | *.java";
            open.ShowDialog();
            string path = open.FileName;
            StreamReader sr = new StreamReader(path);
            string s = sr.ReadToEnd();
            sr.Close();
            textBox1.Text = s;
            Regex re = new Regex(@"\w+\((\w*\s*\,*)*\)\w*\s*\n?\{");
            MatchCollection mc = re.Matches(s);
            int hit = HIT(s);
            label1.Content = "Кількість методів (NOM) - " + mc.Count.ToString();
            label1.Content += Environment.NewLine + "Глибина дерева наслідування (HIT) - " + hit.ToString();

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private int HIT(string text)
        {
            int count = 0;
            Regex re = new Regex(@"\w+\s+extends\s+\w+");
            var mc = re.Matches(text);
            Hashtable hash = new Hashtable();
            foreach (Match m in mc)
            {
                string str = m.Value;
                string first = str.Substring(0, str.IndexOf("extends") - 1);
                string second = str.Substring(str.IndexOf("extends") + 8);
                hash.Add(first, second);
            }
            List<string> list = hash.Keys.Cast<string>().ToList();
            List<string> list2 = hash.Values.Cast<string>().ToList();
            list.AddRange(list2);
            for (int i = 0; i < list.Count; i++)
            {
                int counts = 0;
                string ins = list[i];
                while (true)
                {
                    if (hash.ContainsKey(ins))
                    {
                        ins = (string)hash[ins];
                        counts++;
                    }
                    else break;

                }
                if (counts > count) count = counts;
            }
            return count;
        }

    }
}
