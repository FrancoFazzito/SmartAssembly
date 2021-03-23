using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Interfaces.Error;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Console_.Container;
using Infra.Interfaces.Connections;
using Infra.Repositories.Implementations.Clients;
using Infra.Repositories.Implementations.Components;
using Infra.Repositories.Implementations.Computers;
using Infra.Repositories.Implementations.Employees;
using Infra.Repositories.Implementations.Errors;
using Infra.Repositories.Implementations.Orders;
using Infra.Repositories.Implementations.TypeUses;
using Infra.SqlServer.Connections;
using System;

namespace Tests
{
    public class DependencyContainerMock
    {
        public DependencyContainerMock()
        {
            Container = new DependencyContainer();
            Container.Register<IConnection>(() => new Connection());
            Container.Register<IComponentReadOnlyRepository>(() => new ComponentReadOnlyRepository(Container.Resolve<IConnection>()));
            Container.Register<ITypeUseReadOnlyRepository>(() => new TypeUseReadOnlyRepository(Container.Resolve<IConnection>()));
            Container.Register<IEmployeeReadOnlyRepository>(() => new EmployeeReadOnlyRepository(Container.Resolve<IConnection>()));
            Container.Register<IOrderWriteOnlyRepository>(() => new OrderWriteOnlyRepository(Container.Resolve<IConnection>()));
            Container.Register<IClientReadOnlyRepository>(() => new ClientReadOnlyRepository(Container.Resolve<IConnection>()));
            Container.Register<IErrorWriteOnlyRepository>(() => new ErrorWriteOnlyRepository(Container.Resolve<IConnection>()));
            Container.Register<IComputerReadOnlyRepository>(() => new ComputerReadOnlyRepository(Container.Resolve<IConnection>(), Container.Resolve<IComponentReadOnlyRepository>()));
            Container.Register<IOrderReadOnlyRepository>(() => new OrderReadOnlyRepository(Container.Resolve<IConnection>(), Container.Resolve<IComputerReadOnlyRepository>(), Container.Resolve<IEmployeeReadOnlyRepository>(), Container.Resolve<IClientReadOnlyRepository>()));
            Container.Register<IFactoryCompatibility>(() => new FactoryCompatibility());
            Container.Register<IFactoryEnough>(() => new FactoryEnough());
            Container.Register<IStrategyOrderBy>(() => new StrategyOrderBy());
        }

        public void Register<T>(Func<T> createInstance, string instanceName = null)
        {
            Container.Register(createInstance, instanceName);
        }

        public T Resolve<T>(string instanceName = null)
        {
            return Container.Resolve<T>(instanceName);
        }

        public IContainer Container { get; }
    }
}
