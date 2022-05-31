using System.Net;
using System.Net.Http.Headers;

namespace Books.API;

public class APIHandler
{
	public Task<(HttpStatusCode, string)> GetBookByISBN(string isbn) => GetContent($"isbn/{isbn}");

	private static async Task<(HttpStatusCode, string)> GetContent(string content)
	{
		using HttpClient client = new();

		var baseUri = new Uri("https://openlibrary.org/");
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/json"));

		client.BaseAddress = baseUri;

		using HttpResponseMessage response = await client.GetAsync((string?)$"{content}.json");
		var output = "";
		if (response.IsSuccessStatusCode)
		{
			output = await response.Content.ReadAsStringAsync();
		}

		return (response.StatusCode, output);
	}
}