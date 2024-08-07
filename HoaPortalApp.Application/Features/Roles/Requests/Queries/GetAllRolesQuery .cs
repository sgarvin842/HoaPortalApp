using HoaPortalApp.Application.Bases;
using MediatR;

namespace HoaPortalApp.Application.Features.Roles.Requests.Queries
{
    public class GetAllRolesQuery : IRequest<BaseResponse<IEnumerable<string>>>
    {
    }
}
