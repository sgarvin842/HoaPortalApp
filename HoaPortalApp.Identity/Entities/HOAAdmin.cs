using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HoaPortalApp.Domain.Entities
{
    [Table("HoaAdmins")]
    public class HOAAdmin: User
    {
        public void PostDocument(Document document){

        }
        public void PostEvent(Event eventObject){

        }
        public List<Payment> ViewAllPayments(){
            return null;
        }
        public Report GenerateReport(string reportType){
            return null;
        }
        public override bool Login(string Email, string password){
            return true;
        }
        public override void Logout(){

        }
        public override void ResetPassword(string NewPassword)
        {

        }
    }
}
