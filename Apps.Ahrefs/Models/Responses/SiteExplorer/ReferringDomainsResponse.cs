using Newtonsoft.Json;
using Apps.Ahrefs.Models.Utility;
using Apps.Ahrefs.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class ReferringDomainsResponse : UnitsResponse
{
    [JsonProperty("refdomains")]
    [Display("Referring domains")]
    public List<ReferringDomain> ReferringDomains { get; set; }
}
