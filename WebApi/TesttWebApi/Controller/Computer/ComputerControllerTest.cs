using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Provider;
using Xunit;

namespace TestWebApi.Controller.Computer
{
    public class ComputerControllerTest
    {

        [Fact]
        public async Task Test_Get_All_Computers()
        {
            //arrange
            var provider = new TestClientProvider();
            var price = 100000;
            var use = "gaming";
            var importance = "price";

            //act
            var response = await provider.Client.GetAsync($"api/computer?price={price}&use={use}&importance={importance}");
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        //[Fact]
        //public async Task Test_Delete_Computer()
        //{
        //    //arrange
        //    var provider = new TestClientProvider();

        //    //act
        //    var id = provider.GetLastId("Computer");
        //    var response = await provider.Client.DeleteAsync($"api/computer/delete/{id}");
        //    response.EnsureSuccessStatusCode();

        //    //assert
        //    response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        //}
    }
}
