using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Api.Integration.Functional.Controllers {
    public class ValuesController {

        public class GetShould : IClassFixture<WebApplicationFactory<Startup>> {
            private readonly HttpClient _client;

            public GetShould (WebApplicationFactory<Startup> factory) => _client = factory.CreateClient ();

            [Trait ("Category", "Functional")]
            [Fact (DisplayName = "API - Integration - Functional - ValuesController - Get - Should return array of strings")]
            public async Task ReturnArrayOfStrings () {
                async Task<bool> IsValid (HttpResponseMessage message) {
                    var isValid = true;

                    if (!message.IsSuccessStatusCode) { isValid = false; }

                    var content = await message.Content.ReadAsStringAsync ();

                    var json = new JArray();
                    try {
                        json = JArray.Parse (content);
                    } catch {
                        isValid = false;
                    }

                    foreach (var token in json.Children ()) {
                        if (token.Type != JTokenType.String) { isValid = false; }
                    }

                    return isValid;
                }

                //Act
                var response = _client.GetAsync ("/api/values").Result;

                //Assert
                Assert.True (await IsValid (response));
            }
        }
    }
}
