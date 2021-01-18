namespace Infrastructure.DataAccess.Configuration
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    /// <summary>
    ///     Product Configuration.
    /// </summary>
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        ///     Configure Product.
        /// </summary>
        /// <param name="builder">Builder.</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Product");
            builder.Property(product => product.Supplier)
                .IsRequired();
            builder.Property(product => product.Name)
                .IsRequired();
            builder.Property(product => product.Rate)
                .IsRequired();
            builder.Property(product => product.Renewable)
                .IsRequired();
            builder.Property(product => product.Status)
                .IsRequired();
            builder.Property(product => product.DailyStandingCharge)
                .IsRequired();
            builder.Property(product => product.ContractLength)
                .IsRequired();
            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(p => p.RowVersion)
                .IsRowVersion();

        }
    }
}
