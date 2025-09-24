using Newtonsoft.Json;
using Apps.Ahrefs.Models.Entities;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class ReferringDomainsResponse
{
    [JsonProperty("refdomains")]
    public List<ReferringDomain> ReferringDomains { get; set; }
}
