﻿using Application.Computers.Commands.Build;
using Application.Repositories.Interfaces;
using Domain.Computers;
using Infra.Connections;
using Infra.Repositories.Convert;
using Infra.Repositories.Implementations.Abstracts;
using System.Data;
using System.Linq;

namespace Infra.Repositories.Implementations.TypeUses
{
    public class TypeUseReadOnlyRepository : AbstractReadOnlyRepository<ISpecification>, ITypeUseReadOnlyRepository
    {
        public TypeUseReadOnlyRepository(IConnection connection) : base(connection)
        {
        }

        protected override string QuerySelectAll => "SELECT * FROM TypeUse";

        public ISpecification GetByUse(TypeUse use)
        {
            return All.FirstOrDefault(c => c.TypeUse == use);
        }

        protected override ISpecification NewRecord(IDataReader reader)
        {
            return new Specification(ConvertReader<int>.WithName(reader, "Cpu"),
                                     ConvertReader<int>.WithName(reader, "Fan"),
                                     ConvertReader<int>.WithName(reader, "Ram"),
                                     ConvertReader<int>.WithName(reader, "Gpu"),
                                     ConvertReader<int>.WithName(reader, "HDD"),
                                     ConvertReader<int>.WithName(reader, "SSD"),
                                     ConvertReader<TypeUse>.EnumWithName(reader, "Name"));
        }
    }
}