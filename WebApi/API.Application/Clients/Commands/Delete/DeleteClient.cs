﻿using Application.Common.Exceptions;
using Application.Repositories.Interfaces;

namespace Application.Clients.Commands.Delete
{
    public class DeleteClient
    {
        private readonly IDeleteByName delete;
        private readonly IClientReadOnlyRepository read;

        public DeleteClient(IDeleteByName delete, IClientReadOnlyRepository readClient)
        {
            this.delete = delete;
            read = readClient;
        }

        public void Delete(string email)
        {
            if (read.GetByEmail(email) == null)
            {
                throw new NotFoundClientException();
            }
            delete.Delete(email);
        }
    }
}