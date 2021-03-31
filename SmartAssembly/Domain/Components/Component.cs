using Domain.Compatibilities.Interfaces;
using Domain.Components.Types;
using Domain.Enoughs.Interfaces;

namespace Domain.Components
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PerfomanceLevel { get; set; }
        public TypePart TypePart { get; set; }
        public int Watts { get; set; } = 20;
        public string Socket { get; set; }
        public bool HasIntegratedVideo { get; set; }
        public int Channels { get; set; }
        public int VideoLevel { get; set; }
        public int FanLevel { get; set; }
        public bool NeedHighFrecuency { get; set; }
        public int Capacity { get; set; }
        public int FanSize { get; set; }
        public TypeFormat TypeFormat { get; set; }
        public TypeMemory TypeMemory { get; set; }
        public int MaxFrecuency { get; set; }
        public int Stock { get; set; }
        public int StockLimit { get; set; } = 1;

        public bool IsCompatibleWith(ICompatible Compatibility, Component component)
        {
            return Compatibility.IsCompatibleWith(this, component);
        }

        public bool IsEnough(IEnough enough, int quantity)
        {
            return enough.IsEnough(this, quantity);
        }

        public bool IsType(TypePart type)
        {
            return TypePart == type;
        }
    }
}
