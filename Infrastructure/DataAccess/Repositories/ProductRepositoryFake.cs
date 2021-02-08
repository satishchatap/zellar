using System;

namespace Infrastructure.DataAccess.Repositories
{
    using Domain;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <inheritdoc />
    public sealed class ProductRepositoryFake : IProductRepository
    {
        private readonly DataContextFake _context;

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public ProductRepositoryFake(DataContextFake context) => this._context = context;


        public async Task Add(Product product)
        {
            this._context
               .Products
               .Add(product);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
        public async Task Update(Product product)
        {
            this._context
               .Products
               .Add(product);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
        /// <inheritdoc />
        public async Task Delete(int id)
        {
            Product productOld = this._context
                .Products
                .SingleOrDefault(e => e.Id.Equals(id));

            this._context
                .Products
                .Remove(productOld);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public Task DeleteAsyc(int id)
        {
            throw new NotImplementedException();
        }


        /// <inheritdoc />
        public async Task<IProduct> GetProduct(int id)
        {
            Product product = this._context
                .Products
                .SingleOrDefault(e => e.Id.Equals(id));

            if (product == null)
            {
                return ProductNull.Instance;
            }

            return await Task.FromResult(product)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Product>> Find(ProductSearch productSearch)
        {
            List<Product> products = this._context
                .Products
                .Where(e => e.Status == (productSearch.Status.Length > 0 ? productSearch.Status : e.Status) &&
                        e.Status == (productSearch.Supplier.Length > 0 ? productSearch.Supplier : e.Supplier) &&
                        e.Rate == (productSearch.Rate ?? e.Rate) &&
                        e.ContractLength == (productSearch.ContractLength ?? e.ContractLength)
                        )
                .ToList();

            return await Task.FromResult(products)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IList<Product>> GetAllProducts()
        {
            List<Product> products = this._context
                .Products
                .ToList();

            return await Task.FromResult(products)
                .ConfigureAwait(false);
        }

        

    }
}
