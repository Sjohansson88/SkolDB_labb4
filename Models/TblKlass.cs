using System;
using System.Collections.Generic;

namespace SkolDB_labb4.Models
{
    public partial class TblKlass
    {
        public TblKlass()
        {
            TblStudents = new HashSet<TblStudent>();
        }

        public int KlassId { get; set; }
        public string? KlassNamn { get; set; }

        public virtual ICollection<TblStudent> TblStudents { get; set; }
    }
}
