namespace WebApi.UseCases.Products.V1.EditProduct
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Services;
    using Application.UseCases.EditProduct;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using Models;
    using System;

    /// <summary>
    /// Products
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.EditProduct)]
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

        void IOutputPort.Ok(Product product) =>
            this._viewModel = this.Ok(new EditProductResponse(new ProductModel(product)));

        /// <summary>
        ///     Edit an product.
        /// </summary>
        /// <response code="200">Product already exists,</response>
        /// <response code="201">The product was created successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <param name="id"></param>
        /// <param name="useCase"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="supplier"></param>
        /// <param name="rate"></param>
        /// <param name="contractLength"></param>
        /// <param name="dailyStandingCharge"></param>
        /// <param name="renewable"></param>
        /// <returns>The newly created product.</returns>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EditProductResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EditProductResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> Patch([FromRoute][Required] int id,
            [FromServices] IEditProductUseCase useCase,
            [FromForm][Required] string name,
            [FromForm][Required] string status,
            [FromForm][Required] string supplier,
            [FromForm][Required] float rate,
            [FromForm][Required] int contractLength,
            [FromForm][Required] float dailyStandingCharge, 
            [FromForm][Required] int renewable)
        {
            useCase.SetOutputPort(this);
            await useCase.Execute(id, name, status, supplier, rate, contractLength, dailyStandingCharge, renewable)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
