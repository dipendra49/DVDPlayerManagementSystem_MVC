using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.EntityModel
{
    public class CastMember
    {
        public long DVDNumber { get; set; }
        public long ActorNumber { get; set; }
    }
}
