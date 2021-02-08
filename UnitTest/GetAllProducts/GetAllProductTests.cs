namespace UnitTest.GetAllProducts
{
    using Domain;
    using Infrastructure;
    using Infrastructure.DataAccess.Repositories;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class GetAllProductTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public GetAllProductTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task GetProducts()
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

            Product product2 = new Product(
                   SeedData.DefaultName2,
                SeedData.DefaultStatus2,
                SeedData.DefaultSupplier2,
                SeedData.DefaultRate2,
                SeedData.DefaultContractLength2,
                SeedData.DefaultDailyStandingCharge2,
                SeedData.Renewable2);

            await productRepository
               .Add(product)
               .ConfigureAwait(false);

            await productRepository
              .Add(product2)
              .ConfigureAwait(false);

            bool hasAnyProduct = this._fixture
                .Context
                .Products
                .Count()==2;


            Assert.True(hasAnyProduct);
        }


    }
}
