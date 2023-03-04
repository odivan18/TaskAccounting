using System.Collections.Generic;
using System.Windows.Forms;
using TaskAccounting.Entity;

namespace TaskAccounting
{
    class TaskInfoCheckedListHolder
    {
        CheckedListBox listBox;
        TaskInfoListHolder tasksInfo;

        public TaskInfoCheckedListHolder(CheckedListBox checkedListBox)
        {
            listBox = checkedListBox;
            tasksInfo = new TaskInfoListHolder();
        }

        public void SetSource(TaskInfoListHolder tasksInfo)
        {
            if (tasksInfo == null)
            {
                return;
            }

            this.tasksInfo = tasksInfo;

            listBox.Items.Clear();
            foreach (TaskInfo task in tasksInfo)
            {
                listBox.Items.Add(Parser.StringParser.CombineBySeparator(task[XlsxColumns.taskCode], task[XlsxColumns.taskName], (char)2));
            }
        }

        public TaskInfoListHolder GetCheckedTasks()
        {
            var checkedTasks = new List<TaskInfo>();

            foreach (var i in listBox.CheckedItems)
            {
                string taskCode = i.ToString().Split((char)2)[0];
                checkedTasks.Add(tasksInfo.Find(taskCode, XlsxColumns.taskCode));
            }

            return new TaskInfoListHolder(checkedTasks);
        }

        public void AddNewUnique(TaskInfoListHolder tasksInfo)
        {
            if (tasksInfo == null | tasksInfo.tasks == null)
            {
                return;
            }

            this.tasksInfo.AddUnique(tasksInfo);

            listBox.Items.Clear();

            foreach (TaskInfo task in this.tasksInfo)
            {
                listBox.Items.Add(Parser.StringParser.CombineBySeparator(task[XlsxColumns.taskCode], task[XlsxColumns.taskName], (char)2));
            }
        }
    }
}
