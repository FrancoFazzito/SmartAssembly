using Application.Common.Factories.Compatibilities;
using Application.Common.Factories.Enoughs;
using Application.Common.Strategies.OrderBy;
using Application.Components.Commands.ControlStock;
using Application.Computers.Commands.Build;
using Application.Costs.Commands.Update;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Orders.Commands.RegisterError;
using Application.Repositories.Interfaces;
using Application.Repositories.Interfaces.Confuguration.Update;
using Domain.Clients;
using Domain.Components;
using Infra.Connections;
using Infra.Repositories.Implementations.Clients;
using Infra.Repositories.Implementations.Clients.Create;
using Infra.Repositories.Implementations.Clients.Delete;
using Infra.Repositories.Implementations.Components;
using Infra.Repositories.Implementations.Computers;
using Infra.Repositories.Implementations.Costs.Read;
using Infra.Repositories.Implementations.Costs.Update;
using Infra.Repositories.Implementations.Employees;
using Infra.Repositories.Implementations.Errors;
using Infra.Repositories.Implementations.Orders;
using Infra.Repositories.Implementations.Orders.Delete;
using Infra.Repositories.Implementations.TypeUses;
using Infra.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace WebApi
{
    public class Startup
    {
        public delegate IDeleteById DeleteByIdResolver(DeletesID key);

        public delegate IDeleteByEmail DeleteByEmailResolver(DeletesEmail key);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
            services.AddOptions();

            //register dependencies
            //get computers
            services.AddTransient<IConnection, Connection>();
            services.AddTransient<IComponentReadOnlyRepository, ComponentReadOnlyRepository>();
            services.AddTransient<IFactoryCompatibility, FactoryCompatibility>();
            services.AddTransient<IFactoryEnough, FactoryEnough>();
            services.AddTransient<IStrategyOrderBy, StrategyOrderBy>();
            services.AddTransient<ICostsReadOnlyRepository, CostsReadOnlyRepository>();
            services.AddTransient<IBuilderComputer, BuilderComputer>();
            services.AddTransient<IDirectorComputer, DirectorComputer>();
            services.AddTransient<ITypeUseReadOnlyRepository, TypeUseReadOnlyRepository>();

            //create order
            services.AddTransient<ISubmitOrderRepository, SubmitOrderRepository>();
            services.AddTransient<IEmployeeReadOnlyRepository, EmployeeReadOnlyRepository>();
            services.AddTransient<IClientReadOnlyRepository, ClientReadOnlyRepository>();
            services.AddTransient<IComputerStockRepository, ComputerStockRepository>();
            services.AddTransient<IComponentStock, ControlStock>();
            services.AddTransient<ISubmitOrder, SubmitOrder>();

            //build order
            services.AddTransient<IComputerReadOnlyRepository, ComputerReadOnlyRepository>();
            services.AddTransient<IBuildOrderRepository, BuildOrderRepository>();
            services.AddTransient<IOrderReadOnlyRepository, OrderReadOnlyRepository>();
            services.AddTransient<IBuilderOrder, BuilderOrder>();

            //deliver order
            services.AddTransient<IDeliverOrderRepository, DeliverOrderRepository>();

            //update costs
            services.AddTransient<IUpdateCostRepository, UpdateCostRepository>();
            services.AddTransient<IUpdateCost, UpdateCost>();

            //get costs
            services.AddTransient<ICostsReadOnlyRepository, CostsReadOnlyRepository>();

            //register error build
            services.AddTransient<IErrorBuildingWriteOnlyRepository, ErrorBuildingWriteOnlyRepository>();
            services.AddTransient<IErrorBuildingWithReplaceWriteOnlyRepository, ErrorBuildingWithReplaceWriteOnlyRepository>();
            services.AddTransient<IComputerReadOnlyRepository, ComputerReadOnlyRepository>();
            services.AddTransient<IRegisterBuildError, RegisterBuildError>();

            //register error delivered
            services.AddTransient<IErrorOrderWriteOnlyRepository, ErrorOrderWriteOnlyRepository>();
            services.AddTransient<IOrderReadOnlyRepository, OrderReadOnlyRepository>();
            services.AddTransient<IRegisterErrorOrderDelivered, RegisterErrorOrderDelivered>();

            //delete computer
            services.AddTransient<DeleteComputerRepository>();

            //delete order
            services.AddTransient<DeleteOrderRepository>();

            //delete component
            services.AddTransient<DeleteComponentRepository>();

            //create component
            services.AddTransient<ICreate<Component>, CreateComponentRepository>();

            //update component
            services.AddTransient<IUpdate<Component>, UpdateComponentRepository>();

            //create client
            services.AddTransient<ICreate<Client>, CreateClientRepository>();

            //delete client
            services.AddTransient<DeleteClientRepository>();

            services.AddTransient<DeleteByEmailResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case DeletesEmail.Client:
                        return serviceProvider.GetService<DeleteClientRepository>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddTransient<DeleteByIdResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case DeletesID.Computer:
                        return serviceProvider.GetService<DeleteComputerRepository>();
                    case DeletesID.Component:
                        return serviceProvider.GetService<DeleteComponentRepository>();
                    case DeletesID.Order:
                        return serviceProvider.GetService<DeleteOrderRepository>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}