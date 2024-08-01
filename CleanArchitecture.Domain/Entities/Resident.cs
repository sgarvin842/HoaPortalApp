using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    public class Resident : User
    {
        public string Address { get; set; } = string.Empty;
        public void MakePayment(double amount, Date paymentDate)
        {

        }
        public List<Payment> viewPaymentHistory()
        {

        }
        public List<Payment> viewLatePayments()
        {
        }
        public List<Document> viewHOADocuments()
        {
        }
        public List<Event> viewEvents()
        {

        }
        public override bool Login(string Email, string password)
        {
            return true;
        }
        public override void Logout()
        {

        }
        public override void ResetPassword(string NewPassword)
        {

        }
    }
}
