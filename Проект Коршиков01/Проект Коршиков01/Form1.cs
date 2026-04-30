using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект_Коршиков01
{
    public partial class Form1 : Form
    {
        Task[] tasks = new Task[0];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task tasks = new Task(textBox1.Text, Convert.ToDouble(textBox1.Text));
            listBox1.Items.Add(tasks.Print());
            textBox1.Text.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double notclickbutton = 0;
            listBox1.Items.Clear();
            foreach (var n in tasks)
            {
                listBox1.Items.Add(n.Print());
                notclickbutton += n.notclick();
            }
            label3.Text = Convert.ToString($"{notclickbutton}");
            listBox1.Items.Add(tasks.Print());
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
