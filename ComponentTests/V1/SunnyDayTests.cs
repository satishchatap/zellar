namespace ComponentTests.V2
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;
    /// <summary>
    /// Happy Path
    /// </summary>
    public sealed class SunnyDayTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;
        public SunnyDayTests(CustomWebApplicationFactory factory) => this._factory = factory;

        private async Task<Tuple<Guid, string>> GetProducts()
        {
            HttpClient client = this._factory.CreateClient();
            HttpResponseMessage actualResponse = await client
                .GetAsync("/api/v1/Products/")
                .ConfigureAwait(false);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            using StringReader stringReader = new StringReader(actualResponseString);
            using JsonTextReader reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};

            JObject jsonResponse = await JObject.LoadAsync(reader)
                .ConfigureAwait(false);

            Guid.TryParse(jsonResponse["products"]![0]!["id"]!.Value<string>(), out Guid id);
            var title = jsonResponse["products"]![0]!["title"]!.Value<string>();

            return new Tuple<Guid, string>(id, title);
        }

        private async Task GetProduct(string id)
        {
            HttpClient client = this._factory.CreateClient();
            await client.GetAsync($"/api/v2/Products/{id}")
                .ConfigureAwait(false);
        }

        [Fact]
        public async Task GetProducts_GetProduct()
        {
            Tuple<Guid, string> product = await this.GetProducts()
                .ConfigureAwait(false);
            await this.GetProduct(product.Item1.ToString())
                .ConfigureAwait(false);
        }
    }
}
