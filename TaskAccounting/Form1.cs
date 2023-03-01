using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskAccounting.Sorter;
using TaskAccounting.Entity;

namespace TaskAccounting
{
    public partial class ClientWindow : Form
    {
        public ClientWindow()
        {
            InitializeComponent();

            for (int i = 1; i <= 31; i++)
            {
                TaskDataGridView.Columns.Add($"day{i}", $"{i}");
                TaskDataGridView.Columns[i].Width = 50;
            }

            var msg = new StringBuilder();
            for (int i = 1; i < 50; i++)
                msg.Append($"{i} - {(char)i}\n");
            MessageBox.Show(((int)' ').ToString());
        }

        private void отправитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void выбратьЗадачиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var taskPicker = new TaskPicker(this);
                taskPicker.Show();
                //while(taskPicker.is)
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        public void SetControlEnability(bool state)
        {
            foreach(Control control in this.Controls)
            {
                control.Enabled = state;
            }
        }

        public void FillDataGrid(List<TaskInfo> tasks)
        {
            if (tasks == null)
            {
                throw new Exception("Подан пустой список на заполнение таблицы");
            }

            tasks.Sort(TaskInfoSorter.ByTaskType);
            tasks.Sort(TaskInfoSorter.ByProject);

            List<string> projects = new List<string>();
            List<string> taskTypes = new List<string>();
            
            foreach(TaskInfo task in tasks)
            {
                if(!projects.Contains(task.project))
                {
                    projects.Add(task.project);
                }
                if(!taskTypes.Contains(task.taskType))
                {
                    taskTypes.Add(task.taskType);
                }
            }

            foreach(var project in projects)
            {
                TaskDataGridView.Rows.Add(project);
                TaskDataGridView.Rows[TaskDataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Black;
                //List<string> taskTypes = new List<string>();
            }

        }
    }
}
