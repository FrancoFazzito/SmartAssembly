using Application.Common.Factories.Compatibilities;
using Application.Common.Factories.Enoughs;
using Application.Common.Strategies.OrderBy;
using Application.Components.Commands.ControlStock;
using Application.Computers.Commands.Build.Builders;
using Application.Computers.Commands.Build.Directors;
using Application.Configurations.Commands.Edit;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Orders.Commands.Deliver;
using Application.Orders.Commands.Register.RegisterErrorBuilding;
using Application.Orders.Commands.RegisterErrorOrderDelivered;
using Application.Reports.Commands.Create;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Interfaces.Employees.Delete;
using Application.Repositories.Interfaces.Error;
using Application.Repositories.Interfaces.Orders;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Console_.Container;
using Domain.Components;
using Domain.Computers;
using Domain.Employees;
using Domain.Orders;
using Infra.Connections;
using Infra.Repositories.Implementations.Clients;
using Infra.Repositories.Implementations.Components;
using Infra.Repositories.Implementations.Computers;
using Infra.Repositories.Implementations.Employees;
using Infra.Repositories.Implementations.Employees.Create;
using Infra.Repositories.Implementations.Employees.Delete;
using Infra.Repositories.Implementations.Errors;
using Infra.Repositories.Implementations.Orders;
using Infra.Repositories.Implementations.Orders.Delete;
using Infra.Repositories.Implementations.Orders.Update;
using Infra.Repositories.Implementations.TypeUses;
using System;

namespace Tests
{
    public class DependencyContainerMock
    {
        private readonly IContainer container;

        public DependencyContainerMock()
        {
            container = new DependencyContainer();
            container.Register<IConnection>(() => new Connection());
            container.Register<IComponentReadOnlyRepository>(() => new ComponentReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<ITypeUseReadOnlyRepository>(() => new TypeUseReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IEmployeeReadOnlyRepository>(() => new EmployeeReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<ISubmitOrderRepository>(() => new SubmitOrderRepository(container.Resolve<IConnection>()));
            container.Register<IClientReadOnlyRepository>(() => new ClientReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IErrorBuildingWriteOnlyRepository>(() => new ErrorBuildingWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IErrorBuildingWithReplaceWriteOnlyRepository>(() => new ErrorBuildingReplaceWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IComputerReadOnlyRepository>(() => new ComputerReadOnlyRepository(container.Resolve<IConnection>(), container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IOrderReadOnlyRepository>(() => new OrderReadOnlyRepository(container.Resolve<IConnection>(), container.Resolve<IComputerReadOnlyRepository>(), container.Resolve<IEmployeeReadOnlyRepository>(), container.Resolve<IClientReadOnlyRepository>()));
            container.Register<IComputerStockRepository>(() => new ComputerStockRepository(container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IBuildOrderRepository>(() => new BuildOrderRepository(container.Resolve<IConnection>()));
            container.Register<IBuilderOrder>(() => new BuilderOrder(container.Resolve<IBuildOrderRepository>(), container.Resolve<IOrderReadOnlyRepository>()));
            container.Register<IFactoryCompatibility>(() => new FactoryCompatibility());
            container.Register<IFactoryEnough>(() => new FactoryEnough());
            container.Register<IStrategyOrderBy>(() => new StrategyOrderBy());
            container.Register<IDeliverOrderRepository>(() => new DeliverOrderRepository(container.Resolve<IConnection>()));
            container.Register<IRegisterBuildError>(() => new RegisterBuildError(container.Resolve<IComponentReadOnlyRepository>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IErrorBuildingWriteOnlyRepository>(), container.Resolve<IErrorBuildingWithReplaceWriteOnlyRepository>()));
            container.Register<IDeliverOrder>(() => new DeliverOrder(container.Resolve<IOrderReadOnlyRepository>(), container.Resolve<IDeliverOrderRepository>()));
            container.Register<IBuilderComputer>(() => new BuilderComputer(container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IDirectorComputer>(() => new DirectorComputer(container.Resolve<IBuilderComputer>()));
            container.Register<IControlStock>(() => new ControlStock(container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<ICreateOrder>(() => new CreateOrder(container.Resolve<ISubmitOrderRepository>(), container.Resolve<IEmployeeReadOnlyRepository>(), container.Resolve<IClientReadOnlyRepository>(), container.Resolve<IComputerStockRepository>(), container.Resolve<IControlStock>()));
            container.Register<IErrorOrderWriteOnlyRepository>(() => new ErrorOrderWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IRegisterErrorOrderDelivered>(() => new RegisterErrorOrderDelivered(container.Resolve<IErrorOrderWriteOnlyRepository>(), container.Resolve<IOrderReadOnlyRepository>()));
            container.Register<ICreateReport>(() => new CreateReport(container.Resolve<IOrderReadOnlyRepository>()));
            container.Register<IConfigurationEditor>(() => new ConfigurationEditor());
            container.Register<ICreate<Component>>(() => new CreateComponentRepository(container.Resolve<IConnection>()));
            container.Register<IUpdate<Component>>(() => new UpdateComponentRepository(container.Resolve<IConnection>()));
            container.Register<IUpdate<Order>>(() => new UpdateOrderRepository(container.Resolve<IConnection>()));
            container.Register<IDelete<Component>>(() => new DeleteComponentRepository(container.Resolve<IConnection>()));
            container.Register<IDelete<Computer>>(() => new DeleteComputerRepository(container.Resolve<IConnection>()));
            container.Register<IDelete<Order>>(() => new DeleteOrderRepository(container.Resolve<IConnection>()));
            container.Register<ICreate<Employee>>(() => new CreateEmployeeRepository(container.Resolve<IConnection>()));
            container.Register<IDeleteByEmail>(() => new DeleteEmployeeRepository(container.Resolve<IConnection>()));
        }

        public void Register<T>(Func<T> createInstance, string instanceName = null)
        {
            container.Register(createInstance, instanceName);
        }

        public T Resolve<T>(string instanceName = null)
        {
            return container.Resolve<T>(instanceName);
        }
    }
}