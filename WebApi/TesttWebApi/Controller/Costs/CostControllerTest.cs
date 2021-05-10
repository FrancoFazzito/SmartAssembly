using FluentAssertions;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Provider;
using WebApi.Controllers.Costs;
using Xunit;

namespace TestWebApi.Controller.Cost
{
    public class CostControllerTest
    {
        [Fact]
        public async Task Test_Get_All_Costs()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;

            //act
            var response = await client.GetAsync("api/cost");
            response.EnsureSuccessStatusCode();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Update_cost()
        {
            //arrange
            var provider = new TestClientProvider();
            var client = provider.Client;
            var getResponse = await client.GetAsync("api/cost");
            var result = await getResponse.Content.ReadAsStringAsync();
            var costs = JsonConvert.DeserializeObject<TupleMockResult>(result);
            var costToUpdate = costs.Tuples.First();

            //act
            var newValue = costToUpdate.item2 * 2;
            var json = JsonConvert.SerializeObject(new CostParam() { Name = costToUpdate.item1, Value = newValue });
            var response = await provider.Client.PutAsync("api/cost/update", new StringContent(json, Encoding.UTF8, "application/json"));

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            json = JsonConvert.SerializeObject(new CostParam() { Name = costToUpdate.item1, Value = costToUpdate.item2 });
            await provider.Client.PutAsync("api/cost/update", new StringContent(json, Encoding.UTF8, "application/json"));
        }
    }
}
