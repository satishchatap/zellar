namespace Application.UseCases.GetProducts
{
    using Domain;
    using Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetProductsUseCase : IGetProductsUseCase
    {
        private readonly IProductRepository _productRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetProductsUseCase" /> class.
        /// </summary>
        /// <param name="productRepository">Customer Repository.</param>
        public GetProductsUseCase(
            IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._outputPort = new GetProductsPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(IProductSearch productSearch)
        {
            return this.GetProducts(productSearch);
        }

        private async Task GetProducts(IProductSearch productSearch)
        {
            IList<IProduct>? products = await this._productRepository
                .Find(productSearch)
                .ConfigureAwait(false);

            this._outputPort.Ok(products);
        }
    }
}
