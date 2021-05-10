using Domain.Clients;
using Domain.Orders;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Provider;
using WebApi.Controllers;
using WebApi.Controllers.Orders.Submit;
using Xunit;

namespace TestWebApi.Controller.Orders.Submit
{
    public class OrderSubmitControllerTest
    {
        [Fact]
        public async Task Test_Add_Computers_To_Order()
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
                quantity = 2
            });

            //act
            var responseAdd = await client.PutAsync("api/order/submit/add", new StringContent(json, Encoding.UTF8, "application/json"));
            responseAdd.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Submit_Order()
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
                quantity = 2
            });
            var responseAdd = await client.PutAsync("api/order/submit/add", new StringContent(json, Encoding.UTF8, "application/json"));
            var resultAdd = await responseAdd.Content.ReadAsStringAsync();
            var orderAdded = JsonConvert.DeserializeObject<OrderMockResult>(resultAdd);
            var param = new OrderParam() { Order = orderAdded.Order, Email = "juan@gmail" };
            var paramJson = JsonConvert.SerializeObject(param);

            //act
            var responseSubmit = await client.PostAsync("api/order/submit", new StringContent(paramJson, Encoding.UTF8, "application/json"));
            responseSubmit.EnsureSuccessStatusCode();

            //assert
            responseSubmit.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
