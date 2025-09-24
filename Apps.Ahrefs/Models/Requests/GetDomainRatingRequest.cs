using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests;

public class GetDomainRatingRequest
{
    [Display("Target", Description = "The target of the search: a domain or a URL")]
    public string Target { get; set; }

    [Display("Date", Description = "A date to report metrics on")]
    public DateTime Date { get; set; }

    [Display("Protocol", Description = "The protocol of your target")]
    [StaticDataSource(typeof(ProtocolStaticHandler))]
    public string? Protocol { get; set; }
}
