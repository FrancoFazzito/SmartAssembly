namespace Application.Commands.EditCongifuration
{
    public interface IConfigurationEditor
    {
        void EditCostBuild(int newValue);
        void EditPricePerfomanceMultiplier(int newValue);
    }
}