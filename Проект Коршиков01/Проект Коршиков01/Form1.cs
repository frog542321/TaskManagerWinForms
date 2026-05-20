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

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}