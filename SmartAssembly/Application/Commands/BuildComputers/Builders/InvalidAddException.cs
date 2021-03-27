using System;

namespace Application.Commands.BuildComputers.Builders
{
    public class InvalidAddException : Exception
    {
        private readonly string name;

        public InvalidAddException(string name)
        {
            this.name = name;
        }

        public override string Message => $"Cannot add the component: {name}";

    }
}
