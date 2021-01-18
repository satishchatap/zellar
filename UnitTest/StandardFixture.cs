namespace UnitTest
{

    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Infrastructure;

    /// <summary>
    /// </summary>
    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            this.Context = new DataContextFake();
            this.ProductRepositoryFake = new ProductRepositoryFake(this.Context);
            this.UnitOfWork = new UnitOfWorkFake();
            this.EntityFactory = new EntityFactory();
        }

        public EntityFactory EntityFactory { get; }

        public DataContextFake Context { get; }

        public ProductRepositoryFake ProductRepositoryFake { get; }

        public UnitOfWorkFake UnitOfWork { get; }
    }
}