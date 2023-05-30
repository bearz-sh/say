using Cowsay;
using Cowsay.Abstractions;

namespace Bearz.Say.Core;

public class BearzTamer : ICattleFarmer, IBearzTamer
{
    private readonly IBearzFormatProvider bearzFormatProvider;
    private readonly IBubbleBlower bubbleBlower;

    public BearzTamer(IBearzFormatProvider bearzFormatProvider, IBubbleBlower bubbleBlower)
    {
        this.bearzFormatProvider = bearzFormatProvider;
        this.bubbleBlower = bubbleBlower;
    }

    public static IBearzTamer Default { get; } = new BearzTamer(new BearzFormatProvider(), new DefaultBubbleBlower());

    public IBearz TameBear(string bearName)
    {
        string bearFormat = this.bearzFormatProvider.GetBearzFormat(bearName);

        return new Bearz(bearFormat, this.bubbleBlower);
    }

    public IBearz TameBear(Stream bearStream)
    {
        var bearFile = new BearzFile(bearStream.ConvertToString(leaveOpen: true));
        return new Bearz(bearFile.GetCowFormat(), this.bubbleBlower);
    }

    public async Task<IBearz> TameBearAsync(string bearName)
    {
        string bearFormat = await this.bearzFormatProvider.GetCowFormatAsync(bearName);

        return new Bearz(bearFormat, this.bubbleBlower);
    }

    public async Task<IBearz> TameBearAsync(Stream bearStream)
    {
        var bearFile = new BearzFile(await bearStream.ConvertToStringAsync(leaveOpen: true));
        return new Bearz(await bearFile.GetCowFormatAsync(), this.bubbleBlower);
    }

    public async Task<ICow> RearCowAsync(string cowName = "default")
    {
        string bearFormat = await this.bearzFormatProvider.GetCowFormatAsync(cowName);

        return new Cow(bearFormat, this.bubbleBlower);
    }

    public async Task<ICow> RearCowFromFileStreamAsync(Stream cowStream)
    {
        var bearFile = new BearzFile(await cowStream.ConvertToStringAsync(leaveOpen: true));
        return new Cow(await bearFile.GetCowFormatAsync(), this.bubbleBlower);
    }
}