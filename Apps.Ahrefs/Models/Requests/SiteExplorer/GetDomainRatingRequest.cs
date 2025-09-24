using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Requests.SiteExplorer;

public class GetDomainRatingRequest
{
    [Display("Target", Description = "The target of the search: a domain or a URL")]
    public string Target { get; set; }

    [Display("Date", Description = "A date to report metrics on")]
    public DateTime Date { get; set; }
}
