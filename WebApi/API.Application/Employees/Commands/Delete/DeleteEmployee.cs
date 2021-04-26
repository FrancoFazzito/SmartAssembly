using Application.Repositories.Interfaces;

namespace Application.Employees.Commands.Delete
{
    public class DeleteEmployee
    {
        private readonly IDeleteByName delete;
        private readonly IEmployeeReadOnlyRepository read;

        public DeleteEmployee(IDeleteByName delete, IEmployeeReadOnlyRepository read)
        {
            this.delete = delete;
            this.read = read;
        }

        public void Delete(string email)
        {
            if (read.GetByName(email) == null)
            {
                throw new NotFoundEmployeeException();
            }
            delete.Delete(email);
        }
    }
}