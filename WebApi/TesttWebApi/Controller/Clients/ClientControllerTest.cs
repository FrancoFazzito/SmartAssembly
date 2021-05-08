using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Provider;
using Xunit;

namespace TestWebApi.Controller.Clients
{
    public class ClientControllerTest
    {
        [Fact]
        public async Task Test_Get_All_Clients()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;

            //act
            var response = await client.GetAsync("api/client");
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Create_Client()
        {
            //arrange
            var provider = new TestClientProvider();
            var clientToSubmit = new Domain.Clients.Client() { Name = "franco", Adress = "calle falsa 123", Email = $"{Guid.NewGuid()}@gmail", Number = "12345" };
            var json = JsonConvert.SerializeObject(clientToSubmit);

            // act
            var response = await provider.Client.PostAsync("api/client/create", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/client/delete")
            {
                Content = new StringContent(JsonConvert.SerializeObject(clientToSubmit.Email), Encoding.UTF8, "application/json")
            };
            await provider.Client.SendAsync(request);
        }

        [Fact]
        public async Task Test_Delete_client()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;
            var email = $"{Guid.NewGuid()}@gmail";
            var json = JsonConvert.SerializeObject(new Domain.Clients.Client() { Name = "franco", Adress = "calle falsa 123", Email = email, Number = "12345" });
            await client.PostAsync("api/client/create", new StringContent(json, Encoding.UTF8, "application/json"));

            //act
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/client/delete")
            {
                Content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
