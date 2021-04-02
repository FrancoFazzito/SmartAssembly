namespace Application.Repositories.Interfaces
{
    public interface ICostsReadOnlyRepository
    {
        int BuildCost { get; }
        int PricePerfomanceMultiplier { get; }
    }
}
