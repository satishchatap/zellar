namespace Domain
{
    public class ProductNull : IProduct
    {
        public static ProductNull Instance { get; } = new ProductNull();
        public int Id { get; set; } =0;
        public string Supplier { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
        public float DailyStandingCharge { get; set; }
        public int ContractLength { get; set; }
        public int Renewable { get; set; }
        public string Status { get; set; }
        public byte[] RowVersion { get; }
    }

}
