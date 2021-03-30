﻿using Domain.Computers;

namespace Application.Computers.Commands.Build.Specification
{
    public interface ISpecification
    {
        TypeUse Use { get; }
        int Cpu { get; }
        int Mother { get; }
        int Fan { get; }
        int Ram { get; }
        int Gpu { get; }
        int Hdd { get; }
        int Ssd { get; }
    }
}