using Application.Repositories.Interfaces.Confuguration.Update;

namespace Application.Configuration.Commands.Update
{
    public class UpdateCost
    {
        private readonly IUpdateCost update;

        public UpdateCost(IUpdateCost update)
        {
            this.update = update;
        }

        public void Update(string name,int value)
        {
            update.EditValue(name,value);
        }
    }
}
