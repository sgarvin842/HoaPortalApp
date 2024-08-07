using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    public class Event: HOAItem
    {
        public string Description { get; set; }
        public Date EventDate { get; set; }
        public string GetEventDetails { get; set; }

        public override string GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
