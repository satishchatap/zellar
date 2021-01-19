﻿namespace Application.UseCases.GetProducts
{
    using Domain;
    using System.Threading.Tasks;

    /// <summary>
    ///         Case Domain-Driven Design Pattern
    /// </summary>
    public interface IGetProductsUseCase
    {
        /// <summary>
        ///     Executes the use case.
        /// </summary>
        /// <returns>Task.</returns>
        Task Execute(IProductSearch productSearch);

        /// <summary>
        ///     Sets the Output Port.
        /// </summary>
        /// <param name="outputPort">Output Port</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
