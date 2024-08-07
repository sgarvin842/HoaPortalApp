using HoaPortalApp.Application.Bases;

namespace HoaPortalApp.Application.Contracts.Identity
{
    public interface IEmailsService
    {
        public Task<BaseResponse<string>> SendEmail(string email, string Message, string? reason);
    }
}
