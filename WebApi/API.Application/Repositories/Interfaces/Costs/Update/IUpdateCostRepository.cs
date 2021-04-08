namespace Application.Repositories.Interfaces.Confuguration.Update
{
    public interface IUpdateCostRepository
    {
        void EditValue(string name, int? newValue);
    }
}