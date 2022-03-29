using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Datamuse.Commands;

class WordsCommand : Command<WordsSettings>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] WordsSettings settings)
    {
        throw new NotImplementedException();
    }
}
