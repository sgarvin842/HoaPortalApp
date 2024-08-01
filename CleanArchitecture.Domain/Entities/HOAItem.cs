using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    public abstract class HOAItem
    {
        public string ItemId { get; set; }
        public string Title { get; set; }
        public Date CreatedDate { get; set; }

        public abstract string GetDetails();
    }
}
