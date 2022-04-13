namespace Datamuse.Settings;

static class SettingsResources
{
    // valid codes for the `Vocabulary` option
    public static readonly HashSet<string> Vocabularies = new()
    { 
        "es",
        "enwiki",
    };

    // valid codes for the `Related` option
    public static readonly HashSet<string> RelationCodes = new()
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
    public static readonly HashSet<char> ValidMetadataFlags = new()
    {
        'd', // definitions
        'p', // parts of speech
        's', // syllable count
        'r', // pronunciation
        'f', // word frequency
    };
}