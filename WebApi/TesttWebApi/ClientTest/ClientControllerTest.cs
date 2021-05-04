using Domain.Clients;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Provider;
using Xunit;

namespace TestWebApi.ClientTest
{
    public class ClientControllerTest
    {
        [Fact]
        public async Task Test_Get_All_Clients()
        {
           var client = new TestClientProvider().Client;
           var response = await client.GetAsync("api/client");
           response.EnsureSuccessStatusCode();
           response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Create_Client()
        {
           var client = new TestClientProvider().Client;
           var json = JsonConvert.SerializeObject(new Client() { Name = "franco", Adress = "calle falsa 123", Email = "email_inventado_123_@gmail", Number = "12345" }); 
           var response = await client.PostAsync("api/client/create", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
           response.EnsureSuccessStatusCode();
           response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        //delete
    }
}
