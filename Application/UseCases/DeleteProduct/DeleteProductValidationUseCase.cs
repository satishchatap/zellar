namespace Application.UseCases.DeleteProduct
{
    using System;
    using System.Threading.Tasks;
    using Services;

    /// <inheritdoc />
    public sealed class DeleteProductValidationUseCase : IDeleteProductUseCase
    {
        private readonly IDeleteProductUseCase _useCase;
        private readonly Validation _validation;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeleteProductValidationUseCase" /> class.
        /// </summary>
        public DeleteProductValidationUseCase(IDeleteProductUseCase useCase, Validation validation)
        {
            this._useCase = useCase;
            this._validation = validation;
            this._outputPort = new DeleteProductPresenter();
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
            if (id == 0)
            {
                this._validation
                    .Add(nameof(id), "ProductId is required.");
            }

            if (!this._validation
                .IsValid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(id)
                .ConfigureAwait(false);
        }
    }
}
