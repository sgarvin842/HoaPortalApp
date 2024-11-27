using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Contracts.User;
using HoaPortalApp.Application.Features.Users.Requests.Queries;
using HoaPortalApp.Application.Features.Users.Results;
using MediatR;

namespace HoaPortalApp.Application.Features.Users.Handlers.Queries
{
    public class UsersQueryHandler :
     IRequestHandler<GetUserSummaryQuery, BaseResponse<UserSummaryResult>>
    {
        private readonly IUserService _userService;

        public UsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseResponse<UserSummaryResult>> Handle(GetUserSummaryQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserSummary(request.UserId);
            return result;
        }
    }
}
