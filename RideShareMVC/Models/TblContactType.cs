using System;
using System.Collections.Generic;

namespace RideShareMVC.Models
{
    public partial class TblContactType
    {
        public TblContactType()
        {
            Tblcontact = new HashSet<Tblcontact>();
        }

        public Guid ContactTypeGuid { get; set; }
        public string ContactType { get; set; }
        public DateTime ContactTypeCreateDate { get; set; }
        public DateTime ContactTypeUpdateDate { get; set; }

        public virtual ICollection<Tblcontact> Tblcontact { get; set; }
    }
}
