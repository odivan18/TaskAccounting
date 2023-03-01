using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace TaskAccounting.Entity.XlsxRequestInfo
{
    class XlsxTaskInfoRequetInfo
    {
        public string path { get; }
        public XlsxColumns column { get; }
        public string refVal { get; }

        public XlsxTaskInfoRequetInfo(string newPath, XlsxColumns newColumn, string taskCode)
        {
            path = newPath;
            column = newColumn;
            refVal = taskCode;
        }

        public bool CheckRow(ExcelWorksheet excelWorksheet, int row)
        {
            if (excelWorksheet.Cells[row, (int)column].Value != null)
                if (excelWorksheet.Cells[row, (int)column].Value.ToString() == refVal)
                    return true;
            return false;
        }
    }
}
