using System;
using System.Collections.Generic;
using TaskAccounting.Entity;


namespace TaskAccounting
{
    public class TaskInfoListHolder
    {
        public List<TaskInfo> tasks { get; set; }

        public TaskInfoListHolder()
        {
            tasks = new List<TaskInfo>();
        }
        public TaskInfoListHolder(List<TaskInfo> initTasksInfo)
        {
            if (initTasksInfo == null)
            {
                throw new Exception("Поптка инициализации пустм списком");
            }

            tasks = initTasksInfo;
        }

        public TaskInfo this[int i]
        {
            get { return tasks[i]; }
            set { tasks[i] = value; }
        }

        public List<string> this[XlsxColumns column]
        {
            get
            {
                if (tasks == null)
                {
                    throw new Exception("Список задач не создан");
                }

                var strs = new List<string>();
                foreach (var task in tasks)
                {
                    strs.Add(task[column]);
                }

                return strs;
            }
        }

        public void AddUnique(TaskInfoListHolder newTasks)
        {
            if (newTasks == null | newTasks.tasks == null)
            {
                return;
            }
            if (tasks == null)
            {
                tasks = new List<TaskInfo>();
            }

            foreach (TaskInfo task in newTasks)
            {
                if (!tasks.Contains(task))
                {
                    tasks.Add(task);
                }
            }
        }

        //Не нравится
        public TaskInfo Find(string val, XlsxColumns column)
        {
            foreach (TaskInfo task in tasks)
            {
                if (task[column] == val)
                {
                    return task;
                }
            }

            return null;
        }

        public IEnumerator<TaskInfo> GetEnumerator()
        {
            return tasks.GetEnumerator();
        }
    }
}
