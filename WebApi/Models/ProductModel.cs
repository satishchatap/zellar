namespace WebApi.Models
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    ///     Product Details.
    /// </summary>
    public sealed class ProductModel
    {
        /// <summary>
        ///     Product Details constructor.
        /// </summary>
        public ProductModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Status = product.Status;
            Supplier = product.Supplier;
            Rate = product.Rate;
            ContractLength = product.ContractLength;
            DailyStandingCharge = product.DailyStandingCharge;
            Renewable = product.Renewable;
        }

        /// <summary>
        ///     Gets product ID.
        /// </summary>
        [Required]
        public int Id { get; }
        /// <summary>
        /// Supplier
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// Supplier
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Rate
        /// </summary>
        public float Rate { get; set; }
        /// <summary>
        /// Daily Standing Charge
        /// </summary>
        public float DailyStandingCharge { get; set; }
        /// <summary>
        /// Contract Length
        /// </summary>
        public int ContractLength { get; set; }
        /// <summary>
        /// Renewable
        /// </summary>
        public int Renewable { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }


    }
}
