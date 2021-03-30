using Domain.Components;
using Domain.Components.Types;
using Domain.Configurations;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Computers
{
    public class Computer
    {
        private readonly IConfigurationCosts configuration = new ConfigurationCosts();
        private ICollection<Component> components = new List<Component>();

        public void Add(Component element, int quantity = 1)
        {
            for (var i = 0; i < quantity; i++)
            {
                components.Add(element);
            }
        }

        public int QuantityOf(Component oldComponent)
        {
            return components.Count(c => c.Id == oldComponent.Id);
        }

        public int Id { get; set; }
        public TypeUse TypeUse { get; set; }
        public bool Completed { get; set; }
        public IEnumerable<Component> Components { get => components; set => components = value.ToList(); }
        public decimal Price => components.Sum(c => c.Price) + configuration.BuildCost;
        public int TotalConsumption => components.Sum(c => c.Watts);
        public decimal Perfomance => components.Sum(c => c.PerfomanceLevel);
        public decimal PricePerfomance => System.Math.Round(Perfomance / Price * configuration.PricePerfomanceMultiplier, 2);
        public Component this[TypePart part] => Components.FirstOrDefault(c => c.TypePart == part);
    }
}
