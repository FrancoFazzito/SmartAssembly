using Application.Repositories.Interfaces;
using Domain.Components;
using System.Collections.Generic;

namespace Application.Components.Commands.Read
{
    public class ReadComponent
    {
        private readonly IComponentReadOnlyRepository read;

        public ReadComponent(IComponentReadOnlyRepository read)
        {
            this.read = read;
        }

        public IEnumerable<Component> All => read.All;
    }
}