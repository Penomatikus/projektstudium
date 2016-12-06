using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class AspNetUserClaim
    {
        public AspNetUserClaim() { }
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AspNetUser User {get; set;}

    }
}
