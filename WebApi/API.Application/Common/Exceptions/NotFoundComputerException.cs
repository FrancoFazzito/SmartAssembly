using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class NotFoundComputerException : Exception
    {
        public NotFoundComputerException()
        {
        }

        public NotFoundComputerException(string message) : base(message)
        {
        }

        public NotFoundComputerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundComputerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}