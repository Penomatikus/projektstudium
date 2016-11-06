using DeviceReg.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.DeviceRegDB
{
    public class DeviceRegDBContext : DbContext
    {
        public virtual DbSet<Devices> Devices { get; set; }
    }
}
