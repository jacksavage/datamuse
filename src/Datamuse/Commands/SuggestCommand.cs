using Spectre.Console.Cli;
using Datamuse.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Datamuse.Commands;

class SuggestCommand : Command<SuggestCommandSettings>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] SuggestCommandSettings settings)
    {
        throw new NotImplementedException();
    }
}
