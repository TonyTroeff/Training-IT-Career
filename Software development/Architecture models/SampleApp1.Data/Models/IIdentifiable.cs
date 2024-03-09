namespace SampleApp1.Data.Models
{
    public interface IIdentifiable
    {
        Guid Id { get; } // We removed the `set` accessor but it may be useful in future - we don't know.
    }
}
