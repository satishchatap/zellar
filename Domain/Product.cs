using System;

namespace Domain
{
    public class Product : IProduct, IAuditEntity
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

        public int Id { get; set; }
        public string Supplier { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
        public float DailyStandingCharge { get; set; }
        public int ContractLength { get; set; }
        public int Renewable { get; set; }
        public string Status { get; set; }
        public byte[] RowVersion { get; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public string ModifiedBy { get; private set; }

        public void Audit(string userName, AuditType type)
        {
            switch (type)
            {
                case AuditType.Add:
                    CreatedBy = userName;
                    CreatedOn = DateTime.UtcNow;
                    ModifiedBy = userName;
                    ModifiedOn = DateTime.UtcNow;
                    break;
                case AuditType.Modify:
                    ModifiedBy = userName;
                    ModifiedOn = DateTime.UtcNow;
                    break;
                case AuditType.Delete:
                    ModifiedBy = userName;
                    ModifiedOn = DateTime.UtcNow;
                    break;
            }
        }
    }

}
