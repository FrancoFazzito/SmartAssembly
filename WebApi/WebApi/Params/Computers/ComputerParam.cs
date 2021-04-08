using Domain.Computers;

namespace WebApi.Controllers
{
    public class ComputerParam
    {
        public int Quantity { get; set; }
        public Domain.Computers.Computer Computer { get; set; }
    }
}