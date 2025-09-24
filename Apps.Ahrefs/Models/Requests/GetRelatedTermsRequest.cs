using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests;

public class GetRelatedTermsRequest
{
    [Display("Country", Description = "The country where you want to search for keywords")]
    [StaticDataSource(typeof(CountryCodeStaticHandler))]
    public string Country { get; set; }

    [Display("Keywords", Description = "A list of keywords to show metrics for")]
    public IEnumerable<string>? Keywords { get; set; }
}
