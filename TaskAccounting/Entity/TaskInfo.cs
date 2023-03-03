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

namespace TaskAccounting.Entity
{
 

    public class TaskInfo
    {
        public string department { get; set; }
        public string projectCode { get; set; }
        public string projectName { get; set; }
        public string taskType { get; set; }
        public string taskCode { get; set; }
        public string taskName { get; set; }

        public string[] field;

        public TaskInfo() { }
        public TaskInfo(List<string> excelRow)
        {
            field = new string[Enum.GetNames(typeof(XlsxColumns)).Length];
            for(int i=1;i<field.Length;i++)
            {
                field[i] = excelRow[i];
            }

            var c = this.field[2];
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
