using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;

namespace DeviceReg.Common.Data.Models
{
   public class User: IEntity
    {
        public User()
        {
            Timestamp = new Timestamp();
            Tags = new List<Tag>();
            Devices = new List<Device>();
        }
        public int Id { get; set; }

        public Timestamp Timestamp { get; set; }

        public string name { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}
