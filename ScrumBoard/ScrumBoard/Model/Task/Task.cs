namespace ScrumBoard;

public class Task : ITask
{
    public Task(string title, string description, ITask.Priority priority)
    {
        m_title = title;
        m_description = description;
        m_priority = priority;
        m_id = Guid.NewGuid();
    }

    public string m_title { get; set; }
    public string m_description { get; set; }
    public ITask.Priority m_priority { get; set; }
    public Guid m_id { get; }
}
