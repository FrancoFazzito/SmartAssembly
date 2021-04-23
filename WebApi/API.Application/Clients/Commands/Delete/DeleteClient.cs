using Application.Repositories.Interfaces;

namespace Application.Clients.Commands.Delete
{
    public class DeleteClient
    {
        private readonly IDeleteByEmail delete;
        private readonly IClientReadOnlyRepository read;

        public DeleteClient(IDeleteByEmail delete, IClientReadOnlyRepository readClient)
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