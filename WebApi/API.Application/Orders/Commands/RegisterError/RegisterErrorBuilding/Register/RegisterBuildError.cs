using Application.Common.Exceptions;
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
        private readonly IComputerReadOnlyRepository computerRepository;

        public RegisterBuildError(IComponentReadOnlyRepository componenRepository, IFactoryCompatibility compatibilities, IFactoryEnough enoughs, IErrorBuildingWriteOnlyRepository errorRepository, IErrorBuildingWithReplaceWriteOnlyRepository errorReplaceRepository, IComputerReadOnlyRepository computerRepository)
        {
            this.componenRepository = componenRepository;
            this.compatibilities = compatibilities;
            this.enoughs = enoughs;
            this.errorRepository = errorRepository;
            this.errorReplaceRepository = errorReplaceRepository;
            this.computerRepository = computerRepository;
        }

        public IErrorResult Register(int? idComputer, int? idComponentWithError, string commentary, bool deleteComponentWithError)
        {
            var computer = GetComputer(idComputer);
            var component = GetComponent(idComponentWithError);
            var replace = new ComponentReplacer(computer, component, componenRepository, compatibilities, enoughs).Replace();
            commentary = $" {commentary}";
            return replace == null ? Insert(computer, component, commentary, deleteComponentWithError)
                                   : Insert(computer, component, replace, commentary, deleteComponentWithError);
        }

        private Component GetComponent(int? idComponentWithError)
        {
            return componenRepository.GetById(idComponentWithError) ?? throw new NotFoundComponentException();
        }

        private Computer GetComputer(int? idComputer)
        {
            return computerRepository.GetById(idComputer) ?? throw new NotFoundComputerException();
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