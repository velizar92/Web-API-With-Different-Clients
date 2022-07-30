namespace ProgrammingConsoleWebClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using ProgrammingConsoleWebClient.ViewModels;
  
    public class HttpWebClient
    {
        private static readonly HttpClient s_client = new HttpClient();
        private readonly ILogger _logger;

        public HttpWebClient(ILogger logger)
        {
            _logger = logger;
            s_client.DefaultRequestHeaders.Accept.Clear();
        }

        public async Task<IEnumerable<ProgrammingLanguage>> GetResource(string resourceUrl)
        {
            var streamTask = s_client.GetStreamAsync(resourceUrl);
            var resource = await JsonSerializer.DeserializeAsync<List<ProgrammingLanguage>>(await streamTask);

            return resource;
        }
        public async Task CreateResource(string resourceUrl, ProgrammingLanguage programmingLanguage)
        {
            string jsonPayload = JsonSerializer.Serialize<ProgrammingLanguage>(programmingLanguage);

            StringContent httpContent = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            var response = await s_client.PostAsync(resourceUrl, httpContent);

            string result = response.Content.ReadAsStringAsync().Result;
            _logger.Log(result);
        }

        public async Task UpdateResource(string resourceUrl, ProgrammingLanguage programmingLanguage)
        {
            string jsonPayload = JsonSerializer.Serialize<ProgrammingLanguage>(programmingLanguage);

            StringContent httpContent = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            var response = await s_client.PutAsync(resourceUrl, httpContent);

            string result = response.Content.ReadAsStringAsync().Result;
            _logger.Log(result);
        }

        public async Task DeleteResource(string resourceUrl)
        {
            var response = await s_client.DeleteAsync(resourceUrl);

            string result = response.Content.ReadAsStringAsync().Result;
            _logger.Log(result);
        }
    }
}
