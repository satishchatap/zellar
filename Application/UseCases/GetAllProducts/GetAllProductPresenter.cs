using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.GetAllProducts
{
    using Domain;
    using System.Collections.Generic;

    public sealed class GetAllProductPresenter : IOutputPort
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public IList<Product>? Products { get; private set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public void Ok(IList<Product> products)
        {
            this.Products = products;
        }
    }
}
