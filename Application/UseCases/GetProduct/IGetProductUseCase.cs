using System;
using System.Threading.Tasks;

namespace Application.UseCases.GetProduct
{
    public interface IGetProductUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        /// <param name="id">Product Id.</param>
        Task Execute(int id);

        /// <summary>
        ///     Executes the Use Case.
        /// </summary>
        /// <param name="outputPort"></param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
