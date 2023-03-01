using System.Collections.Generic;
using OfficeOpenXml;
using TaskAccounting.Interface;

namespace TaskAccounting.Entity.XlsxRequestInfo
{
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
