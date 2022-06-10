using Xunit;
using ScrumBoard;

namespace ScrumBoardTest;

public class Tests
{
    [Fact]
    public void Add_Task()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        string title = "Feed the cat";

        board.AddTask(title, "", ITask.TaskPriority.Normal);

        Assert.Single(board.Columns);
        Assert.Single(board.Columns[0].Tasks);
        Assert.Equal(title, board.Columns[0].Tasks[0].Title);
    }

    [Fact]
    public void Remove_Task()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        board.AddTask("Feed the cat", "", ITask.TaskPriority.Normal);
        IColumn column = board.Columns[0];
        ITask task = column.Tasks[0];

        column.RemoveTask(task.Id);

        Assert.Empty(column.Tasks);
    }

    [Fact]
    public void Remove_Column()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        board.AddColumn("Done");
        IColumn columnDone = board.Columns[1];

        board.RemoveColumn(columnDone.Id);

        Assert.Single(board.Columns);
        Assert.Equal("To Do", board.Columns[0].Title);
    }

    [Fact]
    public void Move_Task()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        board.AddColumn("Done");
        board.AddTask("Feed the cat", "", ITask.TaskPriority.Normal);
        IColumn columnToDo = board.Columns[0];
        IColumn columnDone = board.Columns[1];
        ITask task = columnToDo.Tasks[0];

        board.MoveTask(columnDone.Id, task.Id);

        Assert.Empty(columnToDo.Tasks);
        Assert.Single(columnDone.Tasks);
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

        Assert.Equal(10, board.Columns.Count);
        Assert.Equal("column_10", board.Columns[9].Title);
    }
}
