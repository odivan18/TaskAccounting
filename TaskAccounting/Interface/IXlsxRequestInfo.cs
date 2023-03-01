using System.Collections.Generic;
using OfficeOpenXml;

namespace TaskAccounting.Interface
{
    interface IXlsxRequetInfo
    {
        string path { get; }
        XlsxColumns column { get; }

        bool CheckRow(ExcelWorksheet excelWorksheet, int row, List<string> strs);
    }
}
