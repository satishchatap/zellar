

namespace Application.UseCases.GetProduct
{
    using Domain;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetProductUseCase : IGetProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetProductUseCase" /> class.
        /// </summary>
        /// <param name="productRepository">Product Repository.</param>
        public GetProductUseCase(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._outputPort = new GetProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(int id) =>
            this.GetProductInternal(id);

        private async Task GetProductInternal(int id)
        {
            IProduct product = await this._productRepository
                .GetProduct(id)
                .ConfigureAwait(false);

            if (product is Product getProduct)
            {
                this._outputPort.Ok(getProduct);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}
