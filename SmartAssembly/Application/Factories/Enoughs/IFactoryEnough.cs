using Domain.Enoughs.Enums;
using Domain.Enoughs.Interfaces;

namespace Application.Factories.Enoughs
{
    public interface IFactoryEnough
    {
        IEnough this[Enough compatibility] { get; }
    }
}
