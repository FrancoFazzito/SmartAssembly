﻿using Application.Commands.BuildComputers;
using Application.Commands.BuildOrders;
using Application.Commands.ControlStock;
using Application.Commands.CreateReports;
using Application.Commands.DeliverOrders;
using Application.Commands.EditCongifuration;
using Application.Commands.RegisterBuildingError;
using Application.Commands.RegisterOrderErrors;
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
using Infra.Connections;
using Infra.Repositories.Implementations.Clients;
using Infra.Repositories.Implementations.Components;
using Infra.Repositories.Implementations.Computers;
using Infra.Repositories.Implementations.Employees;
using Infra.Repositories.Implementations.Errors;
using Infra.Repositories.Implementations.Orders;
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
