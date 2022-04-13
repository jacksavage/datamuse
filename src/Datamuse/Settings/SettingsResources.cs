using Spectre.Console;

namespace Datamuse.Settings;

static class SettingsResources
{
    // valid codes for the `Vocabulary` option
    static readonly HashSet<string> Vocabularies = new()
    { 
        "es",
        "enwiki",
    };

    // valid codes for the `Related` option
    static readonly HashSet<string> RelationCodes = new()
    {
        "jja",
        "jjb",
        "syn",
        "trg",
        "ant",
        "spc",
        "gen",
        "com",
        "par",
        "bga",
        "bgb",
        "rhy",
        "nry",
        "hom",
        "cns",
    };

    // valid characters for the `MetaDataFlags` option
    static readonly HashSet<char> ValidMetadataFlags = new()
    {
        'd', // definitions
        'p', // parts of speech
        's', // syllable count
        'r', // pronunciation
        'f', // word frequency
    };

    static string PrintList<T>(IEnumerable<T> items) =>
        string.Join(", ", items);

    public static ValidationResult ValidateVocabulary(string? vocabulary)
    {
        if (
            vocabulary is not null
            && !SettingsResources.Vocabularies.Contains(vocabulary.ToLower())
        ) return ValidationResult.Error($"Vocabulary must be one of {PrintList(SettingsResources.Vocabularies)}");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidateRelationCodes(IEnumerable<(string Code, string Word)>? relations)
    {
        if (
            relations is not null
            && relations.Any(r => !SettingsResources.RelationCodes.Contains(r.Code))
        ) return ValidationResult.Error($"Relation codes must be one of {PrintList(SettingsResources.RelationCodes)}");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidateMetaDataFlags(IEnumerable<char>? metadataFlags)
    {
        if (
            metadataFlags is not null
            && metadataFlags.Any(f => !SettingsResources.ValidMetadataFlags.Contains(f))
        ) return ValidationResult.Error($"Metadata flags must be one of {PrintList(SettingsResources.ValidMetadataFlags)}");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidateMaximum(int? maximum)
    {
        const int maxMax = 1000;
        if (
            maximum is not null
            && (maximum < 0 || maximum > maxMax)
        ) return ValidationResult.Error($"Maximum must be non-negative and less than {maxMax}");

        return ValidationResult.Success();
    }
}