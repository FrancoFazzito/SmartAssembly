using Newtonsoft.Json;

namespace TestWebApi.Controller.Cost
{
    public class TupleMockResult
    {
        [JsonProperty("result")]
        public TupleMock[] Tuples { get; set; }
    }
}
