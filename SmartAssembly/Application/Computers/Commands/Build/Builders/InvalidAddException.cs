using System;

namespace Application.Computers.Commands.Build.Builders
{
    public class InvalidAddException : Exception
    {
        public override string Message => $"Cannot add the component";
    }
}
