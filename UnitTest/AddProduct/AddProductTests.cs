

namespace UnitTest.AddProduct
{
    using Domain;
    using Infrastructure;
    using Infrastructure.DataAccess.Repositories;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    public sealed class AddProductTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public AddProductTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task AddProduct()
        {
            ProductRepositoryFake productRepository = new ProductRepositoryFake(this._fixture.Context);

            Product product = new Product(
               SeedData.DefaultName,
                SeedData.DefaultStatus,
                SeedData.DefaultSupplier,
                SeedData.DefaultRate,
                SeedData.DefaultContractLength,
                SeedData.DefaultDailyStandingCharge,
                SeedData.Renewable);



            await productRepository
               .Add(product)
               .ConfigureAwait(false);

            bool hasAnyProduct = this._fixture
                .Context
                .Products
                .Any(e => e.Id == product.Id);


            Assert.True(hasAnyProduct);
        }


    }
}
