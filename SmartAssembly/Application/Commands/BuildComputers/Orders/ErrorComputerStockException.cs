using System;

namespace Application.Commands.BuildComputers.Orders
{
    public class ErrorComputerStockException : Exception
    {
        private readonly int quantity;

        public ErrorComputerStockException(int quantity)
        {
            this.quantity = quantity;
        }

        public override string Message => $"Cannot add {quantity} computers to this order";
    }
}