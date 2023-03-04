using TaskAccounting.Entity;

namespace TaskAccounting.Sorter
{
    class TaskInfoSorter
    {
        public static int ByProject(TaskInfo x, TaskInfo y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.[XlsxColumns.projectName].CompareTo(y.[XlsxColumns.projectName]);
                }
            }
        }

        public static int ByTaskGroup(TaskInfo x, TaskInfo y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x[XlsxColumns.taskGroup].CompareTo(y[XlsxColumns.taskGroup]);
                }
            }
        }
    }
}
