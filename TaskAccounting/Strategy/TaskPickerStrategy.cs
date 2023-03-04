using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TaskAccounting.Entity;
using TaskAccounting.Filler;

namespace TaskAccounting.Strategy
{
    class TaskPickerStrategy
    {
        TaskInfoListHolder taskInfoListHolderGeneral;
        TaskInfoCheckedListHolder upperTasksShown;
        TaskInfoCheckedListHolder lowerTasksShown;
        ColumnsDictionary filterColumnDictionary = new ColumnsDictionary();

        public TaskPickerStrategy(string path)
        {
            taskInfoListHolderGeneral = new TaskInfoListHolder(XlsxService.XlsxService.GetAllTaskInfo(path));
        }
        public TaskPickerStrategy(string path, TaskInfoListHolder alreayPickedTasks, TaskPicker taskPicker)
        {
            taskInfoListHolderGeneral = new TaskInfoListHolder(XlsxService.XlsxService.GetAllTaskInfo(path));
            lowerTasksShown = new TaskInfoCheckedListHolder(taskPicker.CheckedListBox(1));
            upperTasksShown = new TaskInfoCheckedListHolder(taskPicker.CheckedListBox(0));

            lowerTasksShown.SetSource(alreayPickedTasks);
        }

        public void Fill(ComboBox comboBox, XlsxColumns column)
        {
            ListControlFiller.ComboBoxWithStringList(comboBox, taskInfoListHolderGeneral[column].Distinct().ToList());
        }

        public void Fill(ComboBox comboBox, XlsxColumns column, List<string> filters)
        {
            ListControlFiller.ComboBoxWithStringList(comboBox, filter(filters, taskInfoListHolderGeneral.tasks)[column].Distinct().ToList());
        }

        public void FillUpperCheckedBox(List<string> refVal)
        {
            upperTasksShown.SetSource(filter(refVal, taskInfoListHolderGeneral.tasks));
        }

        private TaskInfoListHolder filter(List<string> filters, List<TaskInfo> tasks)
        {
            var filtredTaskList = new List<TaskInfo>();

            foreach (var task in tasks)
            {
                bool flag = false;

                for (int filterColumn = 0; filterColumn < filters.Count; filterColumn++)
                {
                    if (task[filterColumnDictionary[filterColumn]] != filters[filterColumn])
                    {
                        flag = true;
                        break;
                    }     
                }

                if (flag) continue;
                filtredTaskList.Add(task);
            }
            
            return new TaskInfoListHolder(filtredTaskList);
        }

        public void AddPickedUpperToLower()
        {
            lowerTasksShown.AddNewUnique(upperTasksShown.GetCheckedTasks());
        }

        public TaskInfoListHolder GetLowerPicked()
        {
            return lowerTasksShown.GetCheckedTasks();
        }
    }
}
