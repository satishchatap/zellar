using System;
using System.Threading.Tasks;

namespace Application.UseCases.EditProduct
{
    public interface IEditProductUseCase
    {
        /// <summary>
        ///     Executes the Use Case
        /// </summary>
        Task Execute(int id, string name, string status, string supplier, float rate, int contractLength, float dailyStandingCharge);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
