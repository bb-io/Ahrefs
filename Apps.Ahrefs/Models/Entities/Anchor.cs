using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Entities;

public class Anchor
{
    [JsonProperty("anchor")]
    [Display("Anchor")]
    public string Text { get; set; }

    [JsonProperty("links_to_target")]
    [Display("Links to target")]
    public int LinksToTarget { get; set; }

    [JsonProperty("lost_links")]
    [Display("Lost links")]
    public int LostLinks { get; set; }

    [JsonProperty("refdomains")]
    [Display("Referring domains")]
    public int ReferringDomains { get; set; }

    [JsonProperty("refpages")]
    [Display("Referring pages")]
    public int ReferringPages { get; set; }

    [JsonProperty("top_domain_rating")]
    [Display("Top domain rating")]
    public double TopDomainRating { get; set; }
}
