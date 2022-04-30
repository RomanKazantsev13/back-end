namespace ScrumBoard
{
    public interface ITask
    {
        public enum Priority
        {
            Highest,
            AboveNormal,
            Normal,
            BelowNormal,
            Lowest
        }
        public string m_title { get; set; }
        public string m_description { get; set; }
        public ITask.Priority m_priority { get; set; }
        public Guid m_id { get; }
    }
}
