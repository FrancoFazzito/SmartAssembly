using Domain.Clients;
using Domain.Orders;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Controller.Orders.Submit;
using TestWebApi.Provider;
using WebApi.Controllers;
using WebApi.Controllers.Orders.Submit;
using Xunit;

namespace TestWebApi.Controller.Orders.Build
{
    public class OrderBuildControllerTest
    {
        [Fact]
        public async Task Test_Get_Order_By_Employee()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;
            var price = 100000;
            var use = "gaming";
            var importance = "price";
            var email = "juan@gmail";
            var response = await provider.Client.GetAsync($"api/computer?price={price}&use={use}&importance={importance}");
            var result = await response.Content.ReadAsStringAsync();
            var computers = JsonConvert.DeserializeObject<ComputerMockResult>(result);
            var computer = computers.Computers[0];
            var order = new Order()
            {
                Client = new Client() { Email = email },
                Commentary = "maincra"
            };
            var json = JsonConvert.SerializeObject(new AddOrderParam()
            {
                Order = order,
                Computer = computer,
                Quantity = 2
            });
            var responseAdd = await client.PutAsync("api/order/submit/add", new StringContent(json, Encoding.UTF8, "application/json"));
            var resultAdd = await responseAdd.Content.ReadAsStringAsync();
            var orderAdded = JsonConvert.DeserializeObject<OrderMockResult>(resultAdd);
            
            var param = new OrderParam() { Order = orderAdded.Order, Email = email };
            var paramJson = JsonConvert.SerializeObject(param);
            await client.PostAsync("api/order/submit", new StringContent(paramJson, Encoding.UTF8, "application/json"));

            //act
            var employeeEmail = provider.GetLastName("Order","Email_Employee");
            var responseGetOrders = await provider.Client.GetAsync($"api/order/build/{employeeEmail}");
            responseGetOrders.EnsureSuccessStatusCode();

            //assert
            responseGetOrders.StatusCode.Should().Be(HttpStatusCode.OK);
            var id = provider.GetLastId("Order");
            await provider.Client.DeleteAsync($"api/order/delete/{id}");
        }

        [Fact]
        public async Task Test_Build_Order()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;
            var price = 100000;
            var use = "gaming";
            var importance = "price";
            var email = "juan@gmail";
            var response = await provider.Client.GetAsync($"api/computer?price={price}&use={use}&importance={importance}");
            var result = await response.Content.ReadAsStringAsync();
            var computers = JsonConvert.DeserializeObject<ComputerMockResult>(result);
            var computer = computers.Computers[0];
            var order = new Order()
            {
                Client = new Client() { Email = email },
                Commentary = "maincra"
            };
            var json = JsonConvert.SerializeObject(new AddOrderParam()
            {
                Order = order,
                Computer = computer,
                Quantity = 2
            });
            var responseAdd = await client.PutAsync("api/order/submit/add", new StringContent(json, Encoding.UTF8, "application/json"));
            var resultAdd = await responseAdd.Content.ReadAsStringAsync();
            var orderAdded = JsonConvert.DeserializeObject<OrderMockResult>(resultAdd);
            
            var param = new OrderParam() { Order = orderAdded.Order, Email = email };
            var paramJson = JsonConvert.SerializeObject(param);
            await client.PostAsync("api/order/submit", new StringContent(paramJson, Encoding.UTF8, "application/json"));

            //act
            var id = provider.GetLastId("Order");
            var responseSubmit = await client.PostAsync("api/order/build", new StringContent(id.ToString(), Encoding.UTF8, "application/json"));
            responseSubmit.EnsureSuccessStatusCode();

            //assert
            responseSubmit.StatusCode.Should().Be(HttpStatusCode.OK);
            id = provider.GetLastId("Order");
            await provider.Client.DeleteAsync($"api/order/delete/{id}");
        }
    }
}
