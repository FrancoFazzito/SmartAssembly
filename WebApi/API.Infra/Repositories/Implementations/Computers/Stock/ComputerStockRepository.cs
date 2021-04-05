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

        public bool IsValid(Computer computer, int quantity)
        {
            var componentsQuantity = new Dictionary<int,int>();
            foreach (var component in computer.Components)
            {
                if (componentsQuantity.ContainsKey(component.Id))
                {
                    componentsQuantity[component.Id] += computer.QuantityOf(component) * quantity;
                }
                else
                {
                    componentsQuantity.Add(component.Id ,computer.QuantityOf(component) * quantity);
                }
            }

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