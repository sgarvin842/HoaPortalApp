using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    public class Report
    {
        public string ReportId { get; set; }
        public string ReportType { get; set; }
        public Date GeneratedDate { get; set; }
        public string Content { get; set; }
        public string generateContent(){
            throw new NotImplementedException();
        }
    }
}
