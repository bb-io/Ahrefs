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

    [Action("Get referred domains", Description = "Gets referring domains of the specified target")]
    public async Task<ReferringDomainsResponse> GetReferringDomains([ActionParameter] GetReferringDomainsRequest request)
    {
        var client = new AhrefsClient(Creds);
        return await client.GetReferringDomains(request);
    }

    [Action("Get anchors", Description = "Gets anchors of the specified target")]
    public async Task<AnchorsResponse> GetAnchors([ActionParameter] GetAnchorsRequest request)
    {
        var client = new AhrefsClient(Creds);
        return await client.GetAnchors(request);
    }
}