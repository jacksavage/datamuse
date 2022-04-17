using Datamuse.Models;
using Datamuse.Settings;

namespace Datamuse.Services;

interface IApiService
{
    Result[]? GetSuggestions(SuggestCommandSettings settings);
    Result[]? GetWords(WordsCommandSettings settings);
}
