using System;

namespace Application.Orders.Commands.Create
{
    public class AddStockException : Exception
    {
        private readonly int quantity;

        public AddStockException(int quantity)
        {
            this.quantity = quantity;
        }

        public override string Message => $"Cannot add {quantity} computers to this order";
    }
}