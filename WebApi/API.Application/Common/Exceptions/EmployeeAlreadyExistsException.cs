using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    public class EmployeeAlreadyExistsException : Exception
    {
        public EmployeeAlreadyExistsException()
        {
        }

        public EmployeeAlreadyExistsException(string message) : base(message)
        {
        }

        public EmployeeAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}