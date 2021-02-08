namespace WebApi.UseCases.Products.V1.GetProduct
{
    using Application.Services;
    using Application.UseCases.GetProduct;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

  /// <summary>
  /// Products
  /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.GetProduct)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class ProductsController : ControllerBase, IOutputPort
    {
      
        private IActionResult? _viewModel;


        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validation"></param>
        public ProductsController(Validation validation)
        {
            this._validation = validation;
        }
        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._validation.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Product product) => this._viewModel = this.Ok(new GetProductResponse(product));

        /// <summary>
        ///     Get an product details.
        /// </summary>
        /// <response code="200">The Product.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="useCase">Use case.</param>
        /// <param name="id"></param>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public async Task<IActionResult> Get(
            [FromServices] IGetProductUseCase useCase,
            [FromRoute][Required] int id)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(id)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
