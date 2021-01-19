namespace Application.UseCases.CreateProduct
{
    using Domain;
    using Services;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductFactory _productFactory;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public CreateProductUseCase(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            IProductFactory productFactory)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._productFactory = productFactory;
            this._outputPort = new CreateProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge) =>
            this.CreateProduct(name, status, supplier, rate, contractLength, dailyStandingCharge);

        private async Task CreateProduct(string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge)
        {
            Product product = this._productFactory
                .NewProduct( name,  status,  supplier,  rate,  contractLength,  dailyStandingCharge);

            await this.Product(product)
                .ConfigureAwait(false);

            this._outputPort?.Ok(product);
        }

        private async Task Product(Product product)
        {
            await this._productRepository
                .Add(product)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
