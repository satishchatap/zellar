namespace WebApi.UseCases.Products.V1.GetProducts
{
    using Domain;
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     Get Products Response.
    /// </summary>
    public sealed class GetProductsResponse
    {
        /// <summary>
        ///     The Get Products Response constructor.
        /// </summary>
        public GetProductsResponse(IEnumerable<IProduct> products)
        {
            foreach (Product product in products)
            {
                ProductModel productModel = new ProductModel(product);
                this.Products.Add(productModel);
            }
        }

        /// <summary>
        ///     Products
        /// </summary>
        [Required]
        public List<ProductModel> Products { get; } = new List<ProductModel>();
    }
}
