using CustomerTrackingService.Application.Common.Extensions;
using CustomerTrackingService.Application.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTrackingService.Infrastructure.Services
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IConfigurationSection _openIddictSetting;
        private IConfiguration _config;
        private HttpClient _httpClient;

        public AuthorizeService(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClient = httpClientFactory.CreateClient();
            _openIddictSetting = _config.GetSection("OpenIddict");

            _openIddictSetting.CheckArgumentIsNull(nameof(_openIddictSetting));
        }

        public async Task<TokenAuthDto> GetTokenByCode(CallbackAuthDto dto)
        {
            var result = new TokenAuthDto();

            using (var httpClient = new HttpClient())
            {

                var data = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" }
                };


                var content = new FormUrlEncodedContent(data);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var response = await _httpClient.PostAsync("https://example.com/api/data", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    // Process the response content

                }

                return result;
            }
        }
    }
}
