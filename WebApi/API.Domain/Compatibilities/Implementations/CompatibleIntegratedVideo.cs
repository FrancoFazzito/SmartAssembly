﻿using Domain.Compatibilities.Interfaces;
using Domain.Components;

namespace Domain.Compatibilities.Implementations
{
    public class CompatibleIntegratedVideo : ICompatible
    {
        public bool IsCompatibleWith(Component component, Component componentToCompare)
        {
            return component.HasIntegratedVideo && componentToCompare.HasIntegratedVideo;
        }
    }
}