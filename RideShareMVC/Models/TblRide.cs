using System;
using System.Collections.Generic;

namespace RideShareMVC.Models
{
    public partial class TblRide
    {
        public Guid RideGuid { get; set; }
        public Guid RideFromGuid { get; set; }
        public Guid RideToGuid { get; set; }
        public DateTime RideStartDateTime { get; set; }
        public DateTime RideEndDateTime { get; set; }
        public Guid RideStartAddressGuid { get; set; }
        public Guid RideEndAddressGuid { get; set; }
        public DateTime RideCreateDate { get; set; }
        public DateTime RideUpdateDate { get; set; }

        public virtual Tbladdress RideEndAddressGu { get; set; }
        public virtual TblUser RideFromGu { get; set; }
        public virtual Tbladdress RideStartAddressGu { get; set; }
        public virtual TblUser RideToGu { get; set; }
    }
}
