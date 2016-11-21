using DeviceReg.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Services.Abstract
{
    public class AbstractService
    {
        protected UnitOfWork UnitOfWork { get; set; }

        public AbstractService(UnitOfWork currentUnitOfWork)
        {
            this.UnitOfWork = currentUnitOfWork;
        }

    }
}
