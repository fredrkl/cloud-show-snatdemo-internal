using System.Net.Http;
using System.Threading.Tasks;

public class InternalCallService : IInternalCallService
{
    private readonly HttpClient _httpClient;

    public InternalCallService(HttpClient httpClient){
        _httpClient = httpClient;
    }
    public async Task GetInternalResponse()
    {
        await _httpClient.GetStringAsync("");
    }
}