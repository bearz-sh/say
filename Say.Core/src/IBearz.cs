namespace Bearz.Say.Core;

public interface IBearz
{
    /// <summary>
    /// Gets the format string for the cow before the placeholders have been replaced.
    /// </summary>
    /// <value>The format string for the cow before the placeholders have been replaced.</value>
    string Format { get; }

    /// <summary>
    /// Generates the ASCII art for the given phrase.
    /// </summary>
    /// <param name="phrase">The phrase to include in the speech/thought bubble.</param>
    /// <param name="bearzEyes">The characters for the bearz eyes.</param>
    /// <param name="bearzTongue">The characters for the bearz tongue.</param>
    /// <param name="maxCols">The maximum columns the text should take up before being wrapped.</param>
    /// <param name="isThought">True, if the bubble should be a thought bubble, False if it should be a speech bubble.</param>
    /// <returns>The ASCII art for the given phrase.</returns>
    string Say(string phrase, string bearzEyes = "oo", string bearzTongue = "  ", int maxCols = 40, bool isThought = false);
}