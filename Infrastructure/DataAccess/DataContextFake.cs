namespace Infrastructure.DataAccess
{
    using Domain;
    using System.Collections.ObjectModel;

    public sealed class DataContextFake
    {
        /// <summary>
        /// </summary>
        public DataContextFake()
        {

            Product product = new Product(
                SeedData.DefaultName,
                SeedData.DefaultStatus,
                SeedData.DefaultSupplier,
                SeedData.DefaultRate,
                SeedData.DefaultContractLength,
                SeedData.DefaultDailyStandingCharge,SeedData.Renewable);

          
            this.Products.Add(product);

            Product product2 = new Product(
                   SeedData.DefaultName2,
                SeedData.DefaultStatus2,
                SeedData.DefaultSupplier2,
                SeedData.DefaultRate2,
                SeedData.DefaultContractLength2,
                SeedData.DefaultDailyStandingCharge2, SeedData.Renewable2);

            this.Products.Add(product2);
        }

        /// <summary>
        ///     Gets or sets Products.
        /// </summary>
        public Collection<Product> Products { get; } = new Collection<Product>();

    }
}
