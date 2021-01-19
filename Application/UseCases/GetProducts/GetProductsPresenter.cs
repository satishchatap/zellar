namespace Application.UseCases.GetProducts
{
    using Domain;
    using System.Collections.Generic;

    public sealed class GetProductsPresenter : IOutputPort
    {
        public IList<IProduct>? Products { get; private set; }
        public void Ok(IList<IProduct> products) => this.Products = products;
    }
}
