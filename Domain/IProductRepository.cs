using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IProductRepository
    {
        /// <summary>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<IProduct> GetProduct(int productId);

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        Task<IList<Product>> GetAllProducts();

        /// <summary>
        ///     Deletes the Product.
        /// </summary>
        /// <param name="productId">Product Id.</param>
        /// <returns>Task.</returns>
        Task DeleteAsyc(int productId);

        /// <summary>
        ///     create the Product.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <returns>Task.</returns>
        Task Add(Product product);

        /// <summary>
        ///     update the Product.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <returns>Task.</returns>
        Task Update(Product product);

        /// <summary>
        ///     Finds Products.
        /// </summary>
        /// <param name="productSearch">Product Search.</param>
        /// <returns>list of products</returns>     
        Task<IList<IProduct>> Find(IProductSearch productSearch);
    }
}
