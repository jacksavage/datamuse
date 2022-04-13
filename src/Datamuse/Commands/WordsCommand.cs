using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Datamuse.Services;

namespace Datamuse.Commands;

class WordsCommand : Command<WordsSettings>
{
    private readonly IApiService _apiService;

    public WordsCommand(IApiService apiService)
    {
        _apiService = apiService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] WordsSettings settings)
    {
        AnsiConsole.WriteLine(_apiService.GetWords());

        return 0;
    }
}
