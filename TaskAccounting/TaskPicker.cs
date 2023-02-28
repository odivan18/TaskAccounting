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

namespace TaskAccounting
{
    enum XlsxColumns
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

        public TaskPicker()
        {
            InitializeComponent();

            FillComboBox(departmentPickerComboBox, GetUniqueCellValues(new XlsxDepartmentRequestInfo(path)));           

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

                    FillComboBox(projectPickerComboBox, GetUniqueCellValues(new XlsxRequestInfo(path, XlsxColumns.projectName, departmentPickerComboBox.Text)));
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

                    FillComboBox(taskTypePickerComboBox, GetUniqueCellValues(new XlsxRequestInfo(path, XlsxColumns.taskGroup, projectPickerComboBox.Text)));
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
                    bigTaskTypeLable.Text = Parser(taskTypePickerComboBox.Text);
                    taskCheckedListBox.Items.Clear();

                    taskCheckedListBox.Enabled = false;

                    FillTaskCheckedBox(taskCheckedListBox, GetUniqueCellValues(new XlsxRequestInfo(path, XlsxColumns.taskName, taskTypePickerComboBox.Text)));
                    taskCheckedListBox.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Parser(string strIn)
        {
            string str = strIn;
            int i = 0;
            if(str[i]==' ')
            {
                int j = i + 1;
                for (; j < str.Length; j++)
                {
                    if (str[j] != ' ')
                    {
                        break;
                    }
                }
                if (j - i > 3)
                {
                    str = str.Remove(i, j - i);
                    i = j;
                }
            }

            for(; i < str.Length - 5; i++)
            {
                if(str[i]==' ')
                {
                    int j = i + 1;
                    for (; j < str.Length; j++)
                    {
                        if (str[j] != ' ')
                        {
                            break;
                        }
                    }
                    if(j-i>3)
                    {
                        str = str.Remove(i, j - i);
                        str = str.Insert(i, '\n'.ToString());
                        i = j;
                    }
                }
            }

            return str;
        }

        private void FillComboBox(ComboBox comboBox, List<string> fields)
        {
            if (fields == null)
            {
                throw new Exception("Подан пустой список для впадающего списка на заполнение");
            }

            var array = new string[comboBox.Items.Count + 1];
            comboBox.Items.CopyTo(array, 0);

            comboBox.Items.Clear();
            foreach (string field in fields)
            {
                if (field == null)
                {
                    comboBox.Items.Clear();
                    comboBox.Items.AddRange(array);
                    throw new Exception("В списке для впадающего списка оказалось путое имя");
                }

                comboBox.Items.Add(field);
            }
        }

        private void FillTaskCheckedBox(CheckedListBox checkedListBox, List<string> tasks)
        {
            if(tasks==null)
            {
                throw new Exception("Подан пустой список для впадающего списка на заполнение");
            }

            var array = new string[checkedListBox.Items.Count + 1];
            checkedListBox.Items.CopyTo(array, 0);

            checkedListBox.Items.Clear();
            foreach(string task in tasks)
            {
                if(task==null)
                {
                    checkedListBox.Items.Clear();
                    checkedListBox.Items.AddRange(array);
                    throw new Exception("Ошибка в списке задач на заполнение");
                }

                checkedListBox.Items.Add(task);
            }
        }        

        private List<string> GetUniqueCellValues(IXlsxRequetInfo xlsxRequestInfo)
        {
            if(xlsxRequestInfo == null)
            {
                throw new Exception("Не создан запрос");
            }
            if (xlsxRequestInfo.path == null)
            {
                throw new Exception("Неверный формат пути к файлу");
            }
            if (!File.Exists(path))
            {
                throw new Exception("Файла не существует");
            }

            ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path));
            ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets.First();
            var strs = new List<string>();            

            for (int row = 3; row < excelWorksheet.Dimension.End.Row; row++)
            {
                if(xlsxRequestInfo.CheckRow(excelWorksheet,row,strs))
                {
                    strs.Add(excelWorksheet.Cells[row, (int)xlsxRequestInfo.column].Value.ToString());
                }
            }

            return strs;
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }
    }

    interface IXlsxRequetInfo
    {
        string path { get; }
        XlsxColumns column { get; }

        bool CheckRow(ExcelWorksheet excelWorksheet, int row, List<string> strs);
    }
    
    class XlsxRequestInfo : IXlsxRequetInfo
    {
        public string path { get; }
        public XlsxColumns column { get; }
        public XlsxColumns referencedColumn { get; }
        public string refVal { get; }

        public XlsxRequestInfo(string newPath, XlsxColumns newColumn, string newRefVal)
        {
            path = newPath;
            column = newColumn;
            refVal = newRefVal;

            switch (column)
            {
                case XlsxColumns.projectName:
                    referencedColumn = XlsxColumns.departmentName;
                    break;
                case XlsxColumns.taskGroup:
                    referencedColumn = XlsxColumns.projectName;
                    break;
                case XlsxColumns.taskName:
                    referencedColumn = XlsxColumns.taskGroup;
                    break;
            }
        }

        bool IXlsxRequetInfo.CheckRow(ExcelWorksheet excelWorksheet, int row, List<string> strs)
        {
            if (excelWorksheet.Cells[row, (int)column].Value != null)
                if (excelWorksheet.Cells[row, (int)referencedColumn].Value != null)
                    if (excelWorksheet.Cells[row, (int)referencedColumn].Value.ToString() == refVal)
                        if (!strs.Contains(excelWorksheet.Cells[row, (int)column].Value.ToString()))
                            return true;
            return false;
        }
    }

    class XlsxDepartmentRequestInfo : IXlsxRequetInfo
    {
        public string path { get; }
        public XlsxColumns column { get; }

        public XlsxDepartmentRequestInfo(string newPath)
        {
            path = newPath;
            column = XlsxColumns.departmentName;
        }

        bool IXlsxRequetInfo.CheckRow(ExcelWorksheet excelWorksheet, int row, List<string> strs)
        {
            if (excelWorksheet.Cells[row, (int)column].Value != null)
                if (!strs.Contains(excelWorksheet.Cells[row, (int)column].Value.ToString()))
                    return true;
            return false;
        }
    }
}
