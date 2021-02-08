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
        public Task Execute(int id, string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge, int renewable) =>
            this.EditProduct(id, name, status, supplier, rate, contractLength, dailyStandingCharge, renewable);

        private async Task EditProduct(int id, string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge, int renewable)
        {
            var productExisting =await this._productRepository.GetProduct(id)
                .ConfigureAwait(false);

            productExisting.Name = name; 
            productExisting.Status = status;
            productExisting.Supplier = supplier;
            productExisting.Rate = rate;
            productExisting.ContractLength = contractLength;
            productExisting.DailyStandingCharge = dailyStandingCharge;
            productExisting.Renewable = renewable;

            await this.Product((Product)productExisting)
                .ConfigureAwait(false);

            this._outputPort?.Ok((Product)productExisting);
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
