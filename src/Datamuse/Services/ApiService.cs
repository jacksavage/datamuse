using Datamuse.Settings;

namespace Datamuse.Services;

class ApiService : IApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(string address)
    {
        _httpClient = new();
        _httpClient.BaseAddress = new Uri(address);
    }

    public string GetWords(WordsCommandSettings settings)
    {
        return _httpClient.GetStringAsync("/words?ml=ringing+in+the+ears").Result;
    }

    public string GetSuggestions(SuggestCommandSettings settings)
    {
        return _httpClient.GetStringAsync("/sug?s=rawand").Result;
    }
}