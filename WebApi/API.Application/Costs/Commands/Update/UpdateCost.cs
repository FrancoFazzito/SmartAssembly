using Application.Repositories.Interfaces;
using Application.Repositories.Interfaces.Confuguration.Update;
using System.Linq;

namespace Application.Costs.Commands.Update
{
    public class UpdateCost : IUpdateCost
    {
        private readonly IUpdateCostRepository update;
        private readonly ICostsReadOnlyRepository read;

        public UpdateCost(IUpdateCostRepository update, ICostsReadOnlyRepository read)
        {
            this.update = update;
            this.read = read;
        }

        public void Update(string name, int? value)
        {
            if (NotExistsCost(name))
            {
                throw new NotFoundCostException();
            }

            update.EditValue(name, value);
        }

        private bool NotExistsCost(string name)
        {
            return read.All.FirstOrDefault(c => c.Item1 == name) == null;
        }
    }
}