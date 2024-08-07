
using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Features.Auth.Requests.Commands;
using HoaPortalApp.Application.Features.Auth.Results;

namespace HoaPortalApp.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<BaseResponse<LoginResult>> Login(LoginCommand request);
        Task<BaseResponse<RegisterResult>> Register(RegisterCommand request);
        Task<BaseResponse<string>> SendResetPasswordCode(string email);
        Task<BaseResponse<string>> ConfirmAndResetPassword(string code, string email, string newPassword);
    }
}
