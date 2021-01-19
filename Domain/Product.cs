using System;

namespace Domain
{
    public class Product : IProduct
    {
        public Product(string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge)
        {
            Name = name;
            Status = status;
            Supplier = supplier;
            Rate = rate;
            ContractLength = contractLength;
            DailyStandingCharge = dailyStandingCharge;
        }

        public Product(int id, string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge)
        {
            Id = id;
            Name = name;
            Status = status;
            Supplier = supplier;
            Rate = rate;
            ContractLength = contractLength;
            DailyStandingCharge = dailyStandingCharge;
        }

        public int Id { get; set; }
        public string Supplier { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
        public float DailyStandingCharge { get; set; }
        public int ContractLength { get; set; }
        public int Renewable { get; set; }
        public string Status { get; set; }

        public byte[] RowVersion { get; set; }
    }

}
