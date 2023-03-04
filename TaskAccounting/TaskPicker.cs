using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskAccounting.Parser;
using TaskAccounting.Strategy;

namespace TaskAccounting
{
    public enum XlsxColumns
    {
        nul,
        departmentName,
        projectCode,
        projectName,
        taskGroup,
        taskCode,
        taskName
    }

    public partial class TaskPicker : Form
    {
        string path = "C:/Users/Иван/Downloads/attachments/справочник1.xlsx";

        private ClientWindow parentForm = null;
        private TaskPickerStrategy strategy;

        public TaskPicker()
        {
            InitializeComponent();

            strategy = new TaskPickerStrategy(path);
            strategy.Fill(departmentPickerComboBox, XlsxColumns.departmentName);

            ControlEnability();
        }
        public TaskPicker(ClientWindow newParentForm)
        {
            InitializeComponent();

            strategy = new TaskPickerStrategy(path, newParentForm.GetShownTasks(), this);
            strategy.Fill(departmentPickerComboBox, XlsxColumns.departmentName);

            parentForm = newParentForm;
            parentForm.SetControlEnability(false);

            ControlEnability();
        }

        private void ControlEnability()
        {
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox)
                {
                    if (control.Name != departmentPickerComboBox.Name)
                    {
                        control.Enabled = false;
                    }
                }
                if(control is CheckedListBox)
                {
                    control.Enabled = false;
                }
            }
        }

        private void DepartmentPickerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (departmentPickerComboBox.SelectedItem.ToString() == null)
                {

                }
                else
                {
                    bigTaskTypeLable.Text = "";
                    projectPickerComboBox.Items.Clear();
                    taskTypePickerComboBox.Items.Clear();
                    taskCheckedListBox.Items.Clear();

                    projectPickerComboBox.Text = null;
                    taskTypePickerComboBox.Text = null;

                    projectPickerComboBox.Enabled = false;
                    taskTypePickerComboBox.Enabled = false;
                    taskCheckedListBox.Enabled = false;

                    var filter = new List<string>();
                    filter.Add(departmentPickerComboBox.Text);
                    strategy.Fill(projectPickerComboBox, XlsxColumns.projectName, filter);

                    projectPickerComboBox.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void projectPickerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (projectPickerComboBox.SelectedItem.ToString() == null)
                {

                }
                else
                {
                    bigTaskTypeLable.Text = "";
                    taskTypePickerComboBox.Items.Clear();
                    taskCheckedListBox.Items.Clear();

                    taskTypePickerComboBox.Text = null;

                    taskTypePickerComboBox.Enabled = false;
                    taskCheckedListBox.Enabled = false;

                    var filter = new List<string>();
                    filter.Add(departmentPickerComboBox.Text);
                    filter.Add(projectPickerComboBox.Text);
                    strategy.Fill(taskTypePickerComboBox, XlsxColumns.taskGroup, filter);

                    taskTypePickerComboBox.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void taskTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (taskTypePickerComboBox.SelectedItem.ToString() == null)
                {

                }
                else
                {
                    bigTaskTypeLable.Text = StringParser.LongSpaceToNewLine(taskTypePickerComboBox.Text);
                    taskCheckedListBox.Items.Clear();

                    taskCheckedListBox.Enabled = false;

                    var filter = new List<string>();
                    filter.Add(departmentPickerComboBox.Text);
                    filter.Add(projectPickerComboBox.Text);
                    filter.Add(taskTypePickerComboBox.Text);
                    strategy.FillUpperCheckedBox(filter);

                    taskCheckedListBox.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                parentForm.FillDataGrid(strategy.GetLowerPicked());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaskPicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.SetControlEnability(true);
            }
        }

        public CheckedListBox CheckedListBox(int n)
        {
            if (n == 0)
            {
                return taskCheckedListBox;
            }
            if (n == 1)
            {
                return finalCheckedListBox;
            }

            return null;
        }

        private void addToFinalListButton_Click(object sender, EventArgs e)
        {
            strategy.AddPickedUpperToLower();
        }
    }
}
