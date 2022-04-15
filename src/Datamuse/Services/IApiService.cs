using Datamuse.Settings;

namespace Datamuse.Services;

interface IApiService
{
    string? GetSuggestions(IEnumerable<KeyValuePair<string, string>> parameters);
    string? GetWords(IEnumerable<KeyValuePair<string, string>> parameters);
}
