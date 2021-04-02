using Application.Repositories.Interfaces;
using Domain.Computers;
using System.Linq;

namespace Infra.Repositories.Implementations.Computers
{
    public class ComputerStockRepository : IComputerStockRepository
    {
        public ComputerStockRepository(IComponentReadOnlyRepository componentRepository)
        {
            ComponentRepository = componentRepository;
        }

        public IComponentReadOnlyRepository ComponentRepository { get; }

        public bool IsValid(Computer computer, int quantity)
        {
            foreach (var componentQuantity in computer.Components.GroupBy(x => x).ToDictionary(x => x.Key.Id, y => y.Count() * quantity))
            {
                if (ComponentRepository.GetById(componentQuantity.Key).Stock < componentQuantity.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}