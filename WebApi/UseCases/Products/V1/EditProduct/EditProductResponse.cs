namespace WebApi.UseCases.Products.V1.EditProduct
{
    using Models;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Response for Edit 
    /// </summary>
    public sealed class EditProductResponse
    {
        /// <summary>
        /// Product
        /// </summary>
        [Required]
        public ProductModel Product { get; }
        /// <summary>
        /// Response for Edit Constuctor
        /// </summary>
        /// <param name="productModel"></param>
        public EditProductResponse(ProductModel productModel)
        {
            this.Product = productModel;
        }
    }
}
