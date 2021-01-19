using System;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteProduct
{
    /// <summary>
    /// Delete Product use Case
    /// </summary>
    public interface IDeleteProductUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <param name="id">Product Id.</param>
        /// <returns>Task.</returns>
        Task Execute(int id);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
