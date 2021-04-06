using Domain.Orders;

namespace WebApi.Controllers
{
    public class OrderParam
    {
        public Order Order { get; set; }
        public string Email { get; set; }
    }
}