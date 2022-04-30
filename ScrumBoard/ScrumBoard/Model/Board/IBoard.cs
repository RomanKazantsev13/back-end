namespace ScrumBoard
{
    public interface IBoard
    {
        public void AddColumn(string title);
        public void RemoveColumn(Guid id_column);
        public void AddTask(string title, string description, ITask.Priority priority);
        public void MoveTask(Guid id_column, Guid id_task);
        public string m_title { get; }
        public List<IColumn> m_columns { get; }
    }
}
