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
        // map settings to request parameter keys
        Dictionary<string, string> parameters = new()
        {

        };

        // get the suggestions and check for success
        string? response = _apiService.GetSuggestions(parameters);
        if (response is null) return 1;

        // print the response to the user
        AnsiConsole.WriteLine(response);
        return 0;
    }
}
