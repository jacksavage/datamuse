using Datamuse.Settings;

namespace Datamuse.Services;

interface IApiService
{
    string GetSuggestions(SuggestCommandSettings settings);
    string GetWords(WordsCommandSettings settings);
}
