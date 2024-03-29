﻿using Domain.Computers;
using System.Collections.Generic;

namespace Application.Repositories.Interfaces
{
    public interface IComputerReadOnlyRepository
    {
        IEnumerable<Computer> All { get; }

        IEnumerable<Computer> GetByOrder(int id);

        Computer GetById(int? id);
    }
}