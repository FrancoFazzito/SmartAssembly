﻿using Domain.Compatibilities.Interfaces;
using Domain.Compatibility.Enums;

namespace Application.Common.Factories.Compatibilities
{
    public interface IFactoryCompatibility
    {
        ICompatible this[Compatibility compatibility] { get; }
    }
}