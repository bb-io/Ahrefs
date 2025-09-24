using Apps.Ahrefs.Api;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Ahrefs.Actions;

[ActionList("Site explorer")]
public class SiteExplorerActions(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [Action("Get backlinks", Description = "Gets all backlinks of the specified target")]
    public async Task<BacklinksResponse> GetBacklinks([ActionParameter] GetBacklinksRequest request)
    {
        var client = new AhrefsClient(Creds);
        return await client.GetBacklinks(request);
    }

    [Action("Get domain rating", Description = "Gets domain rating of the specified target for specific date")]
    public async Task<DomainRatingResponse> GetDomainRating([ActionParameter] GetDomainRatingRequest request)
    {
        var client = new AhrefsClient(Creds);
        return await client.GetDomainRating(request);
    }
}