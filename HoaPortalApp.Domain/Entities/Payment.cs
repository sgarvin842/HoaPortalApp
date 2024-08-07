using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    public class Payment
    {
        public string PaymentId { get; set; }
        public string ResidentId { get; set; }
        public double Amount { get; set; }
        public Date PaymentDate { get; set; }
        public string Status { get; set; }
        public double LateFee { get; set; }
        private double CalculateLateFee(Date dueDate){
            throw new NotImplementedException();
        }
    }
}
