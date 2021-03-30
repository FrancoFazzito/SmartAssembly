using Application.Common.Factories.Compatibilities;
using Application.Common.Factories.Enoughs;
using Application.Common.Strategies.OrderBy;
using Application.Components.Commands.ControlStock;
using Application.Computers.Commands.Build.Builders;
using Application.Computers.Commands.Build.Directors;
using Application.Configurations.Commands.Edit;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Deliver;
using Application.Orders.Commands.Register.RegisterErrorBuilding;
using Application.Orders.Commands.RegisterErrorOrderDelivered;
using Application.Orders.Commands.Submit;
using Application.Reports.Commands.CreateReports;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Interfaces.Error;
using Application.Repositories.Interfaces.Orders;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Console_.Container;
using Infra.Connections;
using Infra.Repositories.Implementations.Clients;
using Infra.Repositories.Implementations.Components;
using Infra.Repositories.Implementations.Computers;
using Infra.Repositories.Implementations.Employees;
using Infra.Repositories.Implementations.Errors;
using Infra.Repositories.Implementations.Orders;
using Infra.Repositories.Implementations.TypeUses;

namespace Console_
{
    public class Program
    {
        private static IContainer container;

        private static void Main()
        {
            RegisterDependencies();
        }

        private static void RegisterDependencies()
        {
            container = new DependencyContainer();
            container.Register<IConnection>(() => new Connection());
            container.Register<IComponentReadOnlyRepository>(() => new ComponentReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<ITypeUseReadOnlyRepository>(() => new TypeUseReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IEmployeeReadOnlyRepository>(() => new EmployeeReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<ISubmitOrderRepository>(() => new SubmitOrderRepository(container.Resolve<IConnection>()));
            container.Register<IClientReadOnlyRepository>(() => new ClientReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IErrorBuildingWriteOnlyRepository>(() => new ErrorBuildingWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IErrorReplaceWriteOnlyRepository>(() => new ErrorBuildingReplaceWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IComputerReadOnlyRepository>(() => new ComputerReadOnlyRepository(container.Resolve<IConnection>(), container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IOrderReadOnlyRepository>(() => new OrderReadOnlyRepository(container.Resolve<IConnection>(), container.Resolve<IComputerReadOnlyRepository>(), container.Resolve<IEmployeeReadOnlyRepository>(), container.Resolve<IClientReadOnlyRepository>()));
            container.Register<IComputerStockRepository>(() => new ComputerStockRepository(container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IBuildOrderRepository>(() => new BuildOrderRepository(container.Resolve<IConnection>()));
            container.Register<IBuilderOrder>(() => new BuildOrder(container.Resolve<IBuildOrderRepository>(), container.Resolve<IOrderReadOnlyRepository>()));
            container.Register<IFactoryCompatibility>(() => new FactoryCompatibility());
            container.Register<IFactoryEnough>(() => new FactoryEnough());
            container.Register<IStrategyOrderBy>(() => new StrategyOrderBy());
            container.Register<IDeliverOrderRepository>(() => new DeliverOrderRepository(container.Resolve<IConnection>()));
            container.Register<IRegisterBuildError>(() => new RegisterBuildError(container.Resolve<IComponentReadOnlyRepository>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IErrorBuildingWriteOnlyRepository>(), container.Resolve<IErrorReplaceWriteOnlyRepository>()));
            container.Register<IDeliverOrder>(() => new DeliverOrder(container.Resolve<IOrderReadOnlyRepository>(), container.Resolve<IDeliverOrderRepository>()));
            container.Register<IBuilderComputer>(() => new BuilderComputer(container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IDirectorComputer>(() => new DirectorComputer(container.Resolve<IBuilderComputer>()));
            container.Register<IControlStock>(() => new ControlStock(container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<ISubmitOrder>(() => new SubmitOrder(container.Resolve<ISubmitOrderRepository>(), container.Resolve<IEmployeeReadOnlyRepository>(), container.Resolve<IClientReadOnlyRepository>(), container.Resolve<IComputerStockRepository>(), container.Resolve<IControlStock>()));
            container.Register<IErrorComputerWriteOnlyRepository>(() => new ErrorOrderWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IRegisterErrorOrderDelivered>(() => new RegisterErrorOrderDelivered(container.Resolve<IErrorComputerWriteOnlyRepository>(), container.Resolve<IOrderReadOnlyRepository>()));
            container.Register<IReportOrders>(() => new ReportOrders(container.Resolve<IOrderReadOnlyRepository>()));
            container.Register<IConfigurationEditor>(() => new ConfigurationEditor());
        }
    }
}
