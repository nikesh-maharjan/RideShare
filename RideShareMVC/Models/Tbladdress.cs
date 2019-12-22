using System;
using System.Collections.Generic;

namespace RideShareMVC.Models
{
    public partial class Tbladdress
    {
        public Tbladdress()
        {
            TblRideRequestRequestEndAddressGu = new HashSet<TblRideRequest>();
            TblRideRequestRequestStartAddressGu = new HashSet<TblRideRequest>();
            TblRideRideEndAddressGu = new HashSet<TblRide>();
            TblRideRideStartAddressGu = new HashSet<TblRide>();
        }

        public Guid AddressGuid { get; set; }
        public Guid UserGuid { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? PostalCode { get; set; }
        public DateTime AddressCreateDate { get; set; }
        public DateTime AddressUpdateDate { get; set; }

        public virtual TblUser UserGu { get; set; }
        public virtual ICollection<TblRideRequest> TblRideRequestRequestEndAddressGu { get; set; }
        public virtual ICollection<TblRideRequest> TblRideRequestRequestStartAddressGu { get; set; }
        public virtual ICollection<TblRide> TblRideRideEndAddressGu { get; set; }
        public virtual ICollection<TblRide> TblRideRideStartAddressGu { get; set; }
    }
}
