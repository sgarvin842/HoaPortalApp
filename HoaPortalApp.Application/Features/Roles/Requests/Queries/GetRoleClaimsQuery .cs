using HoaPortalApp.Application.Bases;
using MediatR;

namespace HoaPortalApp.Application.Features.Roles.Requests.Queries
{
    public class GetRoleClaimsQuery : IRequest<BaseResponse<IEnumerable<string>>>
    {
        public string RoleName { get; set; }
    }
}
