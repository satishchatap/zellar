namespace Application.UseCases.EditProduct
{
   
     using Domain;

    /// <summary>
    /// </summary>
    public sealed class EditProductPresenter : IOutputPort
    {
        public Product? Product { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Product product) => this.Product = product;
    }
}
