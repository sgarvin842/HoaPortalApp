using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    [Table("Residents")]
    public class Resident : User
    {
        public string Address { get; set; } = string.Empty;
        public void MakePayment(double amount, Date paymentDate)
        {

        }
        public List<Payment> viewPaymentHistory()
        {
            throw new NotImplementedException();

        }
        public List<Payment> viewLatePayments()
        {
            throw new NotImplementedException();
        }
        public List<Document> viewHOADocuments()
        {
            throw new NotImplementedException();
        }
        public List<Event> viewEvents()
        {
            throw new NotImplementedException();
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
