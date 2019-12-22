using System;
using System.Collections.Generic;

namespace RideShareMVC.Models
{
    public partial class Tblcontact
    {
        public Guid ContactGuid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid? ContactType { get; set; }
        public string ContactValue { get; set; }
        public string IsActive { get; set; }
        public DateTime ContactCreateDate { get; set; }
        public DateTime ContactUpdateDate { get; set; }

        public virtual TblContactType ContactTypeNavigation { get; set; }
        public virtual TblUser UserGu { get; set; }
    }
}
