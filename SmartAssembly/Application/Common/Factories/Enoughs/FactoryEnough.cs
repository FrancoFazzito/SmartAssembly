
using Domain.Enoughs.Enums;
using Domain.Enoughs.Implementations;
using Domain.Enoughs.Interfaces;
using System.Collections.Generic;

namespace Application.Common.Factories.Enoughs
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
                { Enough.VideoLevel, new EnoughVideoLevel() },
                { Enough.Level, new EnoughLevel() },
                { Enough.MultipleRam, new EnoughMultipleRam() },
                { Enough.Stock, new EnoughStock() }
            };
        }

        public IEnough this[Enough enough] => enoughs[enough];
    }
}
