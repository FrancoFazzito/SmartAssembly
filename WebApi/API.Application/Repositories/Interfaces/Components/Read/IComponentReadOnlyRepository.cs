using Domain.Components;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IComponentReadOnlyRepository
    {
        IEnumerable<Component> All { get; }

        Component GetById(int? id);

        Component GetByName(string name);

        IEnumerable<Component> GetByComputer(int id);
    }
}