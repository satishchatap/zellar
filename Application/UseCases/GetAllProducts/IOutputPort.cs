namespace Application.UseCases.GetAllProducts
{
    using System.Collections.Generic;
    using Domain;
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Listed products.
        /// </summary>
        void Ok(IList<Product> products);
    }
}
