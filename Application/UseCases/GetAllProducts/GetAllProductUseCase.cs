using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetAllProducts
{
    using Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class GetAllProductUseCase : IGetAllProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetAllProductUseCase" /> class.
        /// </summary>
        /// <param name="productRepository">Customer Repository.</param>
        public GetAllProductUseCase(
            IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._outputPort = new GetAllProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute()
        {
            return this.GetAllProduct();
        }

        private async Task GetAllProduct()
        {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
            IList<Product>? products = await this._productRepository
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
                .GetAllProducts()
                .ConfigureAwait(false);

            this._outputPort.Ok(products);
        }
    }
}