using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Features.Users.Results;

namespace HoaPortalApp.Application.Contracts.User;

public interface IUserService
{
    Task<BaseResponse<UserSummaryResult>> GetUserSummary(string id);
}
