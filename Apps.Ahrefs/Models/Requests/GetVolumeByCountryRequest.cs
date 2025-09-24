using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Requests;

public class GetVolumeByCountryRequest
{
    [Display("Keyword", Description = "The keyword to show metrics for")]
    public string Keyword { get; set; }

    [Display("Limit", Description = "The number of results to return. 20 by default")]
    public int? Limit { get; set; } = 20;
}
