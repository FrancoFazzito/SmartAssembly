using Application.Repositories.Components.Interfaces;
using Domain.Components;
using System.Collections.Generic;
using System.Linq;

namespace Application.Commands.ControlStock
{
    public class ControlStock : IControlStock
    {
        private readonly IComponentReadOnlyRepository componentRepo;

        public ControlStock(IComponentReadOnlyRepository componentRepo)
        {
            this.componentRepo = componentRepo;
        }

        public IEnumerable<Component> ComponentsLowStock => componentRepo.All.Where(c => c.Stock <= c.StockLimit);
    }
}
