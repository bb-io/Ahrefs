using Apps.Ahrefs.Models.Entities;
using Apps.Ahrefs.Models.Utility;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;

namespace Apps.Ahrefs.Models.Responses.KeywordExplorer;

public class KeywordIdeasResponse : UnitsResponse
{
    [JsonProperty("keywords")]
    [Display("Keywords")]
    public List<KeywordIdea> Keywords { get; set; }

    [Display("Keywords Termbase", Description = "All keywords as a termbase file. Can be imported into other Apps.")]
    public FileReference TermbaseFile { get; set; }
}
