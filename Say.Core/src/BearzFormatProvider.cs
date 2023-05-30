using System.Text.RegularExpressions;

using Cowsay.Abstractions;

namespace Bearz.Say.Core;

public class BearzFormatProvider : IBearzFormatProvider
{
    public async Task<string> GetBearzFormatAsync(string cowName)
    {
        var assembly = typeof(Cowsay.DefaultCattleFarmer).Assembly;

        string cowFormat;

        var cows = assembly.GetManifestResourceNames()
            .Where(rn => rn.StartsWith("Cowsay.Cows"))
            .Select(rn => new { Name = Regex.Replace(rn, @"(^Cowsay\.Cows\.)*(\.cow$)*", string.Empty), FullPath = rn });

        string cowFileContents;
        var cowResource = cows.SingleOrDefault(o => o.Name.Equals(cowName, StringComparison.OrdinalIgnoreCase));
        if (cowResource is null)
            throw new FileNotFoundException($"{cowName}.cow embedded file not found");

        using (var stream = assembly.GetManifestResourceStream(cowResource.FullPath))
        {
            if (stream is null)
                throw new FileNotFoundException($"{cowName}.cow embedded file not found");

            cowFileContents = await stream.ConvertToStringAsync(leaveOpen: false);
        }

        var cowFile = new BearzFile(cowFileContents);
        cowFormat = await cowFile.GetCowFormatAsync();

        return cowFormat;
    }

    public async Task<string> GetCowFormatAsync(string cowName)
    {
        var format = await this.GetBearzFormatAsync(cowName);
        return format;
    }

    public string GetBearzFormat(string cowName)
    {
        var assembly = typeof(Cowsay.DefaultCattleFarmer).Assembly;

        string cowFormat;

        var cows = assembly.GetManifestResourceNames()
            .Where(rn => rn.StartsWith("Cowsay.Cows"))
            .Select(rn => new { Name = Regex.Replace(rn, @"(^Cowsay\.Cows\.)*(\.cow$)*", string.Empty), FullPath = rn });

        var cowResource = cows.SingleOrDefault(o => o.Name.Equals(cowName, StringComparison.OrdinalIgnoreCase));
        if (cowResource is null)
            throw new FileNotFoundException($"{cowName}.cow embedded file not found");

        string cowFileContents;

        using (var stream = assembly.GetManifestResourceStream(cowResource.FullPath))
        {
            if (stream is null)
                throw new FileNotFoundException($"{cowName}.cow embedded file not found");

            cowFileContents = stream.ConvertToString();
        }

        var cowFile = new BearzFile(cowFileContents);
        cowFormat = cowFile.GetCowFormat();

        return cowFormat;
    }
}