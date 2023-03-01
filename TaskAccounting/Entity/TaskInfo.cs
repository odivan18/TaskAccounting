
namespace TaskAccounting.Entity
{
    public class TaskInfo
    {
        public string project { get; set; }
        public string taskType { get; set; }
        public string taskCode { get; set; }
        public string taskName { get; set; }

        public TaskInfo() { }
        public TaskInfo(string newProject, string newTakType, string newTaskCode, string newTaskName)
        {
            project = newProject;
            taskType = newTakType;
            taskCode = newTaskCode;
            taskName = newTaskName;
        }
    }
}
