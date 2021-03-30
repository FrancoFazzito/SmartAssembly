using System;

namespace Application.Commands.BuildComputers
{
    public class InvalidAddException : Exception
    {
        public override string Message => $"Cannot add the component";
    }
}
