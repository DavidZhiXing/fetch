using CommandLine;

public class CommandLineOption
{
    [Option('m', "metadata", Required = false, HelpText = "Prints out the metadata for the webpage(s) being fetched.")]
    public bool Metadata { get; set; }

    [Value(0, Required = true, HelpText = "List of URLs to fetch")]
    public IEnumerable<string> Urls { get; set; }

    [Option(shortName: 'o', longName: "output", Required = false, HelpText = "Output folder to download the webpage files.", Default = "")]
    public string? Output { get; set; }
}