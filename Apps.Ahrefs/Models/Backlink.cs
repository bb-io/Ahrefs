using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models;

public class Backlink
{
    [JsonProperty("anchor")]
    [Display("Anchor")]
    public string Anchor { get; set; }

    [JsonProperty("domain_rating_target")]
    [Display("Target domain rating")]
    public double DomainRatingTarget { get; set; }

    [JsonProperty("domain_rating_source")]
    [Display("Source domain rating")]
    public double DomainRatingSource { get; set; }

    [JsonProperty("positions")]
    [Display("Positions")]
    public int Positions { get; set; }

    [JsonProperty("name_source")]
    [Display("Referring domain name")]
    public string NameSource { get; set; }

    [JsonProperty("url_from")]
    [Display("URL from")]
    public string UrlFrom { get; set; }

    [JsonProperty("url_to")]
    [Display("URL to")]
    public string UrlTo { get; set; }
}
