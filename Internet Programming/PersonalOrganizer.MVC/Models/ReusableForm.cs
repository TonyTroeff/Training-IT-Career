namespace PersonalOrganizer.MVC.Models;

public class ReusableForm<TData>
{
    public required TData Data { get; init; }
    public required string Action { get; init; }
    public required string Button { get; init; }
}
