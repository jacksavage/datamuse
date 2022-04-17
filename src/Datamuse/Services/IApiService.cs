using Datamuse.Models;

namespace Datamuse.Services;

interface IApiService
{
    Result[]? GetSuggestions(IEnumerable<KeyValuePair<string, string>> parameters);
    Result[]? GetWords(IEnumerable<KeyValuePair<string, string>> parameters);
}
