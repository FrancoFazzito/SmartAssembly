using Application.Repositories.Interfaces.Employees.Delete;

namespace Application.Employees.Commands.Delete
{
    public class DeleteEmployee
    {
        private readonly IDeleteEmployee delete;

        public DeleteEmployee(IDeleteEmployee delete)
        {
            this.delete = delete;
        }

        public void Create(string email)
        {
            delete.Delete(email);
        }
    }
}
