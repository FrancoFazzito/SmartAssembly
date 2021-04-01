using System;
using System.Runtime.Serialization;

namespace Application.Orders.Commands.Create
{
    [Serializable]
    public class AddStockException : Exception
    {
        private readonly int quantity;

        public AddStockException()
        {
        }

        public AddStockException(int quantity)
        {
            this.quantity = quantity;
        }

        public AddStockException(string message) : base(message)
        {
        }

        public AddStockException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Cannot add {quantity} computers to this order";
    }
}