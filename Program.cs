// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers; // THIS IS MISSING

var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("http://mockbin.org/request/anything"),
    Headers =
    {
        { "Accept-Language", "en" },
        { "Content-Type", "application/json" }, // THIS IS WRONGFULLY ADDED
    },
    Content = new StringContent("{\n\t\"test\":123\n}")
    {
        Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
    }
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
}