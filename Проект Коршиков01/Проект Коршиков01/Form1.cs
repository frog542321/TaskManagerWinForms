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
    /// <summary>
    /// Главная форма приложения для управления задачами.
    /// Позволяет добавлять, удалять, редактировать и фильтровать задачи.
    /// </summary>
    public partial class Form1 : Form
    {
        List<TaskItem> tasks = new List<TaskItem>();
        int selectedIndex = -1;

        /// <summary>
        /// Настраивает элементы интерфейса.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Приоритеты
            cmbPriority.Items.AddRange(new string[]
            {
                "Low",
                "Medium",
                "High"
            });

            // Фильтры
            cmbFilter.Items.AddRange(new string[]
            {
                "Все",
                "Low",
                "Medium",
                "High",
                "Выполнено",
                "Не выполнено"
            });

            cmbFilter.SelectedIndex = 0;

            // DataGridView
            dgvTasks.ColumnCount = 5;

            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.MultiSelect = false;
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.ReadOnly = true;
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AllowUserToDeleteRows = false;
            dgvTasks.AllowUserToResizeRows = false;

            // DrawItem
            cmbPriority.DrawMode = DrawMode.OwnerDrawFixed;
            cmbPriority.DrawItem += Combo_DrawItem;

            cmbFilter.DrawMode = DrawMode.OwnerDrawFixed;
            cmbFilter.DrawItem += Combo_DrawItem;
        }

        /// <summary>
        /// Добавляет новую задачу в список.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            TaskItem task = new TaskItem()
            {
                Title = txtTitle.Text,
                Description = rtxtDescription.Text,
                Date = dtpDate.Value.Date,
                Priority = cmbPriority.Text,
                Completed = chkCompleted.Checked
            };

            tasks.Add(task);

            ShowTasks();
            ClearFields();
        }

        /// <summary>
        /// Удаляет выбранную задачу.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedIndex == -1)
            {
                MessageBox.Show("Ошибка! Ни одна задача не выбрана.");
                return;
            }

            tasks.RemoveAt(selectedIndex);

            ShowTasks();
            ClearFields();

            selectedIndex = -1;
        }

        /// <summary>
        /// Редактирует выбранную задачу.
        /// </summary>

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedIndex == -1)
            {
                MessageBox.Show("Ошибка! Ни одна задача не выбрана.");
                return;
            }

            tasks[selectedIndex].Title = txtTitle.Text;

            tasks[selectedIndex].Description =
                rtxtDescription.Text;

            tasks[selectedIndex].Date =
                dtpDate.Value.Date;

            tasks[selectedIndex].Priority =
                cmbPriority.Text;

            tasks[selectedIndex].Completed =
                chkCompleted.Checked;

            ShowTasks();
            ClearFields();

            selectedIndex = -1;
        }

        /// <summary>
        /// Выполняет фильтрацию задач.
        /// </summary>
        private void btnSort_Click(object sender, EventArgs e)
        {
            ShowTasks();
        }

        /// <summary>
        /// Отображает задачи в DataGridView с учетом фильтрации.
        /// </summary>
        void ShowTasks()
        {
            dgvTasks.Rows.Clear();

            var list = tasks;

            switch (cmbFilter.Text)
            {
                case "Low":
                case "Medium":
                case "High":
                    list = tasks.Where(x => x.Priority == cmbFilter.Text).ToList();
                    break;

                case "Выполнено":
                    list = tasks.Where(x => x.Completed).ToList();
                    break;

                case "Не выполнено":
                    list = tasks.Where(x => !x.Completed).ToList();
                    break;
            }

            foreach (var task in list)
            {
                int row = dgvTasks.Rows.Add(
                    task.Title,
                    task.Description,
                    task.Date.ToShortDateString(),
                    task.Priority,
                    task.Completed ? "Выполнено" : "Не выполнено"
                );

                // Цвет строки
                if (task.Completed)
                {
                    dgvTasks.Rows[row].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (task.Date < DateTime.Today)
                {
                    dgvTasks.Rows[row].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dgvTasks.Rows[row].DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        /// <summary>
        /// Заполняет поля формы данными выбранной задачи.
        /// </summary>
        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedIndex = e.RowIndex;

            txtTitle.Text = dgvTasks.Rows[e.RowIndex].Cells[0].Value.ToString();
            rtxtDescription.Text = dgvTasks.Rows[e.RowIndex].Cells[1].Value.ToString();

            dtpDate.Value = Convert.ToDateTime(
                dgvTasks.Rows[e.RowIndex].Cells[2].Value
            );

            cmbPriority.Text =
                dgvTasks.Rows[e.RowIndex].Cells[3].Value.ToString();

            chkCompleted.Checked =
                dgvTasks.Rows[e.RowIndex].Cells[4].Value.ToString() == "Выполнено";
        }

        /// <summary>
        /// Очищает поля ввода формы.
        /// </summary>
        void ClearFields()
        {
            txtTitle.Clear();
            rtxtDescription.Clear();

            cmbPriority.SelectedIndex = -1;

            chkCompleted.Checked = false;

            dtpDate.Value = DateTime.Today;
        }

        /// <summary>
        /// Отрисовывает элементы ComboBox цветом в зависимости от значения.
        /// </summary>
        private void Combo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = (ComboBox)sender;

            string text = combo.Items[e.Index].ToString();

            Color color = Color.Black;

            if (text == "Low") color = Color.Green;
            if (text == "Medium") color = Color.Orange;
            if (text == "High") color = Color.Red;

            e.DrawBackground();

            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.DrawString(
                    text,
                    e.Font,
                    brush,
                    e.Bounds
                );
            }

            e.DrawFocusRectangle();
        }
    }

    /// <summary>
    /// Представляет задачу пользователя.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// Название задачи.
        /// </summary>
        public string Title;
        /// <summary>
        /// Описание задачи.
        /// </summary>
        public string Description;
        /// <summary>
        /// Дата выполнения задачи.
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// Приоритет задачи.
        /// </summary>
        public string Priority;
        /// <summary>
        /// Статус выполнения задачи.
        /// </summary>
        public bool Completed;
    }
}