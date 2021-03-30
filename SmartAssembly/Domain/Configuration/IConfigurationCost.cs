namespace Domain.Configurations
{
    public interface IConfigurationCosts
    {
        int BuildCost { get; }
        int PricePerfomanceMultiplier { get; }
    }
}