

namespace Application.UseCases.CreateProduct
{
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CreateProductValidationUseCase : ICreateProductUseCase
    {
        private readonly ICreateProductUseCase _useCase;
        private IOutputPort _outputPort;

        public CreateProductValidationUseCase(ICreateProductUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new CreateProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge, int renewable)
        {          

            await this._useCase
                .Execute(name, status, supplier, rate, contractLength, dailyStandingCharge, renewable)
                .ConfigureAwait(false);
        }
    }
}
