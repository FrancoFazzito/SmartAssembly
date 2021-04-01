using Application.Repositories.Interfaces.Employees.Delete;

namespace Application.Employees.Commands.Delete
{
    public class DeleteEmployee
    {
        private readonly IDeleteByEmail delete;

        public DeleteEmployee(IDeleteByEmail delete)
        {
            this.delete = delete;
        }

        public void Create(string email)
        {
            delete.Delete(email);
        }
    }
}
