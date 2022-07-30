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

    public class HttpWebClient : IHttpWebClient
    {
        private static readonly HttpClient s_client = new HttpClient();
        private readonly ILogger _logger;

        public HttpWebClient(ILogger logger)
        {
            _logger = logger;
            s_client.DefaultRequestHeaders.Accept.Clear();
        }


        public async Task<IEnumerable<ProgrammingLanguage>> GetResources(string resourceUrl)
        {
            try
            {
                var streamTask = s_client.GetStreamAsync(resourceUrl);
                var resource = await JsonSerializer.DeserializeAsync<List<ProgrammingLanguage>>(await streamTask);

                return resource;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<ProgrammingLanguage> GetResource(string resourceUrl, int id)
        {
            resourceUrl = resourceUrl.TrimEnd('/');

            try
            {
                var streamTask = s_client.GetStreamAsync($"{resourceUrl}/{id}");

                var resource = await JsonSerializer.DeserializeAsync<ProgrammingLanguage>(await streamTask);

                return resource;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }


        public async Task CreateResource(string resourceUrl, ProgrammingLanguage programmingLanguage)
        {
            try
            {
                string jsonPayload = JsonSerializer.Serialize<ProgrammingLanguage>(programmingLanguage);

                StringContent httpContent = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                var response = await s_client.PostAsync(resourceUrl, httpContent);

                string result = response.Content.ReadAsStringAsync().Result;
                _logger.Log(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        //The 'id' of programming language object also must be filled
        public async Task UpdateResource(string resourceUrl, ProgrammingLanguage programmingLanguage)
        {
            try
            {
                string jsonPayload = JsonSerializer.Serialize<ProgrammingLanguage>(programmingLanguage);

                StringContent httpContent = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                var response = await s_client.PutAsync(resourceUrl, httpContent);

                string result = response.Content.ReadAsStringAsync().Result;
                _logger.Log(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }


        public async Task DeleteResource(string resourceUrl, int id)
        {
            try
            {
                resourceUrl = resourceUrl.TrimEnd('/');

                var response = await s_client.DeleteAsync($"{resourceUrl}/{id}");

                string result = response.Content.ReadAsStringAsync().Result;
                _logger.Log(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
