namespace WebApi.UseCases.Products.V1.CreateProduct
{
    using Models;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Response for Create 
    /// </summary>
    public sealed class CreateProductResponse
    {
        /// <summary>
        /// Product
        /// </summary>
        [Required]
        public ProductModel Product { get; }
        /// <summary>
        /// Response for Create Constuctor
        /// </summary>
        /// <param name="productModel"></param>
        public CreateProductResponse(ProductModel productModel)
        {
            this.Product = productModel;
        }
    }
}
