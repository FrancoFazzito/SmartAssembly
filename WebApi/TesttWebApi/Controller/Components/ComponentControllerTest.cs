using Domain.Components;
using Domain.Components.Types;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Provider;
using Xunit;

namespace TestWebApi.Controller.Components
{
    public class ComponentControllerTest
    {
        [Fact]
        public async Task Test_Get_All_Components()
        {
            //arrange
            var provider = new TestClientProvider();

            //act
            var response = await provider.Client.GetAsync("api/component");
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task Test_Create_component()
        {
            //arrange
            var provider = new TestClientProvider();
            var componentToSubmit = UniqueComponent;
            var json = JsonConvert.SerializeObject(componentToSubmit);

            // act
            var response = await provider.Client.PostAsync("api/component/create", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            var id = provider.GetLastId("component");
            await provider.Client.DeleteAsync($"api/component/delete/{id}");
        }

        public Component UniqueComponent => new Component
        {
            Id = Math.Abs(Guid.NewGuid().GetHashCode()),
            Name = Guid.NewGuid().ToString(),
            Price = 99999,
            PerfomanceLevel = 0,
            TypePart = TypePart.accesory,
            TypeFormat = TypeFormat.ATX,
            TypeMemory = TypeMemory.DDR4,
            Socket = "Socket",
            HasIntegratedVideo = true,
            Channels = 0,
            VideoLevel = 0,
            FanLevel = 0,
            NeedHighFrecuency = true,
            Capacity = 0,
            FanSize = 0,
            MaxFrecuency = 0,
            Stock = 0,
            Watts = 0,
            StockLimit = 0
        };

        [Fact]
        public async Task Test_Delete_Component()
        {
            //arrange
            var provider = new TestClientProvider();
            var json = JsonConvert.SerializeObject(UniqueComponent);
            await provider.Client.PostAsync("api/component/create", new StringContent(json, Encoding.UTF8, "application/json"));

            //act
            var id = provider.GetLastId("Component");
            var response = await provider.Client.DeleteAsync($"api/component/delete/{id}");
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
