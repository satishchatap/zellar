using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IProductRepository
    {
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IProduct> GetProduct(int id);

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        Task<IList<Product>> GetAllProducts();


        /// <summary>
        ///     Deletes the Product.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Task.</returns>
        Task DeleteAsyc(int id);

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
        Task<IList<Product>> Find(ProductSearch productSearch);
    }
}
