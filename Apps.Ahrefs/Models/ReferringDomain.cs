using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models;

public class ReferringDomain
{
    [JsonProperty("domain")]
    [Display("Domain")]
    public string Domain { get; set; }

    [JsonProperty("dofollow_refdomains")]
    [Display("Do follow referring domains")]
    public int DoFollowRefdomains { get; set; }

    [JsonProperty("domain_rating")]
    [Display("Domain rating")]
    public double DomainRating { get; set; }

    [JsonProperty("links_to_target")]
    [Display("Links to target")]
    public int LinksToTarget { get; set; }

    [JsonProperty("positions_source_domain")]
    [Display("Keyword positions")]
    public int PositionsSourceDomain { get; set; }
}
