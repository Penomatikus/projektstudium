using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceReg.Common.Data.Models
{
    public class Tag: IEntity
    {
        public Tag()
        {
            Timestamp = new Timestamp();
            Devices = new List<Device>();
        }

        public int Id { get; set; }

        public Timestamp Timestamp { get; set; }

        public string name { get; set; }

        public int OwnerID { get; set; }

        [ForeignKey("OwnerID")]
        public virtual User User { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
