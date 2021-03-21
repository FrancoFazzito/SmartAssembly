using Domain.Components;
using Domain.Components.Types;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Computers
{
    public class Computer
    {
        private const int MULTIPLIER_PRICE = 10000;
        private readonly List<Component> components = new List<Component>();

        public void Add(Component element, int quantity = 1)
        {
            for (var i = 0; i < quantity; i++)
            {
                components.Add(element);
            }
        }

        public void Replace(Component oldComponent, Component newComponent)
        {
            Remove(oldComponent);
            Add(newComponent, components.Count(c => c.Id == oldComponent.Id));
        }

        public void Remove(Component element)
        {
            components.RemoveAll(c => c == element);
        }

        public int Id { get; set; }
        public string TypeUse { get; set; }
        public IEnumerable<Component> Components => components;
        public decimal Price => components.Sum(c => c.Price);
        public int TotalConsumption => components.Sum(c => c.Watts);
        public decimal Perfomance => components.Sum(c => c.PerfomanceLevel);
        public decimal PricePerfomance => System.Math.Round(Perfomance / Price * MULTIPLIER_PRICE, 2);
        public Component this[TypePart part] => Components.FirstOrDefault(c => c.TypePart == part);
    }
}
