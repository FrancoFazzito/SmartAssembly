using Domain.Enoughs.Enums;
using Domain.Enoughs.Interfaces;

namespace Application.Common.Factories.Enoughs
{
    public interface IFactoryEnough
    {
        IEnough this[Enough compatibility] { get; }
    }
}