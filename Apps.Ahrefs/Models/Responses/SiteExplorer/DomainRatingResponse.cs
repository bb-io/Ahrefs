using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class DomainRatingResponse : UnitsResponse
{
    [JsonProperty("domain_rating")]
    [Display("Domain rating")]
    public DomainRating DomainRating { get; set; }
}
