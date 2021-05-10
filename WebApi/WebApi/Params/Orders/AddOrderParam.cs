using Domain.Computers;
using Domain.Orders;

namespace WebApi.Controllers.Orders.Submit
{
    public class AddOrderParam
    {
        public Order Order { get; set; }

        public Computer Computer { get; set; }

        public int? quantity { get; set; }
    }
}