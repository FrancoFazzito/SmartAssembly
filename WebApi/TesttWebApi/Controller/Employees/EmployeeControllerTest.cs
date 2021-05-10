using Domain.Employees;
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

namespace TestWebApi.Controller
{
    public class EmployeeControllerTest
    {
        [Fact]
        public async Task Test_Get_All_Employees()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;

            //act
            var response = await client.GetAsync("api/employee");
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Test_Create_Employee()
        {
            //arrange
            var provider = new TestClientProvider();
            var email = $"{Guid.NewGuid()}@gmail";
            var employeeToSubmit = new Employee() { Email = email };
            var json = JsonConvert.SerializeObject(employeeToSubmit);

            // act
            var response = await provider.Client.PostAsync("api/employee/create", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/employee/delete")
            {
                Content = new StringContent(JsonConvert.SerializeObject(employeeToSubmit.Email), Encoding.UTF8, "application/json")
            };
            await provider.Client.SendAsync(request);
        }


        [Fact]
        public async Task Test_Delete_Employee()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;
            var email = $"{Guid.NewGuid()}@gmail";
            var json = JsonConvert.SerializeObject(new Domain.Clients.Client() { Name = "franco", Adress = "calle falsa 123", Email = email, Number = "12345" });
            await client.PostAsync("api/employee/create", new StringContent(json, Encoding.UTF8, "application/json"));

            //act
            var request = new HttpRequestMessage(HttpMethod.Delete, "api/employee/delete")
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
