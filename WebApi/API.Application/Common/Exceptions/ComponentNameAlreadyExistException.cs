using System;
using System.Runtime.Serialization;

namespace Application.Components.Commands.Create
{
    [Serializable]
    public class ComponentNameAlreadyExistException : Exception
    {
        public ComponentNameAlreadyExistException()
        {
        }

        public ComponentNameAlreadyExistException(string message) : base(message)
        {
        }

        public ComponentNameAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ComponentNameAlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}