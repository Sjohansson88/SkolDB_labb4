using System;
using System.Collections.Generic;

namespace SkolDB_labb4.Models
{
    public partial class TblKur
    {
        public TblKur()
        {
            TblBetygs = new HashSet<TblBetyg>();
        }

        public int KursId { get; set; }
        public string? KursNamn { get; set; }

        public virtual ICollection<TblBetyg> TblBetygs { get; set; }
    }
}
