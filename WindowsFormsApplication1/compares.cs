using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class compares : Form
    {
        public compares()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void compares_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            long prof = long.Parse(textBox1.Text);
            long lose = long.Parse(textBox2.Text);
            string y = comboBox1.Text;
            XmlDocument doc = new XmlDocument();
            doc.Load("preYears.xml");
            XmlNodeList list = doc.GetElementsByTagName("year");
            for (int i = 0; i < list.Count;i++)
            {
                XmlNodeList years = list[i].ChildNodes;
                long p = long.Parse(years[1].InnerText);
                long l = long.Parse(years[2].InnerText);
                if (years[0].InnerText==y)
                {
                    if (p< prof && l > lose)
                    {
                        MessageBox.Show("Current year profits and losses is better than this year.");
                    }
                    else if (int.Parse(years[1].InnerText) == prof && int.Parse(years[2].InnerText) == lose)
                    {
                        MessageBox.Show("No difference.");

                    }
                    else if (int.Parse(years[1].InnerText) > prof && int.Parse(years[2].InnerText) < lose)
                    {
                        MessageBox.Show("Current year profits and losses is worse than this year.");

                    }

                }


            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            int prof = int.Parse(textBox1.Text);
            int lose = int.Parse(textBox2.Text);

            XmlDocument doc = new XmlDocument();
            XmlElement year = doc.CreateElement("year");
            XmlElement yee = doc.CreateElement("y");
            yee.InnerText = "2018";
            year.AppendChild(yee);
            XmlElement profit = doc.CreateElement("profits");
            profit.InnerText = prof.ToString();
            year.AppendChild(profit);
            XmlElement loss = doc.CreateElement("losses");
            loss.InnerText = lose.ToString();
            year.AppendChild(loss);
            doc.Load("preYears.xml");
            XmlElement root = doc.DocumentElement;
            root.AppendChild(year);
            doc.Save("preYears.xml");
            MessageBox.Show("Your year data has been added.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            mangr m = new mangr();
            m.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
