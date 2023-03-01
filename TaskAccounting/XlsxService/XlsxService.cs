using System;
using System.Collections.Generic;
using System.Linq;
using TaskAccounting.Interface;
using OfficeOpenXml;
using System.IO;
using TaskAccounting.Entity;
using TaskAccounting.Entity.XlsxRequestInfo;

namespace TaskAccounting.XlsxService
{
    class XlsxService
    {
        public static List<string> GetUniqueCellValues(IXlsxRequetInfo xlsxRequestInfo)
        {
            if (xlsxRequestInfo == null)
            {
                throw new Exception("Не создан запрос");
            }
            if (xlsxRequestInfo.path == null)
            {
                throw new Exception("Неверный формат пути к файлу");
            }
            if (!File.Exists(xlsxRequestInfo.path))
            {
                throw new Exception("Файла не существует");
            }

            ExcelPackage xlPackage = new ExcelPackage(new FileInfo(xlsxRequestInfo.path));
            ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets.First();
            var strs = new List<string>();

            for (int row = 3; row < excelWorksheet.Dimension.End.Row; row++)
            {
                if (xlsxRequestInfo.CheckRow(excelWorksheet, row, strs))
                {
                    strs.Add(excelWorksheet.Cells[row, (int)xlsxRequestInfo.column].Value.ToString());
                }
            }

            return strs;
        }

        public static List<string> GetUniqueCellValues(List<IXlsxRequetInfo> xlsxRequestInfo)
        {
            RequestInfoCheck(xlsxRequestInfo);

            ExcelPackage xlPackage = new ExcelPackage(new FileInfo(xlsxRequestInfo[0].path));
            ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets.First();
            var strs = new List<string>();

            // xlsxRequestInfo[0]
            for (int row = 3; row < excelWorksheet.Dimension.End.Row; row++)
            {
                if (xlsxRequestInfo[0].CheckRow(excelWorksheet, row, strs))
                {
                    strs.Add(excelWorksheet.Cells[row, (int)xlsxRequestInfo[0].column].Value.ToString());
                }
            }

            // xlsxRequestInfo[1 - count]
            for (int i=1;i<xlsxRequestInfo.Count;i++)
            {
                int n = 0;
                for (int row = 3; row < excelWorksheet.Dimension.End.Row; row++)
                {
                    if (xlsxRequestInfo[i].CheckRow(excelWorksheet, row, strs))
                    {
                        string addition = excelWorksheet.Cells[row, (int)xlsxRequestInfo[i].column].Value.ToString();
                        strs[n] = Parser.StringParser.CombineBySeparator(strs[n], addition, (char)2);
                        n++;
                    }
                }
            }

            return strs;
        }

        private static void RequestInfoCheck(List<IXlsxRequetInfo> xlsxRequestInfo)
        {
            foreach(var reqInfo in xlsxRequestInfo)
            {
                if (reqInfo == null)
                {
                    throw new Exception("Не создан запрос");
                }
                if (reqInfo.path == null)
                {
                    throw new Exception("Неверный формат пути к файлу");
                }
                if (reqInfo == xlsxRequestInfo[0])
                {
                    for (int i = 0; i < xlsxRequestInfo.Count; i++)
                    {
                        if (reqInfo.path != xlsxRequestInfo[i].path)
                        {
                            throw new Exception("Во множестенном запросе не совпадают пути до файла");
                        }
                    }
                }
                if (!File.Exists(reqInfo.path))
                {
                    throw new Exception("Файла не существует");
                }
            }
        }

        public static TaskInfo GetTaskInfo(XlsxTaskInfoRequetInfo xlsxRequestInfo)
        {
            if (xlsxRequestInfo == null)
            {
                throw new Exception("Не создан запрос");
            }
            if (xlsxRequestInfo.path == null)
            {
                throw new Exception("Неверный формат пути к файлу");
            }
            if (!File.Exists(xlsxRequestInfo.path))
            {
                throw new Exception("Файла не существует");
            }

            ExcelPackage xlPackage = new ExcelPackage(new FileInfo(xlsxRequestInfo.path));
            ExcelWorksheet excelWorksheet = xlPackage.Workbook.Worksheets.First();

            for (int row = 3; row < excelWorksheet.Dimension.End.Row; row++)
            {
                if (xlsxRequestInfo.CheckRow(excelWorksheet, row))
                {
                    return new TaskInfo(excelWorksheet.Cells[row, (int)XlsxColumns.projectName].Value.ToString(),
                        excelWorksheet.Cells[row, (int)XlsxColumns.taskGroup].Value.ToString(),
                        excelWorksheet.Cells[row, (int)XlsxColumns.taskCode].Value.ToString(),
                        excelWorksheet.Cells[row, (int)XlsxColumns.taskName].Value.ToString());
                }
            }

            throw new Exception("Не удалось найти задачу");
        }
    }
}
