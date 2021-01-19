using Domain;

namespace Application.UseCases.DeleteProduct
{
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
        ///     Product deleted successfully.
        /// </summary>
        void Ok(Product product);

        /// <summary>
        ///     Product not found.
        /// </summary>
        void NotFound();
    }
}
