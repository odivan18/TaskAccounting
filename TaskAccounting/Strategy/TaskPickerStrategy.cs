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

namespace TaskAccounting.Strategy
{
    class TaskPickerStrategy
    {
        List<TaskInfo> tasks;

        public void GetAllTasks(string path)
        {
            if (path == null)
            {
                throw new Exception("Пустой путь к файлу");
            }
            if (!File.Exists(path))
            {
                throw new Exception($"По такому адресу файла не существует\n{path}");
            }

            ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path));
            ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets.First();

            tasks = new List<TaskInfo>();

            for (int row = 3; row < excelWorksheet.Dimension.End.Row; row++)
            {
                if (xlsxRequestInfo.CheckRow(excelWorksheet, row, strs))
                {
                    var strs = new List<string>();

                    //var s = new TaskInfo(excelWorksheet.Cells[row, 1, row, Enum.GetNames(typeof(XlsxColumns)).Length].Cast<string[]>());
                    foreach (var i in excelWorksheet.Cells[row, 1, row, Enum.GetNames(typeof(XlsxColumns)).Length])
                    {
                        strs.Add(i.Text);
                    }

                    tasks.Add(new TaskInfo(strs));
                    
                }
            }

            var strs = new List<string>();
            foreach(var ti in tasks)
            {
                if(!strs.Contains(ti[XlsxColumns.departmentName]))
                {
                    strs.Add(ti[XlsxColumns.departmentName]);
                }
            }


        }

        public List<string> GetUniqueValInColumn(XlsxColumns column, List<TaskInfo> tasks)
        {
            var strs = new List<string>();
            foreach (var ti in tasks)
            {
                if (!strs.Contains(ti[column]))
                {
                    strs.Add(ti[column]);
                }
            }

            return strs;
        }
    }

    class TaskInfoListHolder
    {
        List<TaskInfo> tasks;

        public TaskInfoListHolder(List<TaskInfo> initTasksInfo)
        {
            if (initTasksInfo == null)
            {
                throw new Exception("Поптка инициализации пустм списком");
            }

            tasks = initTasksInfo;
        }

        public TaskInfo this[int i]
        {
            get { return tasks[i]; }
            set { tasks[i] = value; }
        }

        public List<string> this[XlsxColumns column]
        {
            get 
            {
                if (tasks == null)
                {
                    throw new Exception("Список задач не создан");
                }

                var strs = new List<string>();
                foreach (var task in tasks)
                {
                        strs.Add(task[column]);
                }

                return strs;
            }
        }

        public List<string> GetUniqueValInColumn(XlsxColumns column)
        {
            if (tasks == null)
            {
                throw new Exception("Список задач не создан");
            }

            var strs = new List<string>();
            foreach (var ti in tasks)
            {
                if (!strs.Contains(ti[column]))
                {
                    strs.Add(ti[column]);
                }
            }

            return strs;
        }
    }
}
