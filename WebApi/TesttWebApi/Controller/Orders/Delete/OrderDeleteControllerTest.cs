using Domain.Clients;
using Domain.Orders;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Controller.Orders.Submit;
using TestWebApi.Provider;
using WebApi.Controllers;
using WebApi.Controllers.Orders.Submit;
using Xunit;

namespace TestWebApi.Controller.Orders.Delete
{
    public class OrderDeleteControllerTest
    {
        [Fact]
        public async Task Test_Delete_Order()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;
            var price = 100000;
            var use = "gaming";
            var importance = "price";
            var response = await provider.Client.GetAsync($"api/computer?price={price}&use={use}&importance={importance}");
            var result = await response.Content.ReadAsStringAsync();
            var computers = JsonConvert.DeserializeObject<ComputerMockResult>(result);
            var computer = computers.Computers[0];
            var order = new Order()
            {
                Client = new Client() { Email = "juan@gmail" },
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
            var param = new OrderParam() { Order = orderAdded.Order, Email = "juan@gmail" };
            var paramJson = JsonConvert.SerializeObject(param);
            await client.PostAsync("api/order/submit", new StringContent(paramJson, Encoding.UTF8, "application/json"));
            var id = provider.GetLastId("Order");

            //act
            var responseDelete = await provider.Client.DeleteAsync($"api/order/delete/{id}");

            //assert
            responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
