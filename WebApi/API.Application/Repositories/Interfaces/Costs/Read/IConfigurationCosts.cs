using System;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface ICostsReadOnlyRepository
    {
        IEnumerable<Tuple<string, int>> All { get; }
        int BuildCost { get; }
        int PricePerfomanceMultiplier { get; }
    }
}