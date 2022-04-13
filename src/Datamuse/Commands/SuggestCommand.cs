using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;

namespace Datamuse.Commands;

class SuggestCommand : Command<SuggestCommandSettings>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] SuggestCommandSettings settings)
    {
        AnsiConsole.WriteLine($"HintString : {settings.HintString}");
        AnsiConsole.WriteLine($"Maximum : {settings.Maximum}");
        AnsiConsole.WriteLine($"Vocabulary : {settings.Vocabulary}");

        return 0;
    }
}
