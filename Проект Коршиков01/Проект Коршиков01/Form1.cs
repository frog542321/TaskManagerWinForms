using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_Коршиков01
{
    public partial class Form1 : Form
    {
        List<Task> task1 = new List<Task>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string task = textBox1.Text.ToString();
            listBox1.Items.Add(task);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Task = listBox1.Text.ToString();
            listBox1.Items.Remove(Task);
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрана задача для выполнения действия");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null) 
            {
                textBox2.Text = listBox1.SelectedItem.ToString();
                textBox2.Visible = true;
            }
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрана задача для выполнения действия");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        public class Task
        {
            public string Title { get; set; }
        }
    }
}