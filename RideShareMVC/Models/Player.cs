using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RideShareMVC.Models
{
    public class Player
    {
        public long Id { get; set; }
        private string _key;
        public string Key
        {
            get
            {
                if(_key == null)
                {
                    _key = Regex.Replace(Name.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        [Display(Name="Player Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 characters long")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100")]
        public int Age { get; set; }

        public string Country { get; set; }

        public int Rank { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength =5, ErrorMessage ="Password must be atlest 5 chars")]
        public string Password { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}
