using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Datamuse.Services;

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
        Dictionary<string, string> parameters = new()
        {

        };

        // get the words and check for success
        string? response = _apiService.GetWords(parameters);
        if (response is null) return 1;

        // print the response to the user
        AnsiConsole.WriteLine(response);
        return 0;
    }
}
