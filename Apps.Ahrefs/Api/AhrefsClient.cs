using Apps.Ahrefs.Constants;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text;

namespace Apps.Ahrefs.Api;

public class AhrefsClient : BlackBirdRestClient
{
    public AhrefsClient(IEnumerable<AuthenticationCredentialsProvider> creds) : base(new()
    {
        BaseUrl = new Uri("https://api.ahrefs.com/v3"),
    })
    {
        this.AddDefaultHeader("Authorization", creds.Get(CredsNames.ApiKey).Value);
    }

    public async Task<BacklinksResponse> GetBacklinks(GetBacklinksRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/all-backlinks?target={request.Target}&" +
            "select=anchor,domain_rating_target,domain_rating_source,positions,name_source,url_from,url_to"
        );

        if (!string.IsNullOrEmpty(request.Mode))
            query.Append($"&mode={request.Mode}");

        if (!string.IsNullOrEmpty(request.Protocol))
            query.Append($"&protocol={request.Protocol}");

        var restRequest = new RestRequest(query.ToString());
        return await ExecuteWithErrorHandling<BacklinksResponse>(restRequest);
    }

    public async Task<KeywordsResponse> GetKeywords(GetKeywordsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/overview?country={request.Country}&" +
            $"select=keyword,clicks,cpc,cps"
        );

        if (request.Keywords != null && request.Keywords.Any())
        {
            string keywords = string.Join(",", request.Keywords);
            query.Append($"&keywords={keywords}");
        }

        if (!string.IsNullOrEmpty(request.TargetMode))
            query.Append($"&target_mode={request.TargetMode}");

        if (!string.IsNullOrEmpty(request.Target))
            query.Append($"&target={request.Target}");

        var restRequest = new RestRequest(query.ToString());
        return await ExecuteWithErrorHandling<KeywordsResponse>(restRequest);
    } 

    public override async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);

        if (!response.IsSuccessStatusCode)
            throw ConfigureErrorException(response);

        return response;
    }

    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content, JsonSettings);
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var responseContent = response.Content;

        if (responseContent.Contains("Insufficient plan"))
            throw new PluginMisconfigurationException("Your Ahrefs plan does not support this action");

        var errorMessage = JArray.Parse(response.Content)[0].ToString();
        throw new PluginApplicationException(errorMessage);
    }
}