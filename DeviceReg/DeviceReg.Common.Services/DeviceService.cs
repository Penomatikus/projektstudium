using DeviceReg.Common.Data.Models;
using DeviceReg.Repositories;
using DeviceReg.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Services
{
    public class DeviceService : AbstractService
    {
        public DeviceService(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public Device AddDevice(Device device)
        {
            UnitOfWork.Devices.Add(device);          
            return (UnitOfWork.SaveChanges() > 0) ? device : null;
        }

        public bool Delete(int id)
        {
            var device = UnitOfWork.Devices.GetById(id);

            if (device != null)
            {
                UnitOfWork.Devices.Delete(device);
                return UnitOfWork.SaveChanges() > 0;
            }

            return false;
        }

        public Device GetDevice(int v)
        {
            throw new NotImplementedException();
        }

        public List<Device> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        public Device UpdateDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public object UpdateDevice(string id, Device device)
        {
            throw new NotImplementedException();
        }
    }
}
