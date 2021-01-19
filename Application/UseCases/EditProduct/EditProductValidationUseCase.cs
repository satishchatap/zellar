

namespace Application.UseCases.EditProduct
{
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class EditProductValidationUseCase : IEditProductUseCase
    {
        private readonly IEditProductUseCase _useCase;
        private IOutputPort _outputPort;

        public EditProductValidationUseCase(IEditProductUseCase useCase)
        {
            this._useCase = useCase;
            this._outputPort = new EditProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        /// <inheritdoc />
        public async Task Execute(int id, string name,string status,string supplier,float rate,int contractLength,float dailyStandingCharge)
        {          

            await this._useCase
                .Execute(id, name, status, supplier, rate, contractLength, dailyStandingCharge)
                .ConfigureAwait(false);
        }
    }
}
