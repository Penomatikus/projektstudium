using DeviceReg.Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class Device: IEntity
    {
        public Device()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
