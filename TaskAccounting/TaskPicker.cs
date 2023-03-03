using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using TaskAccounting.Entity.XlsxRequestInfo;
using TaskAccounting.Entity;
using TaskAccounting.Parser;
using TaskAccounting.Filler;
using TaskAccounting.XlsxService;

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
        readonly string path = "C:/Users/Иван/Downloads/attachments/справочник1.xlsx";

        private ClientWindow parentForm = null;

        public TaskPicker()
        {
            InitializeComponent();

            List<string> fields = XlsxService.XlsxService.GetUniqueCellValues(new XlsxDepartmentRequestInfo(path));
            ListControlFiller.ComboBoxWithStringList(departmentPickerComboBox, fields);

            ControlEnability();
        }

        public TaskPicker(ClientWindow newParentForm)
        {
            InitializeComponent();

            List<string> fields = XlsxService.XlsxService.GetUniqueCellValues(new XlsxDepartmentRequestInfo(path));
            ListControlFiller.ComboBoxWithStringList(departmentPickerComboBox, fields);

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

                    var requetInfo = new XlsxColumnRequestInfo(path, XlsxColumns.projectName, departmentPickerComboBox.Text);
                    ListControlFiller.ComboBoxWithStringList(projectPickerComboBox, XlsxService.XlsxService.GetUniqueCellValues(requetInfo));
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

                    var requetInfo = new XlsxColumnRequestInfo(path, XlsxColumns.taskGroup, projectPickerComboBox.Text);
                    ListControlFiller.ComboBoxWithStringList(taskTypePickerComboBox, XlsxService.XlsxService.GetUniqueCellValues(requetInfo));
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

                    var requetInfo1 = new XlsxColumnRequestInfo(path, XlsxColumns.taskName, taskTypePickerComboBox.Text);
                    var requetInfo2 = new XlsxColumnRequestInfo(path, XlsxColumns.taskCode, XlsxColumns.taskGroup, taskTypePickerComboBox.Text);

                    //var strs1 = XlsxService.XlsxService.GetUniqueCellValues(requetInfo1);
                    //var strs2 = XlsxService.XlsxService.GetUniqueCellValues(requetInfo2);
                    //var strssum = new List<string>();
                    //if(strs1.Count==strs2.Count)
                    //{
                    //    for (int i = 0; i < strs1.Count; i++)
                    //        strssum.Add(StringParser.CombineBySeparator(strs2[i], strs1[i], (char)2));
                    //}

                    var requests = new List<Interface.IXlsxRequetInfo>();
                    requests.Add(requetInfo2);
                    requests.Add(requetInfo1);
                    var strssum = XlsxService.XlsxService.GetUniqueCellValues(requests);

                    ListControlFiller.CheckedListBoxWithStringList(taskCheckedListBox, strssum);
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
            //FillDataGrid(parentForm.DataGrid, TaskList)

            //ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path));
            //ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets.First();
            var tasks = new List<TaskInfo>();


            
            
            //Долго для большого множества 
            foreach (var i in taskCheckedListBox.Items)
            {
                var taskInfoRequetInfo = new XlsxTaskInfoRequetInfo(path, XlsxColumns.taskCode, i.ToString().Substring(0, i.ToString().IndexOf((char)2)));
                tasks.Add(XlsxService.XlsxService.GetTaskInfo(taskInfoRequetInfo));
            }

            

            parentForm.FillDataGrid(tasks);
        }

        private TaskInfo GetTaskInfoByTaskName(string taskName, ExcelWorksheet excelWorksheet)
        {
            var taskInfo = new TaskInfo();
            taskInfo.taskName = taskName;

            for (int rowN = 3; rowN < excelWorksheet.Dimension.End.Row; rowN++)
            {
                if (excelWorksheet.Cells[rowN, (int)XlsxColumns.taskName].Value.ToString() == taskName)
                {
                    taskInfo.projectName = excelWorksheet.Cells[rowN, (int)XlsxColumns.projectName].Value.ToString();
                    taskInfo.taskType = excelWorksheet.Cells[rowN, (int)XlsxColumns.taskGroup].Value.ToString();
                    taskInfo.taskCode = excelWorksheet.Cells[rowN, (int)XlsxColumns.taskCode].Value.ToString();

                    return taskInfo;
                }
            }

            throw new Exception($"Задача с таким именем не найдена в базе:\n{taskName}");
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
    }

    
}
