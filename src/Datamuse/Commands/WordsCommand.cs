using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Datamuse.Services;
using Datamuse.Models;

namespace Datamuse.Commands;

class WordsCommand : Command<WordsCommandSettings>
{
    private readonly IApiService _apiService;

    public WordsCommand(IApiService apiService)
    {
        _apiService = apiService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] WordsCommandSettings settings)
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

        // get the words and check for success
        Result[]? response = _apiService.GetWords(parameters);
        if (response is null) return 1;

        // print the response to the user
        string print = string.Join("\n", response.Select(r => r.Word ?? ""));
        AnsiConsole.WriteLine(print);
        return 0;
    }
}
