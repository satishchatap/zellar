namespace Application.UseCases.DeleteProduct
{
    using Domain;
    using Services;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        private IOutputPort _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeleteProductUseCase" /> class.
        /// </summary>
        /// <param name="productRepository">Product Repository.</param>
        /// <param name="userService">User Service.</param>
        /// <param name="unitOfWork"></param>
        public DeleteProductUseCase(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new DeleteProductPresenter();
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(int id)
        {
            return this.DeleteProductInternal(id);
        }

        private async Task DeleteProductInternal(int id)
        {
            IProduct product = await this._productRepository
                .GetProduct(id)
                .ConfigureAwait(false);

            if (product is Product deleteProduct)
            {
                await this.Delete(deleteProduct)
                    .ConfigureAwait(false);

                this._outputPort.Ok(deleteProduct);
                return;
            }

            this._outputPort.NotFound();
        }

        private async Task Delete(Product deleteProduct)
        {
            await this._productRepository
                .DeleteAsyc(deleteProduct.Id)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
