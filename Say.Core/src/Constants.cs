using System.Text.RegularExpressions;

namespace Bearz.Say.Core;

public static class Constants
{
    internal static Regex Cow { get; } = new Regex(@"\$the_cow\s*=\s*<<""*EOC""*;*[\r\n]*(?<cow>[\s\S]+?)[\r\n]*EOC[\r\n]*", RegexOptions.Multiline);

    internal static Regex Eye { get; } = new Regex("\\$eye");

    internal static Regex LineEndings { get; } = new Regex(@"\r\n?|\n");
}