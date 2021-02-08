namespace Domain
{
    public interface IProductFactory
    {
        /// <summary>
        ///  Create New Product
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="supplier"></param>
        /// <param name="rate"></param>
        /// <param name="contractLength"></param>
        /// <param name="dailyStandingCharge"></param>
        /// <returns></returns>
        public Product NewProduct(string name, string status, string supplier, float rate,int contractLength, float dailyStandingCharge, int renewable);
    }
}
