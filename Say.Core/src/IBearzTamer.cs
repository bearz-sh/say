using Cowsay.Abstractions;

namespace Bearz.Say.Core;

/// <summary>
/// Defines methods for taming bears to produce cows.
/// </summary>
public interface IBearzTamer
{
    /// <summary>
    /// Tames a bear with the specified name to produce a cow.
    /// </summary>
    /// <param name="bearName">The name of the bear to tame.</param>
    /// <returns>The cow produced by the tamed bear.</returns>
    IBearz TameBear(string bearName);

    /// <summary>
    /// Tames a bear from the specified stream to produce a cow.
    /// </summary>
    /// <param name="bearStream">The stream containing the bear to tame.</param>
    /// <returns>The cow produced by the tamed bear.</returns>
    IBearz TameBear(Stream bearStream);

    /// <summary>
    /// Asynchronously tames a bear with the specified name to produce a cow.
    /// </summary>
    /// <param name="bearName">The name of the bear to tame.</param>
    /// <returns>A task that represents the asynchronous taming operation. The task result contains the cow produced by the tamed bear.</returns>
    Task<IBearz> TameBearAsync(string bearName);

    /// <summary>
    /// Asynchronously tames a bear from the specified stream to produce a cow.
    /// </summary>
    /// <param name="bearStream">The stream containing the bear to tame.</param>
    /// <returns>A task that represents the asynchronous taming operation. The task result contains the cow produced by the tamed bear.</returns>
    Task<IBearz> TameBearAsync(Stream bearStream);
}