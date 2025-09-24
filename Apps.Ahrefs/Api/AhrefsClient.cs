using RestSharp;
using Newtonsoft.Json;
using Apps.Ahrefs.Constants;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Authentication;

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
        var responseContent = response.Content!;

        if (responseContent.Contains("Insufficient plan"))
            throw new PluginApplicationException("Your Ahrefs plan does not support this action");

        if (responseContent.Contains("bad target: "))
            throw new PluginMisconfigurationException("Incorrect target format");

        throw new PluginApplicationException(responseContent);
    }
}