using HoaPortalApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaPortalApp.Application.Features.Users.Results
{
    public class UserSummaryResult
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public List<Payment> Payments { get; set; }
        public List<OwnerResidence> OwnerResidences { get; set; }
    }
}
