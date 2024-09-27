using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    [Table("Events")]
    public class Event: HOAItem
    {
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string GetEventDetails { get; set; }

        public override string GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
