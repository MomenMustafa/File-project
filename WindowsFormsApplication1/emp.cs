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
    public partial class emp : Form
    {
        public emp()
        {
            InitializeComponent();
        }

        private void emp_Load(object sender, EventArgs e)
        {
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string s = textBox1.Text;
            string d = comboBox1.Text;

            if (d == "Calc rate")
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                //dataGridView2.Hide();
                dataGridView1.Show();
                int hours, rate;
                bool boo = false;
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list = doc.GetElementsByTagName("id");
                XmlNodeList list1 = doc.GetElementsByTagName("workhour");
                for (int i = 0; i < list.Count; i++)
                {
                    string idd = list[i].InnerText;
                    if (idd == textBox1.Text)
                    {
                        boo = true;
                        hours = int.Parse(list1[i].InnerText);
                        rate = hours - 6;
                        dataGridView1.Columns.Add("Table", "Employees");
                        dataGridView1.Columns.Add("hours", "Work hours");
                        dataGridView1.Columns.Add("rate", "Rate");
                        dataGridView1.Rows.Add(new string[] { null, hours.ToString(), rate.ToString() });

                        break;
                    }
                }
                if (boo == false)
                    MessageBox.Show("Invaild ID");
            }
            else if (d == "Calc salary after taxes")
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                //dataGridView2.Hide();
                dataGridView1.Show();
                double sala, salaryaftertaxes;
                bool boo = false;
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list = doc.GetElementsByTagName("id");
                XmlNodeList list1 = doc.GetElementsByTagName("salary");

                for (int i = 0; i < list.Count; i++)
                {
                    string idd = list[i].InnerText;
                    if (idd == textBox1.Text)
                    {
                        boo = true;
                        sala = int.Parse(list1[i].InnerText);



                        salaryaftertaxes = sala - (sala * 0.07);
                        dataGridView1.Columns.Add("Table", "Employees");
                        dataGridView1.Columns.Add("Salary", "Orginal salary");
                        dataGridView1.Columns.Add("Result", "Salary After Taxes");



                        dataGridView1.Rows.Add(new string[] { null, sala.ToString(), salaryaftertaxes.ToString() });


                        break;
                    }
                }
                if (boo == false)
                    MessageBox.Show("Invaild ID");
            }

            else if (d == "Show tasks")
            {

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
               // dataGridView2.Hide();
                //dataGridView1.Show();
                string dep;
                bool boo = false;
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list = doc.GetElementsByTagName("id");
                XmlNodeList list1 = doc.GetElementsByTagName("department");
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("tasks.xml");
                XmlNodeList list2 = doc2.GetElementsByTagName("task");
                /*DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                check.Name = "Done";
                check.FalseValue = 0;*/
                for (int i = 0; i < list.Count; i++)
                {
                    string idd = list[i].InnerText;
                    if (idd == textBox1.Text)
                    {
                        boo = true;
                        dep = list1[i].InnerText;
                        for (int j = 0; j < list2.Count; j++)
                        {
                            XmlNodeList taskk = list2[j].ChildNodes;
                            if (dep == taskk[1].InnerText)
                            {
                                string name = taskk[0].Name;
                                string nval = taskk[0].InnerText;
                                string de = taskk[1].Name;
                                string deval = taskk[1].InnerText;
                                string line = taskk[2].Name;
                                string lineval = taskk[2].InnerText;

                                if (dataGridView1.ColumnCount == 0)
                                {

                                    dataGridView1.Columns.Add("Table name", "Employees,Tasks");
                                    dataGridView1.Columns.Add("Column", dep);

                                    dataGridView1.Columns.Add("Name", name);
                                    dataGridView1.Columns.Add("Department", de);
                                    dataGridView1.Columns.Add("Deadline(days)", line);

                                }
                                dataGridView1.Rows.Add(new string[] { null, null, nval, deval, lineval });
                            }
                        }

                        break;

                    }
                }
                if (boo == false)
                    MessageBox.Show("Invaild ID");

            }

            else if (d == "Done tasks")
            {/*
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                //dataGridView2.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Hide();
                //dataGridView2.Show();

                string dep;
                bool boo = false;
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list1 = doc.GetElementsByTagName("employees");

                string t1, t2, t3;

                for (int i = 0; i < list1.Count; i++)
                {
                    XmlNodeList emp = list1[i].ChildNodes;

                    if (emp[0].InnerText == textBox1.Text)
                    {
                        boo = true;
                        dep = emp[3].InnerText;
                        if (dataGridView2.ColumnCount == 0)
                        {
                            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                            ch1 = (DataGridViewCheckBoxCell)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0];
                            DataGridViewCheckBoxCell ch2 = new DataGridViewCheckBoxCell();
                            ch2 = (DataGridViewCheckBoxCell)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1];
                            DataGridViewCheckBoxCell ch3 = new DataGridViewCheckBoxCell();
                            ch3 = (DataGridViewCheckBoxCell)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2];
                            dataGridView2.Columns.Add("Table name", "Employees");
                            dataGridView2.Columns.Add("task", "Undone Tasks");
                        }
                        if (emp[5].InnerText == "0")
                        {
                            t1 = emp[5].Name;
                            dataGridView2.Rows.Add(new string[] { null, t1 });

                        }
                        if (emp[6].InnerText == "0")
                        {
                            t2 = emp[6].Name;
                            dataGridView2.Rows.Add(new string[] { null, t2 });

                        }
                        if (emp[7].InnerText == "0")
                        {
                            t3 = emp[7].Name;
                            dataGridView2.Rows.Add(new string[] { null, t3 });

                        }


                    }


                }
                if (boo == false)
                    MessageBox.Show("Invaild ID");


                */
                button3.Show();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                // dataGridView2.Hide();
                //dataGridView1.Show();
                string dep;
                bool boo = false;
                XmlDocument doc = new XmlDocument();
                doc.Load("employees.xml");
                XmlNodeList list = doc.GetElementsByTagName("id");
                XmlNodeList list1 = doc.GetElementsByTagName("department");
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("tasks.xml");
                XmlNodeList list2 = doc2.GetElementsByTagName("task");
                /*DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                check.Name = "Done";
                check.FalseValue = 0;*/
                for (int i = 0; i < list.Count; i++)
                {
                    string idd = list[i].InnerText;
                    if (idd == textBox1.Text)
                    {
                        boo = true;
                        dep = list1[i].InnerText;
                        for (int j = 0; j < list2.Count; j++)
                        {
                            XmlNodeList taskk = list2[j].ChildNodes;
                            if (dep == taskk[1].InnerText)
                            {
                                string name = taskk[0].Name;
                                string nval = taskk[0].InnerText;
                                string de = taskk[1].Name;
                                string deval = taskk[1].InnerText;
                                string line = taskk[2].Name;
                                string lineval = taskk[2].InnerText;

                                if (dataGridView1.ColumnCount == 0)
                                {
                                    DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                                    
                                    check.HeaderText = "check";
                                    check.Name = "Done";
                                    dataGridView1.Columns.Add( check);

                                    dataGridView1.Columns.Add("Table name", "Employees,Tasks");
                                    dataGridView1.Columns.Add("Column", dep);

                                    dataGridView1.Columns.Add("Name", name);
                                    dataGridView1.Columns.Add("Department", de);
                                    dataGridView1.Columns.Add("Deadline(days)", line);
                                   
                                }
                                dataGridView1.Rows.Add(new string[] { null, null, null, nval, deval, lineval });
                               
                            }
                            
                            
                        }
                       

                        break;


                    }


                }
                if (boo == false)
                    MessageBox.Show("Invaild ID");

            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
              

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //dataGridView2.Rows.Clear();
            //dataGridView2.Columns.Clear();
            dataGridView1.Hide();
            //dataGridView2.Show();
            XmlDocument doc = new XmlDocument();
            doc.Load("employees.xml");
            XmlNodeList list1 = doc.GetElementsByTagName("employees");
           /* if (comboBox1.Text =="Done tasks")
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0];
                DataGridViewCheckBoxCell ch2 = new DataGridViewCheckBoxCell();
                ch2 = (DataGridViewCheckBoxCell)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0];
                DataGridViewCheckBoxCell ch3 = new DataGridViewCheckBoxCell();
                ch3 = (DataGridViewCheckBoxCell)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0];
            }*/
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            /*
                 foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)

             {
                 dataGridView1.Rows.RemoveAt(item.Index);
             }
             */

            // bool delete = (bool)dataGridView1.Rows[i].Cells[0].Selected;

            // DataGridViewRow RemoveRow = dataGridView1.Rows[i];

            List<string> list = new List<string>();


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Selected)
                {
                  //  list[i] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    dataGridView1.Rows.RemoveAt(i);
                    

                }
                
                   
            }

            for (int i = 0; i < list.Count; i++)
            {
                MessageBox.Show(list[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
