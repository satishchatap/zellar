namespace WebApi.UseCases.Products.V1.GetProduct
{
    using Domain;
    using System.ComponentModel.DataAnnotations;
    using WebApi.Models;

    /// <summary>
    ///     Get Product Response.
    /// </summary>
    public sealed class GetProductResponse
    {
        /// <summary>
        ///     The Get Product Response constructor.
        /// </summary>
        public GetProductResponse(Product product) => this.Product = new ProductModel(product);

        /// <summary>
        ///     Gets product ID.
        /// </summary>
        [Required]
        public ProductModel Product { get; }
    }
}
