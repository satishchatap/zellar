using Domain;

namespace Application.UseCases.DeleteProduct
{
    /// <summary>
    /// Delete Product Presenter
    /// </summary>
    public sealed class DeleteProductPresenter : IOutputPort
    {
        public Product? Product { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Product product) => this.Product = product;
    }
}
