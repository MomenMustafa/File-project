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
    public partial class mangr : Form
    {
        public mangr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            string dee = comboBox1.Text;

            if (comboBox2.Text == "Avg of salaries")
            {
                textBox1.Hide();
                label4.Hide();
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list1 = doc.GetElementsByTagName("department");
                XmlNodeList list2 = doc.GetElementsByTagName("salary");
                double saa;
                int cnt = 0;
                double sumofsalary = 0;
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i].InnerText == dee)
                    {
                        saa = double.Parse(list2[i].InnerText);
                        sumofsalary += saa - (saa * 0.07);
                        cnt++;
                    }
                }
                double avg = 0;
                avg = sumofsalary / cnt;
                if (dataGridView1.ColumnCount == 0)
                {

                    dataGridView1.Columns.Add("Table name", "Employees");
                    dataGridView1.Columns.Add("Salary", "Salary");
                    dataGridView1.Columns.Add("Avg", "Average");

                }
                dataGridView1.Rows.Add(new string[] { null, null, avg.ToString() });
            }
            else if ("Compares" == comboBox2.Text)
            {
                textBox1.Hide();
                label4.Hide();
                compares f = new compares();
                f.Show();
                this.Hide();
            }
            if ("Report" == comboBox2.Text)
            {
                bool boo = false;
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list = doc.GetElementsByTagName("employee");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList emp = list[i].ChildNodes;


                    if (emp[0].InnerText == textBox1.Text)
                    {
                        boo = true;

                        if (emp[3].InnerText == "hr" || emp[3].InnerText == "sales")
                        {
                            if (dataGridView1.ColumnCount == 0)
                            {

                                dataGridView1.Columns.Add("Table name", "Employees");
                                dataGridView1.Columns.Add("id", "ID");

                                dataGridView1.Columns.Add("Name", "Name");
                                dataGridView1.Columns.Add("salary", "Salary");

                                dataGridView1.Columns.Add("Department", "Department");
                                dataGridView1.Columns.Add("workhours", "Work Hours");
                                dataGridView1.Columns.Add("task1", "Task1");
                                dataGridView1.Columns.Add("task2", "Task2");
                                dataGridView1.Columns.Add("task3", "Task3");



                                dataGridView1.Rows.Add(new string[] { null, emp[0].InnerText, emp[1].InnerText, emp[2].InnerText, emp[3].InnerText, emp[4].InnerText, "Task1", "Task2", "Task3" });
                            }
                        }
                     else if (emp[3].InnerText == "it" || emp[3].InnerText == "marketing")
                        {
                            if (dataGridView1.ColumnCount == 0)
                            {

                                dataGridView1.Columns.Add("Table name", "Employees");
                                dataGridView1.Columns.Add("id", "ID");

                                dataGridView1.Columns.Add("Name", "Name");
                                dataGridView1.Columns.Add("salary", "Salary");

                                dataGridView1.Columns.Add("Department", "Department");
                                dataGridView1.Columns.Add("workhours", "Work Hours");
                                dataGridView1.Columns.Add("task1", "Task1");
                                dataGridView1.Columns.Add("task2", "Task2");




                                dataGridView1.Rows.Add(new string[] { null, emp[0].InnerText, emp[1].InnerText, emp[2].InnerText, emp[3].InnerText, emp[4].InnerText, "Task1", "Task2" });
                            }
                        }

                    }

                       
                }
                if (boo == false)
                    MessageBox.Show("Invaild ID");

            }
            else if ("ideal employee" == comboBox2.Text)
            {
                textBox1.Hide();
                label4.Hide();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                int max = 0; string str = " ";
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list1 = doc.GetElementsByTagName("department");
                XmlNodeList list2 = doc.GetElementsByTagName("workhour");
                XmlNodeList list3 = doc.GetElementsByTagName("name");
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i].InnerText == dee)
                    {
                        int s = int.Parse(list2[i].InnerText);
                        if (max < s)
                        {
                            max = s;
                            str = list3[i].InnerText;
                        }
                    }
                }
                if (dataGridView1.ColumnCount == 0)
                {

                    dataGridView1.Columns.Add("Table name", "Employees");
                    dataGridView1.Columns.Add("workhours", "Workhours");
                    dataGridView1.Columns.Add("name", "Ideal emp's name");

                }
                dataGridView1.Rows.Add(new string[] { null, null, str });
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void mangr_Load(object sender, EventArgs e)
        {

        }

        private void mangr_Load_1(object sender, EventArgs e)
        {
            textBox1.Hide();
            label4.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Report")
            {
                textBox1.Show();
                label4.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
