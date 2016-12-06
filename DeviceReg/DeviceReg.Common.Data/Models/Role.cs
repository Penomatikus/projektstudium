using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class AspNetRole
    {
        public AspNetRole()
        {
            Users = new List<AspNetUser>();
        }
        public string Id { get; set; }
        [Index("RoleNameIndex")]
        [MaxLength(256)]
        public string Name { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; }
    }
}
