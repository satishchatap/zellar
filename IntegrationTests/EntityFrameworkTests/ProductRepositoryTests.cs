

namespace IntegrationTests.EntityFrameworkTests
{
    using Domain;
    using Infrastructure.DataAccess.Repositories;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    public sealed class ProductRepositoryTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public ProductRepositoryTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task Add()
        {
            ProductRepository productRepository = new ProductRepository(this._fixture.Context);

            Product product = new Product(
                SeedData.DefaultName,
                SeedData.DefaultStatus,
                SeedData.DefaultSupplier,
                SeedData.DefaultRate,
                SeedData.DefaultContractLength,
                SeedData.DefaultDailyStandingCharge, SeedData.Renewable);

            await productRepository
               .Add(product)
               .ConfigureAwait(false);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAnyProduct = this._fixture
                .Context
                .Products
                .Any(e => e.Id == product.Id);

            
            Assert.True(hasAnyProduct);
        }

        [Fact]
        public async Task Delete()
        {
            ProductRepository productRepository = new ProductRepository(this._fixture.Context);

            Product product = new Product(
                SeedData.DefaultName,
                SeedData.DefaultStatus,
                SeedData.DefaultSupplier,
                SeedData.DefaultRate,
                SeedData.DefaultContractLength,
                SeedData.DefaultDailyStandingCharge, SeedData.Renewable);



            await productRepository
               .Add(product)
               .ConfigureAwait(false);

            

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            productRepository
                .Delete(product.Id);

            await this._fixture
                .Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAnyProduct = this._fixture
                .Context
                .Products
                .Any(e => e.Id == product.Id);


            Assert.False(hasAnyProduct);
        }
    }
}
