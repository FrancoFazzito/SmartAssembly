using Application.Commands.RegisterComputerError.Errors.Results;
using Application.Commands.RegisterComputerError.Replacers;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Interfaces.Error;
using Domain.Components;
using Domain.Computers;

namespace Application.Commands.RegisterComputerError.Errors
{
    public class RegisterError : IRegisterError
    {
        private readonly Computer computer;
        private readonly IComponentReadOnlyRepository componenRepository;
        private readonly IFactoryCompatibility compatibilities;
        private readonly IFactoryEnough enoughs;
        private readonly IErrorWriteOnlyRepository errorRepository;

        //IwriteError

        public RegisterError(Computer computer, IComponentReadOnlyRepository componenRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs, IErrorWriteOnlyRepository errorRepository)
        {
            this.computer = computer;
            this.componenRepository = componenRepository;
            this.compatibilities = compatibilities;
            this.enoughs = enoughs;
            this.errorRepository = errorRepository;
        }

        public IErrorResult Register(Component componentWithError, string commentary)
        {
            commentary = $" {commentary}";
            var componentReplacer = new ComponentReplacer(computer, componentWithError, componenRepository, compatibilities, enoughs);
            var replaceComponent = componentReplacer.Replace();
            errorRepository.Insert(componentWithError, replaceComponent, computer.Id, commentary);
            if (replaceComponent == null)
            {
                return new ErrorWithoutReplaceResult(componentWithError, computer.Id, commentary);
            }
            computer.Replace(componentWithError, replaceComponent);
            return new ErrorResult(componentWithError, replaceComponent, computer.Id, commentary);
        }
    }
}
