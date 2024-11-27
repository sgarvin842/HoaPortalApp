using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaPortalApp.Domain.Entities
{
    [Table("OwnerResidences")]
    public class OwnerResidence
    {
        public Guid Id { get; set; }
        public Guid ResidentId { get; set; }
        public bool IsPrimary { get; set; }
        public string ResidenceAddress { get; set; }
    }
}
