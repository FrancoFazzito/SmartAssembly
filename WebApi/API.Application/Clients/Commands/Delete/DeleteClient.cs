using Application.Repositories.Interfaces;

namespace Application.Clients.Commands.Delete
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
