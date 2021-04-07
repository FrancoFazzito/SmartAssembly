using Application.Common.Factories.Compatibilities;
using Application.Common.Factories.Enoughs;
using Application.Common.Strategies.OrderBy;
using Application.Components.Commands.ControlStock;
using Application.Computers.Commands.Build;
using Application.Orders.Commands.Build;
using Application.Orders.Commands.Create;
using Application.Repositories.Interfaces;
using Infra.Connections;
using Infra.Repositories.Implementations.Clients;
using Infra.Repositories.Implementations.Components;
using Infra.Repositories.Implementations.Computers;
using Infra.Repositories.Implementations.Costs.Read;
using Infra.Repositories.Implementations.Employees;
using Infra.Repositories.Implementations.Orders;
using Infra.Repositories.Implementations.TypeUses;
using Infra.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Startup
    {
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
