using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaPortalApp.Domain.Entities
{
    [Table("Requests")]
    internal class Requests
    {
        [Key]
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime GeneratedDate { get; set; }
    }
}
