namespace IntegrationTests
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using System;
    public static class SeedData
    {
        

        public static readonly int DefaultId = 101;
        public static readonly string DefaultName = "winter prices";
        public static readonly string DefaultSupplier = "British Ash";
        public static readonly float DefaultRate = 0.12F;
        public static readonly int DefaultContractLength = 39;
        public static readonly string DefaultStatus = "live";
        public static readonly float DefaultDailyStandingCharge = 0.35F;

        public static readonly int SecondId2 = 109;
        public static readonly string DefaultName2 = "black friday prices";
        public static readonly string DefaultSupplier2 = "British Gas";
        public static readonly float DefaultRate2 = 0.11F;
        public static readonly int DefaultContractLength2 = 24;
        public static readonly string DefaultStatus2 = "expired";
        public static readonly float DefaultDailyStandingCharge2 = 0.35F;




        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Entity<Product>()
                .HasData(
                    new
                    {
                        Id = DefaultId,
                        Name = DefaultName,
                        Supplier = DefaultSupplier
                    });

        }
    }
}
