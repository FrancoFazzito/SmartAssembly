using System;

namespace Application.Commands.BuildComputers
{
    public class NotAvailableComputersException : Exception
    {
        public override string Message => "cannot find computers to this budget or/and use";
    }
}