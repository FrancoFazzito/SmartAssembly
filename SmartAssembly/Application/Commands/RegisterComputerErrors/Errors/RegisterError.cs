using Application.Commands.RegisterComputerError.Errors.Results;
using Application.Commands.RegisterComputerError.Replacers;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Interfaces.Error;
using Domain.Components;
using Domain.Computers;
using Domain.Orders.States;

namespace Application.Commands.RegisterComputerError.Errors
{
    public class RegisterError : IRegisterError
    {
        private readonly Computer computer;
        private readonly IComponentReadOnlyRepository componenRepository;
        private readonly IFactoryCompatibility compatibilities;
        private readonly IFactoryEnough enoughs;
        private readonly IErrorWriteOnlyRepository errorRepository;

        public RegisterError(Computer computer, IComponentReadOnlyRepository componenRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs, IErrorWriteOnlyRepository errorRepository)
        {
            this.computer = computer;
            this.componenRepository = componenRepository;
            this.compatibilities = compatibilities;
            this.enoughs = enoughs;
            this.errorRepository = errorRepository;
        }

        public IErrorResult Register(Component componentWithError, string commentary, bool deleteComponentWithError)
        {
            var replace = new ComponentReplacer(computer, componentWithError, componenRepository, compatibilities, enoughs).Replace();
            if (replace == null)
            {
                return InsertErrorWithoutReplace(componentWithError, $" {commentary}", deleteComponentWithError);
            }
            return InsertErrorWithReplace(componentWithError, $" {commentary}", deleteComponentWithError, replace);
        }

        private IErrorResult InsertErrorWithReplace(Component componentWithError, string commentary, bool deleteComponentWithError, Component replace)
        {
            errorRepository.InsertWithReplace(componentWithError, replace, computer, commentary, OrderState.Mistake, deleteComponentWithError);
            return new ErrorResult(componentWithError, replace, commentary);
        }

        private IErrorResult InsertErrorWithoutReplace(Component componentWithError, string commentary, bool deleteComponentWithError)
        {
            errorRepository.InsertWithouthReplace(componentWithError, computer, commentary, OrderState.Mistake, deleteComponentWithError);
            return new ErrorWithoutReplaceResult(componentWithError, commentary);
        }
    }
}
