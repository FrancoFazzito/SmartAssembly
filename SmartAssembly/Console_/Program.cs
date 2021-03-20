using Application.Commands.Build.Builders;
using Application.Commands.Build.Directors;
using Application.Commands.Build.Importances;
using Application.Commands.Build.Orders;
using Application.Commands.Build.Request;
using Application.Commands.Build.Specifications;
using Application.Commands.RegisterComputerError.Errors;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Orders.Interfaces;
using Application.Repositories.TypeUses.Interfaces;
using Application.Strategies.OrderBy;
using Domain.Clients;
using Domain.Computers;
using Infra.Interfaces.Connections;
using Infra.Repositories.Implementations.Components;
using Infra.Repositories.Implementations.Employees;
using Infra.Repositories.Implementations.Orders;
using Infra.Repositories.Implementations.TypeUses;
using Infra.SqlServer.Connections;
using System.Collections.Generic;
using System.Linq;
using System;
using Console_.Container;

namespace Console_
{
    public class Program
    {
        //register in BD error
        //get computer and order from BD
        //llevar el submit a un proyecto de test

        private static IContainer container;

        private static void Main()
        {
            TestRegisterDependencies();
            var computer = TestBuildComputer().ElementAt(0);
            TestSubmitOrder(computer);
            RegisterError(computer);
            Console.Read();
        }

        private static void RegisterError(Computer computer)
        {
            var factoryCompatibility = container.Resolve<IFactoryCompatibility>();
            var factoryEnough = container.Resolve<IFactoryEnough>();
            var repository = container.Resolve<IComponentReadOnlyRepository>();
            var register = new RegisterError(computer, repository, factoryCompatibility, factoryEnough);
            var result = register.Register(computer.Components.ElementAt(0));
            Console.WriteLine(result.PriceDiference);
        }

        private static void TestRegisterDependencies()
        {
            container = new DependencyContainer();
            container.Register<IConnection>(() => new Connection());
            container.Register<IComponentReadOnlyRepository>(() => new ComponentReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<ITypeUseReadOnlyRepository>(() => new TypeUseReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IEmployeeReadOnlyRepository>(() => new EmployeeReadOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IOrderWriteOnlyRepository>(() => new OrderWriteOnlyRepository(container.Resolve<IConnection>()));
            container.Register<IFactoryCompatibility>(() => new FactoryCompatibility());
            container.Register<IFactoryEnough>(() => new FactoryEnough());
            container.Register<IStrategyOrderBy>(() => new StrategyOrderBy());
        }

        private static IEnumerable<Computer> TestBuildComputer()
        {
            var repoType = container.Resolve<ITypeUseReadOnlyRepository>();
            var request = new ComputerRequest(TypeUse.gaming, 1200000, repoType);
            var factoryCompatibility = container.Resolve<IFactoryCompatibility>();
            var factoryEnough = container.Resolve<IFactoryEnough>();
            var factoryOrderBy = container.Resolve<IStrategyOrderBy>();
            var repoComponent = container.Resolve<IComponentReadOnlyRepository>();
            var builder = new BuilderComputer(request, Importance.Price, factoryOrderBy, factoryCompatibility, factoryEnough, repoComponent);
            var computers = new DirectorComputer(builder).Build().Computers;
            foreach (var c in computers)
            {
                Console.WriteLine();
                Console.WriteLine(c.TypeUse);
                foreach (var component in c.Components)
                {
                    Console.WriteLine(component.Name + " " + component.Price);
                }
                Console.WriteLine(c.PricePerfomance);
            }
            return computers;
        }

        private static void TestSubmitOrder(Computer computer)
        {
            var repoOrder = container.Resolve<IOrderWriteOnlyRepository>();
            var repoEmployee = container.Resolve<IEmployeeReadOnlyRepository>();
            var order = new OrderHandler(repoOrder, repoEmployee);
            order.Add(computer, 1);
            order.Submit(new Client("juan", "123123123", "juan@gmail", "berutti 2062")); //repo cliente
        }
    }
}
