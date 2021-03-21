using Domain.Components;
using System.Collections.Generic;

namespace Application.Repositories.Components.Interfaces
{
    public interface IComponentReadOnlyRepository
    {
        IEnumerable<Component> All { get; }
        Component GetById(int id);
        IEnumerable<Component> GetByComputerId(int id);
    }
}
