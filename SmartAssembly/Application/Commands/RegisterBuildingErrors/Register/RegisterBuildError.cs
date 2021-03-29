using Application.Commands.RegisterBuildError.Errors.Results;
using Application.Commands.RegisterBuildError.Replacers;
using Application.Factories.Compatibilities;
using Application.Factories.Enoughs;
using Application.Repositories.Components.Interfaces;
using Application.Repositories.Interfaces.Error;
using Domain.Components;
using Domain.Computers;
using Domain.Orders.States;

namespace Application.Commands.RegisterBuildError.Errors
{
    public class RegisterBuildError : IRegisterBuildError
    {
        private readonly IComponentReadOnlyRepository componenRepository;
        private readonly IFactoryCompatibility compatibilities;
        private readonly IFactoryEnough enoughs;
        private readonly IErrorWriteOnlyRepository errorRepository;
        private readonly IErrorReplaceWriteOnlyRepository errorReplaceRepository;

        public RegisterBuildError(IComponentReadOnlyRepository componenRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs, IErrorWriteOnlyRepository errorRepository, IErrorReplaceWriteOnlyRepository errorReplaceRepository)
        {
            this.componenRepository = componenRepository;
            this.compatibilities = compatibilities;
            this.enoughs = enoughs;
            this.errorRepository = errorRepository;
            this.errorReplaceRepository = errorReplaceRepository;
        }

        public IErrorResult Register(Computer computer, Component componentWithError, string commentary, bool deleteComponentWithError)
        {
            var replace = new ComponentReplacer(computer, componentWithError, componenRepository, compatibilities, enoughs).Replace();
            commentary = $" {commentary}";
            return replace == null ? Insert(computer, componentWithError, commentary, deleteComponentWithError)
                                   : Insert(computer, componentWithError, replace, commentary, deleteComponentWithError);
        }

        private IErrorResult Insert(Computer computer, Component componentWithError, Component replace, string commentary, bool deleteComponentWithError)
        {
            errorReplaceRepository.Insert(componentWithError, replace, computer, commentary, OrderState.Error, deleteComponentWithError);
            return new ErrorResult(componentWithError, replace, commentary);
        }

        private IErrorResult Insert(Computer computer, Component componentWithError, string commentary, bool deleteComponentWithError)
        {
            errorRepository.Insert(componentWithError, computer, commentary, OrderState.Error, deleteComponentWithError);
            return new ErrorWithouthReplaceResult(componentWithError, commentary);
        }
    }
}
