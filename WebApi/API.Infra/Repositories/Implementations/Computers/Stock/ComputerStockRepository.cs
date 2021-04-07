using Application.Repositories.Interfaces;
using Domain.Components;
using Domain.Computers;
using System.Collections.Generic;
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

        public bool IsValid(IEnumerable<Computer> computers)
        {
            return CheckStock(GetComponentsQuantity(computers.SelectMany(c => c.Components)));
        }

        private Dictionary<int, int> GetComponentsQuantity(IEnumerable<Component> components)
        {
            var componentsQuantity = new Dictionary<int, int>();
            foreach (var component in components)
            {
                if (componentsQuantity.ContainsKey(component.Id))
                {
                    componentsQuantity[component.Id] += 1;
                }
                else
                {
                    componentsQuantity.Add(component.Id, 1);
                }
            }
            return componentsQuantity;
        }

        private bool CheckStock(Dictionary<int, int> componentsQuantity)
        {
            foreach (var componentQuantity in componentsQuantity)
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