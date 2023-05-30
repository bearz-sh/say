namespace Bearz.Say.Core;

internal class BearzFile
{
    private readonly Stream? fileStream;

    private readonly SemaphoreSlim streamLock = new SemaphoreSlim(1);

    private string? fileContents;

    internal BearzFile(Stream fileStream)
    {
        this.fileStream = fileStream;
    }

    internal BearzFile(string fileContents)
    {
        this.fileContents = fileContents;
    }

    private enum LoadMode
    {
        Stream,
        String,
    }

    internal async Task<string> GetCowFormatAsync()
    {
        if (this.fileContents is null)
        {
            if (this.fileStream is null)
                throw new InvalidOperationException("Cannot load cow format from string when the file stream is null.");

            await this.streamLock.WaitAsync();

            try
            {
                if (this.fileContents is null)
                    this.fileContents = await this.fileStream.ConvertToStringAsync(leaveOpen: true);
            }
            finally
            {
                this.streamLock.Release();
            }
        }

        var cowFormat = ExtractCow(this.fileContents);
        return cowFormat;
    }

    internal string GetCowFormat()
    {
        if (this.fileContents is null)
        {
            if (this.fileStream is null)
                throw new InvalidOperationException("Cannot load cow format from string when the file stream is null.");

            this.streamLock.Wait();

            try
            {
                if (this.fileContents is null)
                    this.fileContents = this.fileStream.ConvertToString(leaveOpen: true);
            }
            finally
            {
                this.streamLock.Release();
            }
        }

        var cowFormat = ExtractCow(this.fileContents);
        return cowFormat;
    }

    private static string ExtractCow(string cowString)
    {
        var match = Constants.Cow.Match(cowString);

        if (!match.Groups["cow"].Success)
        {
            throw new ArgumentException("Failed to extract cow from cow file.", nameof(cowString));
        }

        var cow = match.Groups["cow"].Value;

        cow = Constants.LineEndings.Replace(cow, Environment.NewLine)
            .Replace("\\\\", "\\");

        return cow;
    }
}