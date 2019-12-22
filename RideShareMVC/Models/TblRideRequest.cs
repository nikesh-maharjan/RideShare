using System;
using System.Collections.Generic;

namespace RideShareMVC.Models
{
    public partial class TblRideRequest
    {
        public Guid RideRequestGuid { get; set; }
        public Guid RequestFromGuid { get; set; }
        public Guid RequestToGuid { get; set; }
        public DateTime RequestStartDateTime { get; set; }
        public DateTime RequestEndDateTime { get; set; }
        public Guid RequestStartAddressGuid { get; set; }
        public Guid RequestEndAddressGuid { get; set; }
        public DateTime RequestCreateDate { get; set; }
        public DateTime RequestUpdateDate { get; set; }

        public virtual Tbladdress RequestEndAddressGu { get; set; }
        public virtual TblUser RequestFromGu { get; set; }
        public virtual Tbladdress RequestStartAddressGu { get; set; }
        public virtual TblUser RequestToGu { get; set; }
    }
}
