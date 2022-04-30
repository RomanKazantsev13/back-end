namespace ScrumBoard
{
    public class Board : IBoard
    {
        public Board(string title)
        {
            m_title = title;
            m_columns = new List<IColumn>();
        }

        public void AddColumn(string title)
        {
            if (m_columns.Count() >= 10)
            {
                return;
            }

            IColumn column = Factory.CreateColumn(title);
            m_columns.Add(column);
        }

        public void RemoveColumn(Guid id_column)
        {
            IColumn? column = GetColumnById(id_column);

            if (column != null)
            {
                m_columns.Remove(column);
            }
        }

        public void AddTask(string title, string description, ITask.Priority priority)
        {
            ITask task = Factory.CreateTask(title, description, priority);
            m_columns[0].AddTask(task);
        }

        public void MoveTask(Guid id_column, Guid id_task)
        {
            ITask? task = null;

            foreach (IColumn column in m_columns)
            {
                task = column.GetTaskById(id_task);
                if (task != null)
                {
                    column.RemoveTask(task.m_id);
                    break;
                }
            }

            IColumn? newColumn = GetColumnById(id_column);

            if (newColumn != null && task != null)
            {
                newColumn.AddTask(task);
            }
        }

        private IColumn? GetColumnById(Guid id_column)
        {
            foreach (IColumn column in m_columns)
            {
                if (column.m_id == id_column)
                {
                    return column;
                }
            }
            return null;
        }

        public string m_title { get; }
        public List<IColumn> m_columns { get;  }
        private Guid m_id = Guid.NewGuid();
    }
}
