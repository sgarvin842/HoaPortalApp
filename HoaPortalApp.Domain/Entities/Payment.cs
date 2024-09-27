﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public string Id { get; set; }
        public string ResidentId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
        public double LateFee { get; set; }
        private double CalculateLateFee(DateTime dueDate){
            throw new NotImplementedException();
        }
    }
}