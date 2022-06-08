using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.EntityModel
{
    public class DVDTitle
    {
        [Key]
        public long DVDNumber { get; set; }
        public long ProducerNumber { get; set; }
        public long CategoryNumber { get; set; }
        public long StudioNumber { get; set; }
        public DateTime DateReleased { get; set; }
        public Decimal StandardCharge { get; set; }
        public Decimal PenaltyCharge { get; set; }
    }
}
