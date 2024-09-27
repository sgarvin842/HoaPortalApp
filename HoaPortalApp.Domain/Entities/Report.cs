using Microsoft.VisualBasic;
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
    [Table("Reports")]
    public class Report
    {
        [Key]
        public string Id { get; set; }
        public string ReportType { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string Content { get; set; }
        public string generateContent(){
            throw new NotImplementedException();
        }
    }
}
