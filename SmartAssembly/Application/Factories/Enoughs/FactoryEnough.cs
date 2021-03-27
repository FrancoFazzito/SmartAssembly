
using Domain.Enoughs.Enums;
using Domain.Enoughs.Implementations;
using Domain.Enoughs.Interfaces;
using System.Collections.Generic;

namespace Application.Factories.Enoughs
{
    public class FactoryEnough : IFactoryEnough
    {
        private readonly Dictionary<Enough, IEnough> enoughs;

        public FactoryEnough()
        {
            enoughs = new Dictionary<Enough, IEnough>
            {
                { Enough.Capacity, new EnoughCapacity() },
                { Enough.Channels, new EnoughChannels() },
                { Enough.Fan, new EnoughFan() },
                { Enough.VideoLevel, new EnoughGpu() },
                { Enough.Level, new EnoughLevel() },
                { Enough.OneRam, new EnoughOneRam() },
                { Enough.Stock, new EnoughStock() }
            };
        }

        public IEnough this[Enough enough] => enoughs[enough];
    }
}
