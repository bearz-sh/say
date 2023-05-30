using Cowsay.Abstractions;

namespace Bearz.Say.Core;

public interface IBearzFormatProvider : ICowFormatProvider
{
    Task<string> GetBearzFormatAsync(string cowName);

    string GetBearzFormat(string cowName);
}