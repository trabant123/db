using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Display();
        }

        private void Display()
        {
            listView1.Items.Clear();
            foreach (Pracant pracant in SQL.Display())
            {
                listView1.Items.Add(pracant.ToListViewItem());
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQL.Addo(new Pracant(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value));
            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                var id = listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text;
                SQL.Delete(id);
                Display();
            }
            else
            {
                MessageBox.Show("Negr");
            }

 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedIndices.Count > 0)
            {
                var id = listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text;
                SQL.Edit(int.Parse(id), new Pracant(textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Value));
                Display();
            }
            else
            {
                MessageBox.Show("Negr");
            }
        }
    }
}
