namespace Application.Costs.Commands.Update
{
    public interface IUpdateCost
    {
        void Update(string name, int? value);
    }
}