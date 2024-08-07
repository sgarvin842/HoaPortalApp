using HoaPortalApp.Api.Base;
using HoaPortalApp.Application.Features.Emails.Requests.Commands;
using HoaPortalApp.Domain.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HoaPortalApp.Api.Controllers
{

    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class EmailsController : AppControllerBase
    {
        [HttpPost(Router.EmailsRoute.Actions.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            return CustomResult(await Mediator.Send(command));
        }
    }
}