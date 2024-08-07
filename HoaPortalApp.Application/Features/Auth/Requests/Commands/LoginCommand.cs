using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Features.Auth.Results;
using MediatR;

namespace HoaPortalApp.Application.Features.Auth.Requests.Commands
{
    public class LoginCommand : IRequest<BaseResponse<LoginResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
