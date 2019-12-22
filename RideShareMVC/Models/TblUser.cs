using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RideShareMVC.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblRideRequestRequestFromGu = new HashSet<TblRideRequest>();
            TblRideRequestRequestToGu = new HashSet<TblRideRequest>();
            TblRideRideFromGu = new HashSet<TblRide>();
            TblRideRideToGu = new HashSet<TblRide>();
            Tbladdress = new HashSet<Tbladdress>();
            Tblcontact = new HashSet<Tblcontact>();
        }

        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Password { get; set; }

        //private byte[] password;

        //public byte[] GetPassword()
        //{
        //    return Password;
        //}

        public void SetPassword(String value)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] hash = GetMD5Hash(md5Hash, value);
                Password = hash;
            }
        }
        private byte[] GetMD5Hash(MD5 md5Hash, String password)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return data;
        }

        public DateTime? UserCreateDate { get; set; }
        public DateTime? UserUpdateDate { get; set; }

        public virtual ICollection<TblRideRequest> TblRideRequestRequestFromGu { get; set; }
        public virtual ICollection<TblRideRequest> TblRideRequestRequestToGu { get; set; }
        public virtual ICollection<TblRide> TblRideRideFromGu { get; set; }
        public virtual ICollection<TblRide> TblRideRideToGu { get; set; }
        public virtual ICollection<Tbladdress> Tbladdress { get; set; }
        public virtual ICollection<Tblcontact> Tblcontact { get; set; }
    }
}
