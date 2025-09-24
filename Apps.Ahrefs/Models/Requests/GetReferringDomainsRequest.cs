using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests;

public class GetReferringDomainsRequest
{
    [Display("Target", Description = "The target of the search: a domain or a URL")]
    public string Target { get; set; }

    [Display("Protocol", Description = "The protocol of your target")]
    [StaticDataSource(typeof(ProtocolStaticHandler))]
    public string? Protocol { get; set; }

    [Display("Mode", Description = "The scope of the search based on the target you entered")]
    [StaticDataSource(typeof(ModeStaticHandler))]
    public string? Mode { get; set; }
}
