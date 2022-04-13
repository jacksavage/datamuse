using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Datamuse.Services;

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
        AnsiConsole.WriteLine(_apiService.GetSuggestions());

        return 0;
    }
}
