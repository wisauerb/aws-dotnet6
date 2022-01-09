namespace TodoApi.Models;

// using record type in Dapper
// https://github.com/DapperLib/Dapper/issues/1571#issuecomment-984878454

public record TodoItem
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public bool IsComplete { get; init; }
}
