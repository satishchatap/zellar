namespace Application.UseCases.GetProduct
{
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetProductValidationUseCase : IGetProductUseCase
    {
        private readonly IGetProductUseCase _useCase;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetProductValidationUseCase" /> class.
        /// </summary>
        public GetProductValidationUseCase(IGetProductUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new GetProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(int id)
        {
            await this._useCase
                .Execute(id)
                .ConfigureAwait(false);
        }
    }
}
