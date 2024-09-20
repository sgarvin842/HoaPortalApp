using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoaPortalApp.Domain.Entities
{
    [Table("Documents")]
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
