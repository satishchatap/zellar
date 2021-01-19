namespace ComponentTests.V1
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    [Collection("WebApi Collection")]
    public sealed class GetProductsTests
    {
        private readonly CustomWebApplicationFactoryFixture _fixture;
        public GetProductsTests(CustomWebApplicationFactoryFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task GetProductsReturnsList()
        {
            HttpClient client = this._fixture
                .CustomWebApplicationFactory
                .CreateClient();

            HttpResponseMessage actualResponse = await client
                .GetAsync("/api/v1/Products/")
                .ConfigureAwait(false);

            string actualResponseString = await actualResponse.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, actualResponse.StatusCode);

            using StringReader stringReader = new StringReader(actualResponseString);
            using JsonTextReader reader = new JsonTextReader(stringReader) {DateParseHandling = DateParseHandling.None};
            JObject jsonResponse = await JObject.LoadAsync(reader)
                .ConfigureAwait(false);

            Assert.Equal(JTokenType.String, jsonResponse["products"]![0]!["id"]!.Type);
            Assert.Equal(JTokenType.String, jsonResponse["products"]![0]!["title"]!.Type);

            Assert.True(Guid.TryParse(jsonResponse["products"]![0]!["id"]!.Value<string>(), out Guid _));
            Assert.True(jsonResponse["products"]![0]!["title"]!.Value<string>()!="");
        }

    }
}
