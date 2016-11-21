using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        Timestamp Timestamp { get; set; }
    }
}
