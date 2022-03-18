using RequestService.Interface;
using RequestService.Policies;

namespace RequestService.Services;

public class RequestService: IRequestService
{
    private readonly ClientPolicy _clientPolicy;
    private readonly IHttpClientFactory _clientFactory;

    public RequestService(ClientPolicy clientPolicy, IHttpClientFactory clientFactory)
    {
        _clientPolicy = clientPolicy;
        _clientFactory = clientFactory;
    }
    
    public async Task<string> MakeRequest()
    {
        var client = _clientFactory.CreateClient();

        var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(() =>
            client.GetAsync("https://localhost:7094/api/Response/25"));
        
        if (response.IsSuccessStatusCode)
        {
            return "--> ResponseService returned Success";
        }
        
        return "--> ResponseService returned Failure";
    }
}