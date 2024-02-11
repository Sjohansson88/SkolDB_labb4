using System;
using System.Collections.Generic;

namespace SkolDB_labb4.Models
{
    public partial class TblBetyg
    {
        public int BetygId { get; set; }
        public int? BetygNamn { get; set; }
        public DateTime? BetygDatum { get; set; }
        public int? StudentId { get; set; }
        public int? KursId { get; set; }
        public int? PersonalId { get; set; }

        public virtual TblKur? Kurs { get; set; }
        public virtual TblPersonal? Personal { get; set; }
        public virtual TblStudent? Student { get; set; }
    }
}
