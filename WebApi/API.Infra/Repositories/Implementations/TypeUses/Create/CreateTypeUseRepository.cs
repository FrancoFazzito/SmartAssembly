using Application.Repositories.Interfaces;
using Domain.Specification;
using Infra.Connections;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.TypeUses.Create
{
    public class CreateTypeUseRepository : ICreate<ISpecification>
    {
        private readonly IConnection connection;

        public CreateTypeUseRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Create(ISpecification specification)
        {
            SqlCommand command = new SqlCommand("INSERT INTO VALUES (@name,@cpu,@fan,@ram,@gpu,@hdd,@ssd)");
            command.Parameters.AddWithValue("@name", specification.Name);
            command.Parameters.AddWithValue("@cpu", specification.Cpu);
            command.Parameters.AddWithValue("@fan", specification.Fan);
            command.Parameters.AddWithValue("@ram", specification.Ram);
            command.Parameters.AddWithValue("@gpu", specification.Gpu);
            command.Parameters.AddWithValue("@hdd", specification.Hdd);
            command.Parameters.AddWithValue("@ssd", specification.Ssd);
            connection.Execute(command);
        }
    }
}
