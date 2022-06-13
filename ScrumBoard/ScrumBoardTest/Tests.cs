namespace ScrumBoardTest;

using Xunit;
using ScrumBoard;
using System.Collections.Generic;

public class Tests
{
    [Fact]
    public void AddTask_NoColumns_TaskWasNotAdded()
    { 
        IBoard board = Factory.CreateBoard("Home");

        board.AddTask("Feed the cat", "", ITask.TaskPriority.Normal);

        Assert.Empty(board.Columns);
    }

    [Fact]
    public void AddTask_ColumnToDo_TaskWasAdded()
    { 
        string title = "Feed the cat";
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");

        board.AddTask(title, "", ITask.TaskPriority.Normal);

        Assert.Single(board.Columns);
        Assert.Single(board.Columns[0].Tasks);
        Assert.True(board.Columns[0].Tasks[0].Title == title);
    }

    [Fact]
    public void RemoveTask_FromColumnToDo_ColumnToDoIsEmpty()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        board.AddTask("Feed the cat", "", ITask.TaskPriority.Normal);
        IColumn columnToDo = board.Columns[0];

        board.RemoveTask(columnToDo.Tasks[0].Id);

        Assert.Empty(columnToDo.Tasks);
    }

    [Fact]
    public void ChangeTitle_Task_TitleHasBeenChanged()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        board.AddTask("Feed the cat", "", ITask.TaskPriority.Normal);
        ITask task = board.Columns[0].Tasks[0];
        string newTitle = "Feed the dog";

        task.Title = newTitle;

        Assert.True(task.Title == newTitle);
    }

    [Fact]
    public void ChangeDescription_Task_DescriptionHasBeenChanged()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        board.AddTask("Feed the cat", "", ITask.TaskPriority.Normal);
        ITask task = board.Columns[0].Tasks[0];
        string newDescription = "Buy food in the store and feed the cat";

        task.Description = newDescription;

        Assert.True(task.Description == newDescription);
    }

    [Fact]
    public void ChangePriority_Task_PriorityHasBeenChanged()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        board.AddTask("Feed the cat", "Buy food in the store and feed the cat", ITask.TaskPriority.Normal);
        ITask task = board.Columns[0].Tasks[0];
        ITask.TaskPriority newPriority = ITask.TaskPriority.Highest;

        task.Priority = newPriority;

        Assert.True(task.Priority == newPriority);
    }

    [Fact]
    public void AddColumn_Board_ColumnWasAdded()
    {
        IBoard board = Factory.CreateBoard("Study");
        string title = "History";

        board.AddColumn(title);

        Assert.Single(board.Columns);
        Assert.True(board.Columns[0].Title == title);
    }

    [Fact]
    public void AddColumn_BoardWith10Columns_ColumnWasNotAdded()
    {
        IBoard board = Factory.CreateBoard("Study");
        for (int i = 1; i <= 10; ++i)
        {
            string title = "column_" + i;
            board.AddColumn(title);
        }

        board.AddColumn("column_11");

        Assert.True(board.Columns.Count == 10); 
        Assert.True(board.Columns[0].Title == "column_1");
        Assert.True(board.Columns[9].Title == "column_10");
    }

    [Fact]
    public void RemoveColumn_Board_ColumnWasRemoved()
    {
        IBoard board = Factory.CreateBoard("Study");
        board.AddColumn("History");

        board.RemoveColumn(board.Columns[0].Id);

        Assert.Empty(board.Columns);
    }

    [Fact]
    public void AddBoard_ScrumBoard_BoardWasAdded()
    {
        List<IBoard> boards = new List<IBoard>();
        IBoard board = Factory.CreateBoard("Study");

        boards.Add(board);

        Assert.Single(boards);
        Assert.True(boards[0].Title == "Study");
    }

    [Fact]
    public void RemoveBoard_ScrumBoard_BoardWasRemoved()
    {
        List<IBoard> boards = new List<IBoard>();
        IBoard board = Factory.CreateBoard("Study");
        boards.Add(board);

        boards.Remove(board);

        Assert.Empty(boards);
    }

    [Fact]
    public void MoveTask_Board_TaskWasMoved()
    {
        IBoard board = Factory.CreateBoard("Home");
        board.AddColumn("To Do");
        IColumn columnToDo = board.Columns[0];
        board.AddTask("Feed the cat", "", ITask.TaskPriority.Normal);
        ITask task = columnToDo.Tasks[0];
        board.AddColumn("Done");
        IColumn columnDone = board.Columns[1];

        board.MoveTask(columnDone.Id, task.Id);

        Assert.Empty(columnToDo.Tasks);
        Assert.Single(columnDone.Tasks);
        Assert.True(columnDone.Tasks[0] == task);
    }
}
