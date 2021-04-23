using Domain.Components;
using Domain.Components.Types;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Computers
{
    public class Computer
    {
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
        public string TypeUse { get; set; }
        public bool Completed { get; set; }
        public int CostBuild { get; set; }
        public int Multiplier { get; set; }
        public IEnumerable<Component> Components { get => components; set => components = value.ToList(); }
        public decimal Price => components.Sum(c => c.Price) + CostBuild;
        public int TotalConsumption => components.Sum(c => c.Watts);
        public decimal Perfomance => components.Sum(c => c.PerfomanceLevel);
        public decimal PricePerfomance => System.Math.Round(Perfomance / Price * Multiplier, 2);
        public Component this[TypePart part] => Components.FirstOrDefault(c => c.TypePart == part);
    }
}