using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;

namespace Datamuse.Commands;

class WordsCommand : Command<WordsSettings>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] WordsSettings settings)
    {
        AnsiConsole.WriteLine($"MeansLike : {settings.MeansLike}");
        AnsiConsole.WriteLine($"SoundsLike : {settings.SoundsLike}");
        AnsiConsole.WriteLine($"SpelledLike : {settings.SpelledLike}");
        AnsiConsole.WriteLine($"Related : {settings.Related}");
        AnsiConsole.WriteLine($"Vocabulary : {settings.Vocabulary}");
        AnsiConsole.WriteLine($"Topics : {settings.Topics}");
        AnsiConsole.WriteLine($"LeftContext : {settings.LeftContext}");
        AnsiConsole.WriteLine($"RightContext : {settings.RightContext}");
        AnsiConsole.WriteLine($"Maximum : {settings.Maximum}");
        AnsiConsole.WriteLine($"MetadataFlags : {settings.MetadataFlags}");
        AnsiConsole.WriteLine($"QueryEcho : {settings.QueryEcho}");
        AnsiConsole.WriteLine($"Validate : {settings.Validate}");

        return 0;
    }
}
