using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses;

public class ReferringDomainsResponse
{
    [JsonProperty("refdomains")]
    public List<ReferringDomain> ReferringDomains { get; set; }
}
