namespace Infrastructure.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    public sealed class ProductRepository :IProductRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public ProductRepository(DataContext context) => this._context = context ??
                                                                          throw new ArgumentNullException(
                                                                              nameof(context));

       
        /// <inheritdoc />
        public async Task DeleteAsyc(int Id)
        {

            await this._context
                .Database
                .ExecuteSqlRawAsync("DELETE FROM [Product] WHERE Id=@p0", Id)
                .ConfigureAwait(false);
        }

        public void Delete(int productId)
        {
            this._context.Products.Remove(this._context.Products.First(a => a.Id == productId));
        }
        /// <inheritdoc />
        public async Task<IProduct> GetProduct(int Id)
        {
            Product Product = await this._context
                .Products
                .Where(e => e.Id == Id)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (Product is Product findProduct)
            {             

                return Product;
            }

            return ProductNull.Instance;
        }

        public async Task<IList<IProduct>> Find(IProductSearch productSearch)
        {
            IList<Product> Products = await this._context
                .Products
                .Where(e => 
                        e.Status == (productSearch.Status.Length>0 ? productSearch.Status: e.Status) &&
                        e.Status == (productSearch.Supplier.Length > 0 ? productSearch.Supplier : e.Supplier) &&
                        e.Rate == (productSearch.Rate ?? e.Rate) &&
                        e.ContractLength == (productSearch.ContractLength ?? e.ContractLength)
                        )
                .ToListAsync()
                .ConfigureAwait(false);

            return (IList<IProduct>)Products;
        }
        public async Task<IList<Product>> GetAllProducts()
        {
            IList<Product> Products = await this._context
                .Products
                .ToListAsync()
                .ConfigureAwait(false);

            return Products;
        }

       

        public async Task Add(Product product)
        {
            await this._context
                .Products
                .AddAsync(product)
                .ConfigureAwait(false);
        }
        public async Task Update(Product product)
        {
            await this._context
                .Products
                .AddAsync(product)
                .ConfigureAwait(false);
        }
    }
}