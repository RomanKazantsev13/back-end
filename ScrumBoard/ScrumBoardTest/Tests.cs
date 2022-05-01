using Xunit;
using ScrumBoard;

namespace ScrumBoardTest
{
    public class Tests
    {
        [Fact]
        public void Add_Task()
        {
            IBoard board = Factory.CreateBoard("Home");
            board.AddColumn("To Do");
            string title = "Feed the cat";

            board.AddTask(title, "", ITask.Priority.Normal);

            Assert.Single(board.m_columns);
            Assert.Single(board.m_columns[0].m_tasks);
            Assert.Equal(title, board.m_columns[0].m_tasks[0].m_title);
        }

        [Fact]
        public void Remove_Task()
        {
            IBoard board = Factory.CreateBoard("Home");
            board.AddColumn("To Do");
            board.AddTask("Feed the cat", "", ITask.Priority.Normal);
            IColumn column = board.m_columns[0];
            ITask task = column.m_tasks[0];

            column.RemoveTask(task.m_id);

            Assert.Empty(column.m_tasks);
        }

        [Fact]
        public void Remove_Column()
        {
            IBoard board = Factory.CreateBoard("Home");
            board.AddColumn("To Do");
            board.AddColumn("Done");
            IColumn columnDone = board.m_columns[1];

            board.RemoveColumn(columnDone.m_id);

            Assert.Single(board.m_columns);
            Assert.Equal("To Do", board.m_columns[0].m_title);
        }

        [Fact]
        public void Move_Task()
        {
            IBoard board = Factory.CreateBoard("Home");
            board.AddColumn("To Do");
            board.AddColumn("Done");
            board.AddTask("Feed the cat", "", ITask.Priority.Normal);
            IColumn columnToDo = board.m_columns[0];
            IColumn columnDone = board.m_columns[1];
            ITask task = columnToDo.m_tasks[0];

            board.MoveTask(columnDone.m_id, task.m_id);

            Assert.Empty(columnToDo.m_tasks);
            Assert.Single(columnDone.m_tasks);
        }

        [Fact]
        public void Add_11th_Task()
        {
            IBoard board = Factory.CreateBoard("Home");
            for (int i = 1; i <= 10; ++i)
            {
                string title = "column_" + i;
                board.AddColumn(title);
            }

            board.AddColumn("New Column");

            Assert.Equal(10, board.m_columns.Count);
            Assert.Equal("column_10", board.m_columns[9].m_title);
        }
    }
}
