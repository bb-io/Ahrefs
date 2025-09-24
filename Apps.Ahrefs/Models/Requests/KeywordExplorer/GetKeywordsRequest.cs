using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests.KeywordExplorer;

public class GetKeywordsRequest
{
    [StaticDataSource(typeof(CountryCodeStaticHandler))]
    [Display("Country", Description = "The country where you want to search for keywords")]
    public string Country { get; set; }

    [Display("Keywords", Description = "A list of keywords to show metrics for")]
    public IEnumerable<string>? Keywords { get; set; }

    [Display("Target", Description = "The target of the search: a domain or a URL")]
    public string? Target { get; set; }

    [StaticDataSource(typeof(ModeStaticHandler))]
    [Display("Target mode", Description = "The scope of the target URL you specified")]
    public string? TargetMode { get; set; }
}
