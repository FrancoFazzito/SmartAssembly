namespace Application.Orders.Commands.RegisterError
{
    public interface IErrorResult
    {
        decimal PriceDifference { get; }
        string NewComponent { get; }
        string OldComponent { get; }
        string Commentary { get; }
    }
}