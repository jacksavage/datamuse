namespace Datamuse.Services;

class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(string address)
    {
        _httpClient = new();
        _httpClient.BaseAddress = new Uri(address);
    }

    public string? GetWords(IEnumerable<KeyValuePair<string, string>> parameters) =>
        GetResource("/words", parameters);

    public string? GetSuggestions(IEnumerable<KeyValuePair<string, string>> parameters) =>
        GetResource("/sug", parameters);

    string? GetResource(string endpoint, IEnumerable<KeyValuePair<string, string>> parameters)
    {
        // https://stackoverflow.com/a/47902348
        // setup the request
        HttpRequestMessage request = new(HttpMethod.Get, endpoint)
        {
            Content = new FormUrlEncodedContent(parameters),
        };
        
        // make the request and check for success
        using HttpResponseMessage response = _httpClient.Send(request);
        if (!response.IsSuccessStatusCode) return null;

        // read the content as a string
        Stream stream = response.Content.ReadAsStream();
        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }
}