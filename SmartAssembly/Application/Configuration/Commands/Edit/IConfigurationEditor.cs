namespace Application.Configurations.Commands.Edit
{
    public interface IConfigurationEditor
    {
        void EditCostBuild(int newValue);

        void EditPricePerfomanceMultiplier(int newValue);
    }
}