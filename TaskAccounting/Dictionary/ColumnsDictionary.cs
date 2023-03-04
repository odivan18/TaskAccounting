using System.Collections.Generic;

namespace TaskAccounting
{
    class ColumnsDictionary
    {
        Dictionary<int, XlsxColumns> pairs = new Dictionary<int, XlsxColumns>();

        public ColumnsDictionary()
        {
            pairs.Add(0, XlsxColumns.departmentName);
            pairs.Add(1, XlsxColumns.projectName);
            pairs.Add(2, XlsxColumns.taskGroup);
            pairs.Add(3, XlsxColumns.taskName);
        }

        public XlsxColumns this[int i]
        {
            get { return pairs[i]; }
        }
    }
}
