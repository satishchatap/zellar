namespace WebApi.Modules.Common.FeatureFlags
{
    /// <summary>
    ///     Features Flags Enum.
    /// </summary>
    public enum CustomFeature
    {
        /// <summary>
        /// Product
        /// </summary>
        CreateProduct,

        /// <summary>
        ///     Get Product.
        /// </summary>
        GetProduct,

        /// <summary>
        ///     Get Products.
        /// </summary>
        GetProducts,

        /// <summary>
        ///     Filter errors out.
        /// </summary>
        ErrorFilter,

        /// <summary>
        ///     Use Swagger.
        /// </summary>
        Swagger,

        /// <summary>
        ///     Use SQL Server Persistence.
        /// </summary>
        SQLServer,        

        /// <summary>
        ///     Edit Product
        /// </summary>
        EditProduct,

        /// <summary>
        ///     Delete Product
        /// </summary>
        DeleteProduct,

        /// <summary>
        /// Get All Products
        /// </summary>
        GetAllProducts
    }
}
