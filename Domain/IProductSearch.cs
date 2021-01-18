namespace Domain
{
    public interface IProductSearch
    {
        string Supplier { get; set; }
        float? Rate { get; set; }
        int? ContractLength { get; set; }
        string Status { get; set; }
    }
}