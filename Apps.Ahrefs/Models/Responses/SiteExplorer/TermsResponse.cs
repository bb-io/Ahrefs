using Apps.Ahrefs.Models.Entities;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.SiteExplorer;

public class TermsResponse
{
    [JsonProperty("keywords")]
    public List<Term> Terms { get; set; }
}
