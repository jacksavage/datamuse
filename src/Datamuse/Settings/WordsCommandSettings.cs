using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Datamuse.Settings;

class WordsSettings : CommandSettings
{
    [Description("Require that the results have a meaning related to this string value")]
    [CommandOption("-m,--mean")]
    public string? MeansLike { get; set; }

    [Description("Require that the results are pronounced similarly to this string of characters")]
    [CommandOption("-s,--sound")]
    public string? SoundsLike { get; set; }

    [Description("Require that the results are spelled similarly to this string of characters")]
    [CommandOption("-p,--spell")]
    public string? SpelledLike { get; set; }

    [Description("Require that the results are in a predefined lexical relation to a word")]
    [CommandOption("-r,--related")]
    public (string Code, string Word)[]? Related { get; set; }

    [Description("Identifier for the vocabulary to use")]
    [CommandOption("-v,--vocab")]
    public string? Vocabulary { get; set; }

    [Description("Up to five hints about the theme of the document being written")]
    [CommandOption("-t,--topics")]
    public string[]? Topics { get; set; }

    [Description("A hint about the word that appears immediately to the left of the target word in a sentence")]
    [CommandOption("--left")]
    public string? LeftContext { get; set; }

    [Description("A hint about the word that appears immediately to the right of the target word in a sentence")]
    [CommandOption("--right")]
    public string? RightContext { get; set; }

    [Description("Maximum number of results")]
    [CommandOption("--max")]
    [DefaultValue(100)]
    public int? Maximum { get; set; }

    [Description("Single-letter codes (no delimiter) requesting extra lexical knowledge")]
    [CommandOption("--meta")]
    public string? MetadataFlags { get; set; }

    [Description("Prepend a result to the output that describes the query string from some other parameter")]
    [CommandOption("-e,--query-echo")]
    public string? QueryEcho { get; set; }

    public override ValidationResult Validate()
    {
        static string list<T>(IEnumerable<T> items) =>
            string.Join(", ", items);

        // valid vocabulary
        if (
            Vocabulary is not null
            && !SettingsResources.Vocabularies.Contains(Vocabulary.ToLower())
        ) return ValidationResult.Error($"Vocabulary must be one of {list(SettingsResources.Vocabularies)}");

        // valid relation code
        if (
            Related is not null
            && Related.Any(r => !SettingsResources.RelationCodes.Contains(r.Code))
        ) return ValidationResult.Error($"Relation codes must be one of {list(SettingsResources.RelationCodes)}");

        // valid maximum
        const int maxMax = 1000;
        if (Maximum is not null && (Maximum < 0 || Maximum > maxMax))
            return ValidationResult.Error($"Maximum must be non-negative and less than {maxMax}");

        // valid metadata flags
        if (
            MetadataFlags is not null
            && MetadataFlags.Any(f => !SettingsResources.ValidMetadataFlags.Contains(f))
        ) return ValidationResult.Error($"Metadata flags must be one of {list(SettingsResources.ValidMetadataFlags)}");

        return ValidationResult.Success();
    }
}
