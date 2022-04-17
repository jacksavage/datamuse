using System.Net.Http.Json;
using Datamuse.Models;
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

    public Result[]? GetWords(WordsCommandSettings settings)
    {
        // map settings to request parameter keys
        Dictionary<string, string> parameters = new();
        void add<T>(string key, T value)
        {
            if (value is not null)
            {
                parameters.Add(key, value.ToString());
            }
        }
        add("ml", settings.MeansLike);
        add("sl", settings.SoundsLike);
        add("sp", settings.SpelledLike);
        if (settings.Related is not null)
            foreach (var (code, word) in settings.Related)
                add($"rel_{code}", word);
        add("v", settings.Vocabulary);
        add("topics", settings.Topics);
        add("lc", settings.LeftContext);
        add("rc", settings.RightContext);
        add("max", settings.Maximum);
        add("md", settings.MetadataFlags);
        add("qe", settings.QueryEcho);

        return GetResource("/words", parameters);
    }

    public Result[]? GetSuggestions(SuggestCommandSettings settings)
    {
        // map settings to request parameter keys
        Dictionary<string, string> parameters = new();
        void add<T>(string key, T value)
        {
            if (value is not null)
            {
                parameters.Add(key, value.ToString());
            }
        }
        add("s", settings.Hint);
        add("v", settings.Vocabulary);
        add("max", settings.Maximum);

        return GetResource("/sug", parameters);
    }

    Result[]? GetResource(string endpoint, IEnumerable<KeyValuePair<string, string>> parameters)
    {
        // make the request
        string joined = string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        return _httpClient.GetFromJsonAsync<Result[]>($"{endpoint}?{joined}").Result;
    }
}