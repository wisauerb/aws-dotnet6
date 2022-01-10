namespace TodoApi.Models;

// using record type in Dapper
// https://github.com/DapperLib/Dapper/issues/1571#issuecomment-984878454

public record TodoItem
{
    public TodoItem(int id, string name, bool isComplete)
    {
        Id = id;
        Name = name;
        IsComplete = isComplete;
    }

    public int Id { get; init; }
    public string? Name { get; init; }
    public bool IsComplete { get; init; }
}
