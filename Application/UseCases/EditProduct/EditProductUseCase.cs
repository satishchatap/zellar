namespace Application.UseCases.EditProduct
{
    using Domain;
    using Services;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class EditProductUseCase : IEditProductUseCase
    {
       
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public EditProductUseCase(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new EditProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(int id, string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge) =>
            this.EditProduct(id, name, status, supplier, rate, contractLength, dailyStandingCharge);

        private async Task EditProduct(int id, string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge)
        {
            var productExisting =await this._productRepository.GetProduct(id)
                .ConfigureAwait(false);

            var product = new Product(productExisting.Id, name, status, supplier, rate, contractLength, dailyStandingCharge);

            await this.Product(product)
                .ConfigureAwait(false);

            this._outputPort?.Ok(product);
        }

        private async Task Product(Product product)
        {
            await this._productRepository
                .Update(product)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
