using HoaPortalApp.Application.Bases;
using MediatR;

namespace HoaPortalApp.Application.Features.Roles.Requests.Queries
{
    public class GetUserRolesQuery : IRequest<BaseResponse<IEnumerable<string>>>
    {
        public string UserId { get; set; }
    }
}
