namespace Application.UseCases.GetProducts
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
        void Ok(IList<IProduct> products);
    }
}
