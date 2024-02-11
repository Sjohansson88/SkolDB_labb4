using System;
using System.Collections.Generic;

namespace SkolDB_labb4.Models
{
    public partial class TblStudent
    {
        public TblStudent()
        {
            TblBetygs = new HashSet<TblBetyg>();
        }

        public int StudentId { get; set; }
        public string? StudentFnamn { get; set; }
        public string? StudentEnamn { get; set; }
        public string? Personnummer { get; set; }
        public int? KlassId { get; set; }

        public virtual TblKlass? Klass { get; set; }
        public virtual ICollection<TblBetyg> TblBetygs { get; set; }
    }
}
