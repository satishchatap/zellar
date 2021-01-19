using Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Products.V1.DeleteProduct
{
    /// <summary>
    /// Delete Product Response
    /// </summary>
    public class DeleteProductResponse
    {
        /// <summary>
        ///     Delete Product Response constructor.
        /// </summary>
        public DeleteProductResponse(Product product) => this.Id = product.Id;

        /// <summary>
        ///     Gets product ID.
        /// </summary>
        [Required]
        public int Id { get; }
    }
}
