namespace Bearz.Say.Core;

public static class StreamExtensions
{
    internal static async Task<string> ConvertToStringAsync(this Stream stream, bool leaveOpen = true)
    {
        stream.Seek(0, SeekOrigin.Begin);
        using (var streamReader = new StreamReader(stream, System.Text.Encoding.UTF8, false, 1024, leaveOpen: leaveOpen))
        {
            var content = await streamReader.ReadToEndAsync();
            return content;
        }
    }

    internal static string ConvertToString(this Stream stream, bool leaveOpen = true)
    {
        stream.Seek(0, SeekOrigin.Begin);
        using (var streamReader = new StreamReader(stream, System.Text.Encoding.UTF8, false, 1024, leaveOpen: leaveOpen))
        {
            return streamReader.ReadToEnd();
        }
    }
}