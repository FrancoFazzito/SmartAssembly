using Application.Common.Factories.Compatibilities;
using Application.Common.Factories.Enoughs;
using Application.Repositories.Interfaces;
using Domain.Components;
using Domain.Computers;
using Domain.Orders.States;

namespace Application.Orders.Commands.RegisterError
{
    public class RegisterBuildError : IRegisterBuildError
    {
        private readonly IComponentReadOnlyRepository componenRepository;
        private readonly IFactoryCompatibility compatibilities;
        private readonly IFactoryEnough enoughs;
        private readonly IErrorBuildingWriteOnlyRepository errorRepository;
        private readonly IErrorBuildingWithReplaceWriteOnlyRepository errorReplaceRepository;

        public RegisterBuildError(IComponentReadOnlyRepository componenRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs, IErrorBuildingWriteOnlyRepository errorRepository, IErrorBuildingWithReplaceWriteOnlyRepository errorReplaceRepository)
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