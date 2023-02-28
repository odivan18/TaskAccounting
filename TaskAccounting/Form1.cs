using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                var taskPicker = new TaskPicker();
                taskPicker.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}
