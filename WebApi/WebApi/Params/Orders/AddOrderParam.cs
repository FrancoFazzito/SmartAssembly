using Domain.Computers;
using Domain.Orders;

namespace WebApi.Controllers.Orders.Submit
{
    public partial class SubmitController
    {
        public class AddOrderParam
        {
            public Order Order { get; set; }

            public Computer computer { get; set; }

            public int? quantity { get; set; }
        }
    }
}