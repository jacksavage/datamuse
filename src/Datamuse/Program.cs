using Datamuse.Commands;
using Spectre.Console.Cli;

// configure the application
CommandApp app = new();
app.Configure(config =>
{
#if DEBUG
    // show full stack trace on error
    config.PropagateExceptions();
#endif

    // add the words command
    config
        .AddCommand<WordsCommand>("words")
        .WithAlias("w")
        .WithDescription("Returns a list of words/expressions that match a set of constraints.");

    // add the suggest command
    config
        .AddCommand<SuggestCommand>("sug")
        .WithAlias("s")
        .WithDescription("Provides word suggestions given a partially-entered query.");
});

// run it with the CLI arguments provided
app.Run(args);
