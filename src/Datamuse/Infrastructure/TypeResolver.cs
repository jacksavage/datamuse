using Spectre.Console.Cli;

namespace Datamuse.Infrastructure;

// https://github.com/spectreconsole/spectre.console/tree/47fde1875b8dbcfdbae6fcd9061a615700bd6a5b/examples/Cli/Injection
sealed class TypeResolver : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _provider;

    public TypeResolver(IServiceProvider provider)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    public object Resolve(Type type)
    {
        if (type == null)
        {
            return null;
        }

        return _provider.GetService(type);
    }

    public void Dispose()
    {
        if (_provider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}
