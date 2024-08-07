using HoaPortalApp.Application.Bases;
using MediatR;

namespace HoaPortalApp.Application.Features.Roles.Requests.Commands
{
    public class AssignClaimToUserCommand : IRequest<BaseResponse<string>>
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
