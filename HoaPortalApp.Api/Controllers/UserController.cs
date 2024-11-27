using HoaPortalApp.Api.Base;
using HoaPortalApp.Application.Features.Auth.Requests.Commands;
using HoaPortalApp.Application.Features.Users.Requests.Queries;
using HoaPortalApp.Domain.AppMetaData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authentication.Commands.Models;

namespace HoaPortalApp.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpGet(Router.UserRouting.Actions.GetUserSummary)]
        public async Task<IActionResult> GetUserSummary([FromQuery] string userId)
        {
            var query = new GetUserSummaryQuery { UserId = userId };
            return CustomResult(await Mediator.Send(query));
        }
    }
}
