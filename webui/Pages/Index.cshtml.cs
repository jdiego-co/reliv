using domain;
using domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace webui.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    public IList<Patient> Patients { get; set; } = default!;

    public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    public void OnGet()
    {
        using (var httpClient = _httpClientFactory.CreateClient("api"))
        {
            var task = httpClient.GetAsync("/api/Patient");
            task.Wait();
            var resquestResponse = task.Result.Content.ReadFromJsonAsync<DTOActionResponse<IList<Patient>>>();
            resquestResponse.Wait();

            if(resquestResponse.IsCompletedSuccessfully && resquestResponse.Result.IsSuccess)
                Patients = resquestResponse.Result.Value;
        }
    }
}
