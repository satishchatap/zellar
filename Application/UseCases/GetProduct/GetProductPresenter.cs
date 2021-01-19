namespace Application.UseCases.GetProduct
{
    using Domain;
    public sealed class GetProductPresenter : IOutputPort
    {
        public Product? Product { get; private set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;
        public void Ok(Product product)
        {
            this.Product = product;
        }
    }
}
