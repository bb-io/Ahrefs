using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Entities;

public class DomainRating
{
    [JsonProperty("domain_rating")]
    [Display("Domain rating")]
    public double Rating { get; set; }

    [JsonProperty("ahrefs_rank")]
    [Display("Ahrefs rank")]
    public int? Rank { get; set; }
}
