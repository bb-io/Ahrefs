using Apps.Ahrefs.Models.Entities;
using Apps.Ahrefs.Models.Utility;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class KeywordsResponse : UnitsResponse
{
    [JsonProperty("keywords")]
    [Display("Keywords")]
    public List<Keyword> Keywords { get; set; }

    [Display("All words")]
    public string AllKeywords => string.Join(", ", Keywords.Select(x => x.Word));

    [Display("Keywords Termbase", Description = "All keywords as a termbase file. Can be imported into other Apps.")]
    public FileReference TermbaseFile { get; set; }
}
