using HoaPortalApp.Application.Bases;
using MediatR;

namespace HoaPortalApp.Application.Features.Roles.Requests.Commands
{
    public class CreateRoleCommand : IRequest<BaseResponse<string>>
    {
        public string RoleName { get; set; }
    }
}
