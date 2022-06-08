using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class DVDTitleModel
    {
        public long DVDNumber { get; set; }
        public long ProducerNumber { get; set; }
        public long CategoryNumber { get; set; }
        public long StudioNumber { get; set; }
        public DateTime DateReleased { get; set; }
        public Decimal StandardCharge { get; set; }
        public Decimal PenaltyCharge { get; set; }
    }
}
