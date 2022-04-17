using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Datamuse.Services;
using Datamuse.Models;

namespace Datamuse.Commands;

class SuggestCommand : Command<SuggestCommandSettings>
{
    private readonly IApiService _apiService;

    public SuggestCommand(IApiService apiService)
    {
        _apiService = apiService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] SuggestCommandSettings settings)
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

        // get the words and check for success
        Result[]? response = _apiService.GetSuggestions(parameters);
        if (response is null) return 1;

        // print the response to the user
        string print = string.Join("\n", response.Select(r => r.Word ?? ""));
        AnsiConsole.WriteLine(print);
        return 0;
    }
}
