using System.Text;

using Spectre.Console;

namespace Datamuse.Settings;

static class Validation
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

    static string PrintList<T>(IEnumerable<T> items)
    {
        static string quote<U>(U source) => $"'{source}'";

        var itemsE = items.GetEnumerator();
        if (!itemsE.MoveNext()) return "";
        StringBuilder sb = new($"{quote(itemsE.Current)}, ");

        int len = items.Count();
        for (int i = 1; i < len; i++)
        {
            itemsE.MoveNext();
            
            if (i == len - 1) sb.Append($" or {quote(itemsE.Current)}");
            else sb.Append($"{quote(itemsE.Current)}, ");
        }

        return sb.ToString();
    }

    public static ValidationResult ValidateVocabulary(string? vocabulary)
    {
        if (
            vocabulary is not null
            && !Validation.Vocabularies.Contains(vocabulary.ToLower())
        ) return ValidationResult.Error($"Vocabulary can only be {PrintList(Validation.Vocabularies)}");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidateRelationCodes(IEnumerable<(string Code, string Word)>? relations)
    {
        if (
            relations is not null
            && relations.Any(r => !Validation.RelationCodes.Contains(r.Code))
        ) return ValidationResult.Error($"Relation codes can only be {PrintList(Validation.RelationCodes)}");

        return ValidationResult.Success();
    }

    public static ValidationResult ValidateMetaDataFlags(IEnumerable<char>? metadataFlags)
    {
        if (
            metadataFlags is not null
            && metadataFlags.Any(f => !Validation.ValidMetadataFlags.Contains(f))
        ) return ValidationResult.Error($"Metadata flags can only be {PrintList(Validation.ValidMetadataFlags)}");

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

    public static ValidationResult ValidateUntilError(IEnumerable<Func<ValidationResult>> validations)
    {
        foreach (var validation in validations)
        {
            ValidationResult validationResult = validation.Invoke();
            if (!validationResult.Successful) return validationResult;
        }

        return ValidationResult.Success();
    }
}