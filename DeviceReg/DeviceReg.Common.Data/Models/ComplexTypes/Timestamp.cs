using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models.ComplexTypes
{
    [ComplexType]
    public class Timestamp
    {
        public Nullable<DateTime> Created { get; set; }
        public Nullable<DateTime> Deleted { get; set; }
        public Nullable<DateTime> Modified { get; set; }
    }
}
