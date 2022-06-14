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
        ITask task = Factory.CreateTask("Feed the cat", "", ITask.TaskPriority.Normal);

        board.AddTask(task);

        Assert.Empty(board.Columns);
    }

    [Fact]
    public void AddTask_ColumnToDo_TaskWasAdded()
    { 
        string title = "Feed the cat";
        IBoard board = Factory.CreateBoard("Home");
        IColumn column = Factory.CreateColumn("To Do");
        board.AddColumn(column);
        ITask task = Factory.CreateTask(title, "", ITask.TaskPriority.Normal);

        board.AddTask(task);

        Assert.Single(board.Columns);
        Assert.Single(board.Columns[0].Tasks);
        Assert.True(board.Columns[0].Tasks[0].Title == title);
    }

    [Fact]
    public void RemoveTask_FromColumnToDo_ColumnToDoIsEmpty()
    {
        IBoard board = Factory.CreateBoard("Home");
        IColumn column = Factory.CreateColumn("To Do");
        board.AddColumn(column);
        ITask task = Factory.CreateTask("Feed the cat", "", ITask.TaskPriority.Normal);
        board.AddTask(task);
        IColumn columnToDo = board.Columns[0];

        board.RemoveTask(columnToDo.Tasks[0].Id);

        Assert.Empty(columnToDo.Tasks);
    }

    [Fact]
    public void ChangeTitle_Task_TitleHasBeenChanged()
    {
        IBoard board = Factory.CreateBoard("Home");
        IColumn column = Factory.CreateColumn("To Do");
        board.AddColumn(column);
        ITask task = Factory.CreateTask("Feed the cat", "", ITask.TaskPriority.Normal);
        board.AddTask(task);
        ITask taskInColumn = board.Columns[0].Tasks[0];
        string newTitle = "Feed the dog";

        taskInColumn.Title = newTitle;

        Assert.True(taskInColumn.Title == newTitle);
    }

    [Fact]
    public void ChangeDescription_Task_DescriptionHasBeenChanged()
    {
        IBoard board = Factory.CreateBoard("Home");
        IColumn column = Factory.CreateColumn("To Do");
        board.AddColumn(column);
        ITask task = Factory.CreateTask("Feed the cat", "", ITask.TaskPriority.Normal);
        board.AddTask(task);
        ITask taskInColumn = board.Columns[0].Tasks[0];
        string newDescription = "Buy food in the store and feed the cat";

        taskInColumn.Description = newDescription;

        Assert.True(taskInColumn.Description == newDescription);
    }

    [Fact]
    public void ChangePriority_Task_PriorityHasBeenChanged()
    {
        IBoard board = Factory.CreateBoard("Home");
        IColumn column = Factory.CreateColumn("To Do");
        board.AddColumn(column);
        ITask task = Factory.CreateTask("Feed the cat", "Buy food in the store and feed the cat", ITask.TaskPriority.Normal);
        board.AddTask(task);
        ITask taskInColumn = board.Columns[0].Tasks[0];
        ITask.TaskPriority newPriority = ITask.TaskPriority.Highest;

        taskInColumn.Priority = newPriority;

        Assert.True(taskInColumn.Priority == newPriority);
    }

    [Fact]
    public void AddColumn_Board_ColumnWasAdded()
    {
        IBoard board = Factory.CreateBoard("Study");
        string title = "History";
        IColumn column = Factory.CreateColumn(title);

        board.AddColumn(column);

        Assert.Single(board.Columns);
        Assert.True(board.Columns[0].Title == title);
    }

    [Fact]
    public void AddColumn_BoardWith10Columns_ColumnWasNotAdded()
    {
        IBoard board = Factory.CreateBoard("Study");
        for (int i = 1; i <= 10; ++i)
        {
            IColumn column = Factory.CreateColumn("column_" + i);
            board.AddColumn(column);
        }

        IColumn column11 = Factory.CreateColumn("column_11");
        board.AddColumn(column11);

        Assert.True(board.Columns.Count == 10); 
        Assert.True(board.Columns[0].Title == "column_1");
        Assert.True(board.Columns[9].Title == "column_10");
    }

    [Fact]
    public void RemoveColumn_Board_ColumnWasRemoved()
    {
        IBoard board = Factory.CreateBoard("Study");
        IColumn column = Factory.CreateColumn("History");
        board.AddColumn(column);

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
        IColumn columnToDo = Factory.CreateColumn("To Do");
        board.AddColumn(columnToDo);
        ITask task = Factory.CreateTask("Feed the cat", "", ITask.TaskPriority.Normal);
        board.AddTask(task);
        IColumn columnDone = Factory.CreateColumn("To Do");
        board.AddColumn(columnDone);

        board.MoveTask(columnDone.Id, task.Id);

        Assert.Empty(columnToDo.Tasks);
        Assert.Single(columnDone.Tasks);
        Assert.True(columnDone.Tasks[0] == task);
    }
}
