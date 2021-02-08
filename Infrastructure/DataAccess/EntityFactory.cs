using Domain;

using System;

namespace Infrastructure
{
    public sealed class EntityFactory : IProductFactory
    {
        /// <inheritdoc />
        public Product NewProduct(string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge, int renewable)
       => new Product(name, status, supplier, rate, contractLength, dailyStandingCharge, renewable);
    }
}
