using DeviceReg.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceReg.Repositories;

namespace DeviceReg.Services
{
    public class UserService : AbstractService
    {
        public UserService(UnitOfWork currentUnitOfWork) : base(currentUnitOfWork)
        {
        }
    }
}
