using Domain.Computers;
using Domain.Orders;
using Newtonsoft.Json;

namespace TestWebApi.Controller.Orders.Submit
{
    public class ComputerMockResult
    {
        [JsonProperty("result")]
        public Computer[] Computers { get; set; }
    }

    public class OrderMockResult
    {
        [JsonProperty("result")]
        public Order Order { get; set; }
    }
}