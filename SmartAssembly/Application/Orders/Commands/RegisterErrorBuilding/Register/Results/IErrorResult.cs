namespace Application.Orders.Commands.Register.RegisterErrorBuilding.Results
{
    public interface IErrorResult
    {
        decimal PriceDifference { get; }
        string NewComponent { get; }
        string OldComponent { get; }
        string Commentary { get; }
    }
}