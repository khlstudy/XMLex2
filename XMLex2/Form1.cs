using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace XMLex2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("���������� �� ����", "�������");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
            }
            else
            {
                MessageBox.Show("������� ����� ��� �����������.", "�������.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("������� ����� ��� ���������.", "�������.");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            numericUpDown1.Value = n;
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Employee";
                dt.Columns.Add("Name");
                dt.Columns.Add("Age", typeof(int)); // ������ ��� �����
                dt.Columns.Add("Programmer", typeof(bool)); // ������ ��� �����
                ds.Tables.Add(dt);

                foreach (DataGridViewRow r in dataGridView1.Rows) // ������ "in" ����� dataGridView1.Rows
                {
                    DataRow row = ds.Tables["Employee"].NewRow();

                    row["Name"] = r.Cells[0].Value;
                    row["Age"] = Convert.ToInt32(r.Cells[1].Value); // ������������� �������� � int
                    row["Programmer"] = Convert.ToBoolean(r.Cells[2].Value); // ������������� �������� � bool
                    ds.Tables["Employee"].Rows.Add(row);
                }

                ds.WriteXml("D:\\Data.xml");
                MessageBox.Show("XML ���� ������ ���������", "��������");
            }
            catch
            {
                MessageBox.Show("XML ���� ������ ���������", "��������");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 1) 
            {
                MessageBox.Show("������� ���� ����� ������������� ������ �����.", "�������.");
            }
            else
            {
                if(File.Exists("D:\\Data.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("D:\\Data.xml");
                        foreach(DataRow item in ds.Tables["Employee"].Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value= item["Name"];
                        dataGridView1.Rows[n].Cells[1].Value = item["Age"];
                        dataGridView1.Rows[n].Cells[2].Value = item["Programmer"];
                    }
                }
                else
                {
                    MessageBox.Show("XML ���� �� ��������.", "�������.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0) 
            { 
                dataGridView1.Rows.Clear();
            }
            else
            {
                MessageBox.Show("������� �������.", "�������.");
            }
        }
    }
}