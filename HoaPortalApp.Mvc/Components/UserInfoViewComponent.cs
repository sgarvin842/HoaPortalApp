using HoaPortalApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HoaPortalApp.Domain.AppMetaData;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using HoaPortalApp.Application.Features.Users.Results;
using Microsoft.AspNetCore.Http.Json;

public class UserInfoViewComponent : ViewComponent
{
    private readonly HttpClient _httpClient;

    public UserInfoViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userId = UserClaimsPrincipal.FindFirst(CustomClaimTypes.Uid)?.Value;
        if (userId == null) return Content(""); // Or handle the error as needed

        var response = await _httpClient.GetAsync($"{Router.UserRouting.Actions.GetUserSummary}?userId={userId}");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadFromJsonAsync<ApiResponse<UserSummaryResult>>(); ;
            return View(responseContent.Data);
        }
        return Content(""); // Show no content if data fetch fails
    }
}