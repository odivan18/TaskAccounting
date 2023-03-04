using System;
using System.Collections.Generic;

namespace TaskAccounting.Entity
{
    public class TaskInfo
    {
        public string[] field;

        public TaskInfo() { }
        public TaskInfo(List<string> excelRow)
        {
            field = new string[Enum.GetNames(typeof(XlsxColumns)).Length];
            for (int i = 1; i < field.Length; i++)
            {
                field[i] = excelRow[i];
            }
        }

        public string this[int i]
        {
            get { return field[i]; }
            set { field[i] = value; }
        }

        public string this[XlsxColumns column]
        {
            get { return field[(int)column]; }
            set { field[(int)column] = value; }
        }
    }
}
