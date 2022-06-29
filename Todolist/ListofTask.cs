namespace Todolist2
{
    internal class ListofTask
    {
        public ListofTask(bool status, string project, string task, string updatedate,string startdate, string enddate)
        {
            Status = status;
            Project = project;
            Task = task;
            UpdateDate = updatedate;
            StartDate = startdate;
            EndDate = enddate;
        }
        public bool Status { get; set; }
        public string Project { get; set; }
        public string Task { get; set; }
        public string UpdateDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}