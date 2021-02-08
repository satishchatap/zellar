namespace WebApi.UseCases.Products.V1.GetProducts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.GetProducts;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;

    /// <summary>
    /// Products
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.GetProducts)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class ProductsController : ControllerBase, IOutputPort
    {
        private readonly IGetProductsUseCase _useCase;

        private IActionResult? _viewModel;

        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="useCase"></param>
        public ProductsController(Validation validation, IGetProductsUseCase useCase)
        {
            this._validation = validation;
            this._useCase = useCase;
        }

        void IOutputPort.Ok(IList<Product> products) => this._viewModel = this.Ok(new GetProductsResponse(products));

        /// <summary>
        ///     Get Products.
        /// </summary>
        /// <response code="200">The List of Products.</response>
        /// <response code="404">Not Found.</response>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductsResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get(ProductSearch productSearch)
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute(productSearch)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
