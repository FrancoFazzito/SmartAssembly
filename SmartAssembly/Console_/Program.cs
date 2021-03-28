using Application.Commands.BuildComputers.Builders;
using Application.Commands.BuildComputers.Directors;
using Application.Commands.BuildComputers.Importances;
using Application.Commands.BuildComputers.Orders;
using Application.Commands.BuildComputers.Request;
using Application.Commands.BuildOrders;
using Application.Commands.DeliverOrders;
using Application.Commands.RegisterComputerError.Errors;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Interfaces.Error;
using Application.Repositories.Interfaces.Orders;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Console_.Container;
using Domain.Computers;
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
using System.Linq;

namespace Console_
{
    public class Program
    {
        private static IContainer container;

        private static void Main()
        {
            RegisterDependencies();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, Importance.Price, container.Resolve<ITypeUseReadOnlyRepository>());
            var director = container.Resolve<IDirectorComputer>();
            var resultDirector = director.Build(request);
            Console.WriteLine();
            foreach (var pc in resultDirector.Computers)
            {
                Console.WriteLine();
                foreach (var item in pc.Components)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine(pc.Price);
                Console.WriteLine(pc.PricePerfomance);
            }
            Console.Read();
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
            container.Register<IErrorWriteOnlyRepository>(() => new ErrorWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IErrorReplaceWriteOnlyRepository>(() => new ErrorReplaceWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IComputerReadOnlyRepository>(() => new ComputerReadOnlyRepository(container.Resolve<IConnection>(), container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IOrderReadOnlyRepository>(() => new OrderReadOnlyRepository(container.Resolve<IConnection>(), container.Resolve<IComputerReadOnlyRepository>(), container.Resolve<IEmployeeReadOnlyRepository>(), container.Resolve<IClientReadOnlyRepository>()));
            container.Register<IComputerStockRepository>(() => new ComputerStockRepository(container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IBuildOrderRepository>(() => new BuildOrderRepository(container.Resolve<IConnection>()));
            container.Register<IBuilderOrder>(() => new BuildOrder(container.Resolve<IBuildOrderRepository>(), container.Resolve<IOrderReadOnlyRepository>()));
            container.Register<IFactoryCompatibility>(() => new FactoryCompatibility());
            container.Register<IFactoryEnough>(() => new FactoryEnough());
            container.Register<IStrategyOrderBy>(() => new StrategyOrderBy());
            container.Register<IDeliverOrderRepository>(() => new DeliverOrderRepository(container.Resolve<IConnection>()));
            container.Register<IRegisterError>(() => new RegisterError(container.Resolve<IComponentReadOnlyRepository>(), container.Resolve<IFactoryCompatibility>(), container.Resolve<IFactoryEnough>(), container.Resolve<IErrorWriteOnlyRepository>(), container.Resolve<IErrorReplaceWriteOnlyRepository>()));
            container.Register<IDeliverOrder>(() => new DeliverOrder(container.Resolve<IOrderReadOnlyRepository>(), container.Resolve<IDeliverOrderRepository>()));
            container.Register<IBuilderComputer>(() => new BuilderComputer(container.Resolve<IStrategyOrderBy>(), container.Resolve<IFactoryCompatibility>(),container.Resolve<IFactoryEnough>(),container.Resolve<IComponentReadOnlyRepository>()));
            container.Register<IDirectorComputer>(() => new DirectorComputer(container.Resolve<IBuilderComputer>()));
            container.Register<ISubmitOrder>(() => new SubmitOrder(container.Resolve<ISubmitOrderRepository>(), container.Resolve<IEmployeeReadOnlyRepository>(), container.Resolve<IClientReadOnlyRepository>(), container.Resolve<IComputerStockRepository>()));
        }
    }
}
