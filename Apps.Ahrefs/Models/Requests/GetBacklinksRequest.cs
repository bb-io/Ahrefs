using Apps.Ahrefs.Handlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Ahrefs.Models.Requests;

public class GetBacklinksRequest
{
    [Display("Target", Description = "The target of the search: a domain or a URL")]
    public string Target { get; set; }

    [StaticDataSource(typeof(BacklinksModeStaticHandler))]
    [Display("Mode", Description = "The scope of the search based on the target you entered. Default mode is 'Subdomains'")]
    public string? Mode { get; set; }

    [StaticDataSource(typeof(BacklinksProtocolStaticHandler))]
    [Display("Protocol", Description = "The protocol of your target. Default is 'Both'")]
    public string? Protocol { get; set; }
}
