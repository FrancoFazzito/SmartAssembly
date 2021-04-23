using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class ComponentAlreadyExistException : Exception
    {
        public ComponentAlreadyExistException()
        {
        }

        public ComponentAlreadyExistException(string message) : base(message)
        {
        }

        public ComponentAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ComponentAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}