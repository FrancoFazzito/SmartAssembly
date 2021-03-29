using Application.Repositories.Orders.Interfaces;
using Domain.Components;
using Domain.Computers;
using Domain.Orders;
using Infra.Interfaces.Connections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders
{
    public class SubmitOrderRepository : ISubmitOrderRepository
    {
        private const string PARAMETER_PRICE = "price";
        private const string PARAMETER_ORDER_DATE = "orderDate";
        private const string PARAMATER_ORDER_DELIVERY = "orderDelivery";
        private const string PARAMETER_ID_COMPONENT = "id_component";
        private const string PARAMETER_ID_EMPLOYEE = "Id_employee";
        private const string PARAMETER_TYPE_USE = "typeUse";
        private const string PARAMETER_EMAIL_CLIENT = "Email_client";
        private const string PARAMETER_COMMENTARY = "Commentary";
        private const string PARAMETER_STATE = "State";
        private const string PARAMETER_DELIVERED = "DateDelivered";
        private readonly IConnection connection;

        public SubmitOrderRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(Order order)
        {
            var commands = new List<SqlCommand>
            {
                CommandOrder(order)
            };
            foreach (var computer in order.Computers)
            {
                commands.Add(CommandComputer(computer));
                foreach (var component in computer.Components)
                {
                    commands.Add(CommandComponent(component));
                    commands.Add(CommandStock(component));
                }
            }
            connection.Execute(commands);
        }

        private SqlCommand CommandStock(Component component)
        {
            using (var commandStock = new SqlCommand($"UPDATE [Component] SET Stock = Stock - 1 WHERE ID = @{PARAMETER_ID_COMPONENT}"))
            {
                commandStock.Parameters.AddWithValue(PARAMETER_ID_COMPONENT, component.Id);
                return commandStock;
            }
        }

        private SqlCommand CommandComponent(Component component)
        {
            using (var commandComponent = new SqlCommand($"INSERT INTO [Component_Computer] VALUES (@{PARAMETER_ID_COMPONENT} , (SELECT IDENT_CURRENT('computer')))"))
            {
                commandComponent.Parameters.AddWithValue(PARAMETER_ID_COMPONENT, component.Id);
                return commandComponent;
            }
        }

        private SqlCommand CommandComputer(Computer computer)
        {
            using (var commandComputer = new SqlCommand($"INSERT INTO [Computer] VALUES((SELECT IDENT_CURRENT('order')),@{PARAMETER_TYPE_USE},0)"))
            {
                commandComputer.Parameters.AddWithValue(PARAMETER_TYPE_USE, computer.TypeUse.ToString());
                return commandComputer;
            }
        }

        private SqlCommand CommandOrder(Order order)
        {
            using (var commandOrder = new SqlCommand($"INSERT INTO [Order] VALUES (@{PARAMETER_PRICE},@{PARAMETER_ORDER_DATE},@{PARAMATER_ORDER_DELIVERY},@{PARAMETER_ID_EMPLOYEE},@{PARAMETER_EMAIL_CLIENT},@{PARAMETER_COMMENTARY},@{PARAMETER_STATE},@DateDelivered)"))
            {
                commandOrder.Parameters.AddWithValue(PARAMETER_PRICE, order.Price);
                commandOrder.Parameters.AddWithValue(PARAMETER_ORDER_DATE, order.DateRequested);
                commandOrder.Parameters.AddWithValue(PARAMATER_ORDER_DELIVERY, order.DateToDelivery);
                commandOrder.Parameters.AddWithValue(PARAMETER_ID_EMPLOYEE, order.Employee.Email);
                commandOrder.Parameters.AddWithValue(PARAMETER_EMAIL_CLIENT, order.Client.Email);
                commandOrder.Parameters.AddWithValue(PARAMETER_COMMENTARY, order.Commentary);
                commandOrder.Parameters.AddWithValue(PARAMETER_STATE, (int)order.State);
                commandOrder.Parameters.AddWithValue(PARAMETER_DELIVERED, System.DBNull.Value);
                return commandOrder;
            }
        }
    }
}
