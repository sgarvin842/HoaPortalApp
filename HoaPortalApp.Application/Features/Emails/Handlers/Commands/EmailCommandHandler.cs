using HoaPortalApp.Application.Bases;
using HoaPortalApp.Application.Contracts.Identity;
using HoaPortalApp.Application.Features.Emails.Requests.Commands;
using MediatR;

namespace HoaPortalApp.Application.Features.Emails.Handlers.Commands
{
    internal class EmailCommandHandler : IRequestHandler<SendEmailCommand, BaseResponse<string>>
    {
        private readonly IEmailsService _emailsService;

        public EmailCommandHandler(IEmailsService emailsService)
        {
            _emailsService = emailsService;
        }

        public async Task<BaseResponse<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            return await _emailsService.SendEmail(request.Email, request.Message, null);
        }
    }
}
