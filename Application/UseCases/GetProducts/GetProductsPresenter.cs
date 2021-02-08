namespace Application.UseCases.GetProducts
{
    using Domain;
    using System.Collections.Generic;

    public sealed class GetProductsPresenter : IOutputPort
    {
        public IList<Product>? Products { get; private set; }
        public void Ok(IList<Product> products) => this.Products = products;
    }
}
