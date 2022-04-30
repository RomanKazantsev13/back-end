namespace ScrumBoard
{
    public class Column : IColumn
    {
        public Column(string title)
        {
            m_title = title;
            m_tasks = new List<ITask>();
            m_id = Guid.NewGuid();
        }

        public void AddTask(ITask task)
        {
            m_tasks.Add(task);
        }

        public void RemoveTask(Guid id_task)
        {
            ITask? task = GetTaskById(id_task);

            if (task != null)
            {
                m_tasks.Remove(task);
            }
        }

        public ITask? GetTaskById(Guid id_task)
        {
            foreach (ITask task in m_tasks)
            {
                if (task.m_id == id_task)
                {
                    return task;
                }
            }

            return null;
        }

        public string m_title { set; get; }
        public List<ITask> m_tasks { get; }
        public Guid m_id { get; }
    }
}
