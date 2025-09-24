using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses;

public class DomainRatingResponse
{
    [JsonProperty("domain_rating")]
    public DomainRating DomainRating { get; set; }
}
