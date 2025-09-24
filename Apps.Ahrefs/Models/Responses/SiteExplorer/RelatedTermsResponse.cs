using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class RelatedTermsResponse
{
    [JsonProperty("keywords")]
    public List<RelatedTerm> RelatedTerms { get; set; }
}
