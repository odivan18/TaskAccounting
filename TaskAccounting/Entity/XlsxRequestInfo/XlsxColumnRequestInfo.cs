using System.Collections.Generic;
using OfficeOpenXml;
using TaskAccounting.Interface;

namespace TaskAccounting.Entity.XlsxRequestInfo
{
    class XlsxColumnRequestInfo : IXlsxRequetInfo
    {
        public string path { get; }
        public XlsxColumns column { get; }
        public XlsxColumns referencedColumn { get; }
        public string refVal { get; }

        public XlsxColumnRequestInfo(string newPath, XlsxColumns newColumn, string newRefVal)
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

        public XlsxColumnRequestInfo(string newPath, XlsxColumns newColumn, XlsxColumns newReferencedColumn, string newRefVal)
        {
            path = newPath;
            column = newColumn;
            referencedColumn = newReferencedColumn;
            refVal = newRefVal;
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
}
