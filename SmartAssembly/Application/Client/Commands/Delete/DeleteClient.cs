using Application.Repositories.Interfaces.Employees.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Client.Commands.Delete
{
    public class DeleteClient
    {
        private readonly IDeleteByEmail delete;

        public DeleteClient(IDeleteByEmail delete)
        {
            this.delete = delete;
        }

        public void Delete(string email)
        {
            delete.Delete(email);
        }
    }
}
