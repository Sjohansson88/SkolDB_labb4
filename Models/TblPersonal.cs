using System;
using System.Collections.Generic;

namespace SkolDB_labb4.Models
{
    public partial class TblPersonal
    {
        public TblPersonal()
        {
            TblBetygs = new HashSet<TblBetyg>();
        }

        public int PersonalId { get; set; }
        public string? PersonalFnamn { get; set; }
        public string? PersonalEnamn { get; set; }
        public int? BefattningsId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Salary { get; set; }

        public virtual ICollection<TblBetyg> TblBetygs { get; set; }
    }
}
