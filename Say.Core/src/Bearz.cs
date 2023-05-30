using Cowsay.Abstractions;

namespace Bearz.Say.Core;

public class Bearz : IBearz, ICow
{
    private readonly string bearzFormat;

    private readonly IBubbleBlower bubbleGenerator;

    public Bearz(string bearzFormat, IBubbleBlower bubbleGenerator)
    {
        this.bearzFormat = bearzFormat;
        this.bubbleGenerator = bubbleGenerator;
    }

    public string Format => this.bearzFormat;

    public string Say(string phrase, string bearzEyes = "oo", string bearzTongue = "  ", int maxCols = 40, bool isThought = false)
    {
        bearzTongue = bearzTongue.PadRight(2);
        bearzEyes = bearzEyes.PadRight(2);

        string bubble = this.bubbleGenerator.GetBubble(phrase, maxCols, isThought);

        string cow = this.bearzFormat
            .Replace("$eyes", bearzEyes)
            .Replace("$tongue", bearzTongue)
            .Replace("$thoughts", isThought ? "o" : @"\");

        cow = Constants.Eye.Replace(cow, bearzEyes.First().ToString(), 1);
        cow = Constants.Eye.Replace(cow, bearzEyes.Last().ToString(), 1);

        return bubble + cow;
    }
}