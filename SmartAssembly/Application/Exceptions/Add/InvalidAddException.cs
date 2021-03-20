using System;

namespace Application.Exceptions.Add
{
    public class InvalidAddException : Exception
    {
        public static void Throw()
        {
            throw new InvalidAddException();
        }
    }
}
