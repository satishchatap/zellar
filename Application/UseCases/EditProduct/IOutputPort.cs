namespace Application.UseCases.EditProduct
{
    using Domain;

    /// <summary>
    ///     Open Product Output Port.
    /// </summary>
    public interface IOutputPort
    {
        /// <summary>
        ///     Product open.
        /// </summary>
        void Ok(Product product);

        /// <summary>
        ///     Resource not found.
        /// </summary>
        void NotFound();

        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();
    }
}
