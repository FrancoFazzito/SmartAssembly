using System;
using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    [Serializable]
    internal class SpecificationAlreadyExistsException : Exception
    {
        public SpecificationAlreadyExistsException()
        {
        }

        public SpecificationAlreadyExistsException(string message) : base(message)
        {
        }

        public SpecificationAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SpecificationAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}