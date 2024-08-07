using HoaPortalApp.Application.Bases;
using MediatR;

namespace HoaPortalApp.Application.Features.Roles.Requests.Queries
{
    public class GetAllClaimsQuery : IRequest<BaseResponse<IEnumerable<string>>>
    {
    }
}
