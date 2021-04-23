using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class InvalidAddException : Exception
    {
        public InvalidAddException()
        {
        }

        public InvalidAddException(string message) : base(message)
        {
        }

        public InvalidAddException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAddException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => $"Cannot add the component";
    }
}