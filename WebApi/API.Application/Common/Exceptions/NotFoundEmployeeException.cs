using System;
using System.Runtime.Serialization;

namespace Application.Employees.Commands.Delete
{
    [Serializable]
    public class NotFoundEmployeeException : Exception
    {
        public NotFoundEmployeeException()
        {
        }

        public NotFoundEmployeeException(string message) : base(message)
        {
        }

        public NotFoundEmployeeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundEmployeeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}