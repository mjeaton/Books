using System.Net;
using System.Net.Http.Headers;

namespace Books.API
{
    public class APIHandler
    {
        public async Task<(HttpStatusCode, string)> GetBookByISBN(string isbn)
        {
            return await GetContent($"isbn/{isbn}");
        }

        private async Task<(HttpStatusCode, string)> GetContent(string content)
        {
            using (HttpClient client = new HttpClient())
            {
                var baseUri = new Uri("https://openlibrary.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                client.BaseAddress = baseUri;

                var finalUrl = $"{content}.json";

                using HttpResponseMessage response = await client.GetAsync(finalUrl);
                string output = "";
                if(response.IsSuccessStatusCode)
                {
                    output = await response.Content.ReadAsStringAsync();
                }
                return (response.StatusCode, output);
            }
        }
    }
}
