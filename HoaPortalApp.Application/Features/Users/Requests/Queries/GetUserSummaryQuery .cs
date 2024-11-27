using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Features.Users.Results;
using MediatR;

namespace HoaPortalApp.Application.Features.Users.Requests.Queries
{
    public class GetUserSummaryQuery : IRequest<BaseResponse<UserSummaryResult>>
    {
        public string UserId { get; set; }
    }
}
