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

            Task task1 = new Task
            {
                Title = textBox1.Text,
                Description = richTextBox1.Text,
                Date = dateTimePicker1.Value,
                Priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), comboBox1.Text),
            };
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

            int index = listBox1.SelectedIndex;
            Task tasks = task1[index];
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SlectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Task selected)
            {
                textBox1.Text = selected.Title;
                richTextBox1.Text = selected.Description;
                dateTimePicker1.Text = selected.Date;
                comboBox1.Text = selected.Priority.ToString();
                checkBox1.Checked = false;
                if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            }
        }
        public enum TaskPriority { Low, Medium, High }
        public class Task
        {
            public string Title { get; set; }
            public string Description { get; set; } 
            public DateTime Date { get; set; }
            public TaskPriority Priority { get; set; }
            public bool Completed { get; set; }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}