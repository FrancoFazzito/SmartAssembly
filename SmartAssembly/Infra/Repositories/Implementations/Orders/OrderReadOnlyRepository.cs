﻿using Application.Repositories.Employees.Interfaces;
using Application.Repositories.Interfaces.Clients;
using Application.Repositories.Interfaces.Computers;
using Application.Repositories.Orders.Interfaces;
using Domain.Orders;
using Infra.Interfaces.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System;
using System.Data;
using System.Linq;

namespace Infra.Repositories.Implementations.Orders
{
    public class OrderReadOnlyRepository : AbstractReadOnlyRepository<Order>, IOrderReadOnlyRepository
    {

        public OrderReadOnlyRepository(IConnection connection, IComputerReadOnlyRepository computerRepository, IEmployeeReadOnlyRepository employeeRepository, IClientReadOnlyRepository clientRepository) : base(connection)
        {
            ComputerRepository = computerRepository;
            EmployeeRepository = employeeRepository;
            ClientRepository = clientRepository;
        }

        public IComputerReadOnlyRepository ComputerRepository { get; }
        public IEmployeeReadOnlyRepository EmployeeRepository { get; }
        public IClientReadOnlyRepository ClientRepository { get; }

        protected override string QuerySelectAll => "SELECT o.ID," +
                                                           "o.OrderDate," +
                                                           "o.Email_Employee," +
                                                           "o.Email_client," +
                                                           "o.Commentary," +
                                                           "c.ID as ID_computer FROM [Order] o inner join Computer c on c.ID_Order = o.ID ";

        protected override string QuerySelectByName => $"SELECT * FROM [Order] where Email_employee = @{ParamName}";

        protected override string ParamName => "EmailEmployee";

        protected override Order NewRecord(IDataReader reader)
        {
            var id = ConvertReader<int>.WithName(reader, "id");
            return new Order
            {
                Id = id,
                OrderDate = ConvertReader<DateTime>.WithName(reader, "OrderDate"),
                Computers = ComputerRepository.GetByOrderId(id).ToList(),
                Employee = EmployeeRepository.GetByName(ConvertReader<string>.WithName(reader, "Email_Employee")),
                Client = ClientRepository.GetByName(ConvertReader<string>.WithName(reader, "Email_client")),
                Commentary = ConvertReader<string>.WithName(reader, "Commentary")
            };
        }
    }
}
