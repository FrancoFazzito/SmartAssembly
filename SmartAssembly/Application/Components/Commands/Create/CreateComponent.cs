using Application.Repositories.Interfaces;
using Domain.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Commands.Create
{
    public class CreateComponent
    {
        private readonly ICreate<Component> create;

        public CreateComponent(ICreate<Component> create)
        {
            this.create = create;
        }

        public void Create(Component component)
        {
            create.Create(component);
        }
    }
}
