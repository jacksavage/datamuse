using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Datamuse.Settings;

class SuggestCommandSettings : CommandSettings
{
    [Description("Prefix hint string; typically, the characters that the user has entered so far into a search box")]
    [CommandArgument(0, "<hint>")]
    public string? Hint { get; set; }

    [Description("Maximum number of results")]
    [CommandOption("--max")]
    [DefaultValue(10)]
    public int? Maximum { get; set; }

    [Description("Identifier for the vocabulary to use")]
    [CommandOption("-v|--vocab")]
    public string? Vocabulary { get; set; }

    public override ValidationResult Validate() =>
        Validation.ValidateUntilError(new Func<ValidationResult>[] {
            () => Validation.ValidateMaximum(Maximum),
            () => Validation.ValidateVocabulary(Vocabulary),
        });
}
