﻿using Application.Repositories.Orders.Interfaces;
using Domain.Components;
using Domain.Computers;
using Domain.Orders;
using Infra.Interfaces.Connections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infra.Repositories.Implementations.Orders
{
    public class OrderWriteOnlyRepository : IOrderWriteOnlyRepository
    {
        private const string PARAMETER_PRICE = "price";
        private const string PARAMETER_ORDER_DATE = "orderDate";
        private const string PARAMATER_ORDER_DELIVERY = "orderDelivery";
        private const string PARAMETER_ID_COMPONENT = "id_component";
        private const string PARAMETER_ID_EMPLOYEE = "Id_employee";
        private const string PARAMETER_TYPE_USE = "typeUse";
        private const string PARAMETER_EMAIL_CLIENT = "Email_client";
        private readonly IConnection connection;

        public OrderWriteOnlyRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void Insert(Order order)
        {
            List<SqlCommand> commands = new List<SqlCommand>
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
            using (var commandComputer = new SqlCommand($"INSERT INTO [Computer] VALUES((SELECT IDENT_CURRENT('order')),@{PARAMETER_TYPE_USE})"))
            {
                commandComputer.Parameters.AddWithValue(PARAMETER_TYPE_USE, computer.TypeUse);
                return commandComputer;
            }
        }

        private SqlCommand CommandOrder(Order order)
        {
            using (var commandOrder = new SqlCommand($"INSERT INTO [Order] VALUES (@{PARAMETER_PRICE},@{PARAMETER_ORDER_DATE},@{PARAMATER_ORDER_DELIVERY},@{PARAMETER_ID_EMPLOYEE},@{PARAMETER_EMAIL_CLIENT})"))
            {
                commandOrder.Parameters.AddWithValue(PARAMETER_PRICE, order.Price);
                commandOrder.Parameters.AddWithValue(PARAMETER_ORDER_DATE, order.OrderDate);
                commandOrder.Parameters.AddWithValue(PARAMATER_ORDER_DELIVERY, order.OrderDelivery);
                commandOrder.Parameters.AddWithValue(PARAMETER_ID_EMPLOYEE, order.Employee.Email);
                commandOrder.Parameters.AddWithValue(PARAMETER_EMAIL_CLIENT, order.Client.Email);
                return commandOrder;
            }
        }
    }
}
