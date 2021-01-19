namespace WebApi.UseCases.Products.V1.GetAllProducts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.GetAllProducts;
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
    [FeatureGate(CustomFeature.GetAllProducts)]
    [Route("api/v{version:apiVersion}/[controller]/GetAll")]
    [ApiController]
    public sealed class ProductsController : ControllerBase, IOutputPort
    {
        private readonly IGetAllProductUseCase _useCase;

        private IActionResult? _viewModel;

        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        /// <param name="useCase"></param>
        public ProductsController(Validation validation, IGetAllProductUseCase useCase)
        {
            this._validation = validation;
            this._useCase = useCase;
        }

        void IOutputPort.Ok(IList<Product> products) => this._viewModel = this.Ok(new GetAllProductsResponse(products));

        /// <summary>
        ///     Get Products.
        /// </summary>
        /// <response code="200">The List of Products.</response>
        /// <response code="404">Not Found.</response>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllProductsResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public async Task<IActionResult> Get()
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute()
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
