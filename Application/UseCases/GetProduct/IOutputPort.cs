namespace Application.UseCases.GetProduct
{
    using Domain;
    /// <summary>
    ///     Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();

        /// <summary>
        ///     Product closed.
        /// </summary>
        void NotFound();

        /// <summary>
        ///     Product closed.
        /// </summary>
        void Ok(Product product);
    }
}
