using Application.Common.Exceptions;
using Application.Repositories.Interfaces;

namespace Application.TypeUse.Commands.Delete
{
    public class DeleteTypeUse
    {
        private readonly IDeleteByName delete;
        private readonly ITypeUseReadOnlyRepository read;

        public DeleteTypeUse(IDeleteByName delete, ITypeUseReadOnlyRepository read)
        {
            this.delete = delete;
            this.read = read;
        }

        public void Delete(string email)
        {
            if (read.GetByUse(email) == null)
            {
                throw new NotFoundTypeUseException();
            }
            delete.Delete(email);
        }
    }
}