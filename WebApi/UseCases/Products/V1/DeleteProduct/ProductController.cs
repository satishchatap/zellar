using Application.Services;
using Application.UseCases.DeleteProduct;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApi.Modules.Common;
using WebApi.Modules.Common.FeatureFlags;

namespace WebApi.UseCases.Products.V1.DeleteProduct
{
    /// <summary>
    /// Products 
    /// </summary>
    [ApiVersion("1.0")]
    [FeatureGate(CustomFeature.DeleteProduct)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class ProductsController : ControllerBase, IOutputPort
    {
        private readonly IDeleteProductUseCase _useCase;
        private readonly Validation _validation;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="validation"></param>
        public ProductsController(IDeleteProductUseCase useCase, Validation validation)
        {
            this._useCase = useCase;
            this._validation = validation;
        }

        private IActionResult? _viewModel;

        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._validation.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        

        void IOutputPort.Ok(Product product) => this._viewModel = this.Ok(new DeleteProductResponse(product));

        /// <summary>
        ///     Delete an Product.
        /// </summary>
        /// <response code="200">The closed product id.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="404">Not Found.</response>
        /// <param name="id">The Id.</param>
        /// <returns>ViewModel.</returns>
        [Authorize(Policy = "FullAccess")]
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteProductResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<IActionResult> Delete(
            [FromRoute][Required] int id)
        {
            this._useCase.SetOutputPort(this);

            await this._useCase.Execute(id)
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
