namespace WebApi.Modules
{
    using Application.Services;
    using Application.UseCases.CreateProduct;
    using Application.UseCases.DeleteProduct;
    using Application.UseCases.EditProduct;
    using Application.UseCases.GetAllProducts;
    using Application.UseCases.GetProduct;
    using Application.UseCases.GetProducts;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Adds Use Cases classes.
    /// </summary>
    public static class UseCasesExtensions
    {
        /// <summary>
        ///     Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Validation, Validation>();

            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.Decorate<ICreateProductUseCase, CreateProductValidationUseCase>();

            services.AddScoped<IGetProductUseCase, GetProductUseCase>();
            services.Decorate<IGetProductUseCase, GetProductValidationUseCase>();

            services.AddScoped<IEditProductUseCase, EditProductUseCase>();
            services.Decorate<IEditProductUseCase, EditProductValidationUseCase>();

            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
            services.Decorate<IDeleteProductUseCase, DeleteProductValidationUseCase>();

            services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();

            services.AddScoped<IGetAllProductUseCase, GetAllProductUseCase>();

            return services;
        }
    }
}
