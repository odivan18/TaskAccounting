using System;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using System.IO;
using TaskAccounting.Entity;

namespace TaskAccounting.XlsxService
{
    class XlsxService
    {
        public static List<TaskInfo> GetAllTaskInfo(string path)
        {
            if (path == null)
            {
                throw new Exception("Пустой адрес файла");
            }

            if (!File.Exists(path))
            {
                throw new Exception("Файла не существует");
            }

            ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path));
            ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets.First();
            var tasks = new List<TaskInfo>();

            for (int rowN = 3; rowN < excelWorksheet.Dimension.End.Row; rowN++)
            {
                var rowVal = new List<string>();
                rowVal.Add(rowN.ToString());

                foreach (var cell in excelWorksheet.Cells[rowN, 1, rowN, Enum.GetNames(typeof(XlsxColumns)).Length])
                {
                    rowVal.Add(cell.Text);
                }

                tasks.Add(new TaskInfo(rowVal));
            }

            return tasks;
        }
    }
}
