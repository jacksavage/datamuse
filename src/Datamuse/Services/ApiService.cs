using System.Net.Http.Json;
using Datamuse.Models;

namespace Datamuse.Services;

class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(string address)
    {
        _httpClient = new();
        _httpClient.BaseAddress = new Uri(address);
    }

    public Result[]? GetWords(IEnumerable<KeyValuePair<string, string>> parameters) =>
        GetResource("/words", parameters);

    public Result[]? GetSuggestions(IEnumerable<KeyValuePair<string, string>> parameters) =>
        GetResource("/sug", parameters);

    Result[]? GetResource(string endpoint, IEnumerable<KeyValuePair<string, string>> parameters)
    {
        // make the request
        string joined = string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        return _httpClient.GetFromJsonAsync<Result[]>($"{endpoint}?{joined}").Result;
    }
}