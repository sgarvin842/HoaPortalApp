using HoaPortalApp.Application.Bases;
using MediatR;

namespace HoaPortalApp.Application.Features.Roles.Requests.Commands
{
    public class AssignRoleToUserCommand : IRequest<BaseResponse<string>>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
