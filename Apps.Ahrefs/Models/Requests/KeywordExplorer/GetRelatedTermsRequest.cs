using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests.KeywordExplorer;

public class GetRelatedTermsRequest
{
    [Display("Country")]
    [StaticDataSource(typeof(CountryCodeStaticHandler))]
    public string Country { get; set; }

    [Display("Keywords", Description = "A list of keywords to show metrics for")]
    public IEnumerable<string>? Keywords { get; set; }
}
