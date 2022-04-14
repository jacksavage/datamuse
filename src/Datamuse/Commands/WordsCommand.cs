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
        string response = _apiService.GetWords(settings);
        AnsiConsole.WriteLine(response);

        return 0;
    }
}
