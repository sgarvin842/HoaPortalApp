using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Features.Auth.Results;
using MediatR;

namespace HoaPortalApp.Application.Features.Auth.Requests.Commands
{
    public class RegisterCommand : IRequest<BaseResponse<RegisterResult>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
