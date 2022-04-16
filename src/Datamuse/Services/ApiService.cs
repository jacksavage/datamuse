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
        // make the request
        string joined = string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        return _httpClient.GetStringAsync($"{endpoint}?{joined}").Result;
    }
}