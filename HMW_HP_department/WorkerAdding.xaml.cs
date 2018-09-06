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
using System.Xml;

namespace HMW_HP_department
{
    /// <summary>
    /// Interaction logic for WorkerAdding.xaml
    /// </summary>
    public partial class WorkerAdding : Window
    {
        XmlDataProvider xdp;
        public WorkerAdding()
        {
            InitializeComponent();
            xdp = (XmlDataProvider)this.FindResource("provider2");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> studentInfo = new List<string>();

            foreach (var item in panel1.Children)
                if (item is TextBox)
                    studentInfo.Add((item as TextBox).Text);

            XmlDocument doc = new XmlDocument();
            string path = @"..\..\Data\workers.xml";
            doc.Load(path);

            //< worker id = "1" photo = "Images/worker1.png" name = "Leonid" surname = "Leonenkov" middlename = "Sergeevich" birthdate = "21.05.1989" specialization = "office man" position = "office worker" did = "1" dname = "office" />
            string[] strings = new string[] { "id", "photo", "name", "surname", "middlename", "birthdate","specialization","position","did","dname" };
            XmlElement root = doc.DocumentElement;
            XmlElement node = doc.CreateElement("worker");

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

            DialogResult = true;
        }
    }
}
