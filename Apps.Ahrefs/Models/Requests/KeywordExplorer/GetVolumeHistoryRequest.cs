using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests.KeywordExplorer;

public class GetVolumeHistoryRequest
{
    [Display("Keyword", Description = "The keyword to show metrics for")]
    public string Keyword { get; set; }

    [Display("Country")]
    [StaticDataSource(typeof(CountryCodeStaticHandler))]
    public string Country { get; set; }

    [Display("Start date", Description = "The start date of the historical period")]
    public DateTime? DateFrom { get; set; }

    [Display("End date", Description = "The end date of the historical period")]
    public DateTime? DateTo { get; set; }
}
