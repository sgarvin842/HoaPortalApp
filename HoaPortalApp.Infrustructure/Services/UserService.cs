using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Contracts.Identity;
using HoaPortalApp.Application.Contracts.User;
using HoaPortalApp.Application.Features.Roles.Requests.Commands;
using Microsoft.Extensions.Localization;
using HoaPortalApp.Application.Features.Users.Results;
using HoaPortalApp.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using HoaPortalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using HoaPortalApp.Persistence;

namespace HoaPortalApp.Identity.Services
{
    public class UserService : BaseResponseHandler, IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<UserService> _localizer;
        private readonly IUser _user;
        private readonly ApplicationDbContext _context;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IStringLocalizer<UserService> localizer,
            IUser user,
            ApplicationDbContext context)
            : base(localizer)
        {
            _userManager = userManager;
            _localizer = localizer;
            _user = user;
            _context = context;
        }

        public async Task<BaseResponse<UserSummaryResult>> GetUserSummary(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest<UserSummaryResult>(_localizer["UserNotFound", userId]);
            }
            var ownerResidences = _context.OwnerResidences.ToList();
            var userSummaryResult = new UserSummaryResult()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                OwnerResidences = _context.OwnerResidences.Where(x => x.ResidentId == new Guid(user.Id)).ToList(),
                Payments = _context.Payments.Where(x => x.ResidentId == user.Id).ToList(),
            };


            return Success<UserSummaryResult>(userSummaryResult);
        }

    }
}
