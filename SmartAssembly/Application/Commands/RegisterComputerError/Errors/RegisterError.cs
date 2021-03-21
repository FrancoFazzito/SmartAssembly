using Application.Commands.RegisterComputerError.Errors.Results;
using Application.Commands.RegisterComputerError.Replacers;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
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
        //IwriteError

        public RegisterError(Computer computer, IComponentReadOnlyRepository componenRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs)
        {
            this.computer = computer;
            this.componenRepository = componenRepository;
            this.compatibilities = compatibilities;
            this.enoughs = enoughs;
        }

        public IErrorResult Register(Component component, string commentary)
        {
            var componentReplacer = new ComponentReplacer(computer, component, componenRepository, compatibilities, enoughs);
            var replaceComponent = componentReplacer.Replace();
            //register in BD -> update commentary de la orden y add al error
            if (replaceComponent == null)
            {
                return new ErrorWithoutReplaceResult(component, computer.Id, commentary);
            }

            computer.Replace(component, replaceComponent);
            return new ErrorResult(component, replaceComponent, computer.Id, commentary);
        }
    }
}
