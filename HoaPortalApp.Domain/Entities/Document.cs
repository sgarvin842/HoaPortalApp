using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    public class Document: HOAItem
    {
        public string Content { get; set; }
        public string getDocumentContent()
        {
            return "";
        }
        public override string GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
