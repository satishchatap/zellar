using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Product : IProduct
    {
        public Product(string name, string status, string supplier, float rate, 
            int contractLength, float dailyStandingCharge,int renewable)
        {
            Name = name;
            Status = status;
            Supplier = supplier;
            Rate = rate;
            ContractLength = contractLength;
            DailyStandingCharge = dailyStandingCharge;
            Renewable = renewable;
        }

        public Product(int id, string name, string status, string supplier, float rate, 
            int contractLength, float dailyStandingCharge, int renewable)
        {
            Id = id;
            Name = name;
            Status = status;
            Supplier = supplier;
            Rate = rate;
            ContractLength = contractLength;
            DailyStandingCharge = dailyStandingCharge;
            Renewable = renewable;
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Supplier { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public float Rate { get; set; }
        public float DailyStandingCharge { get; set; }
        public int ContractLength { get; set; }
        public int Renewable { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }

        public byte[] RowVersion { get; set; }

    }

}
