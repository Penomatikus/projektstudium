using DeviceReg.Common.Data.Models;
using System;

namespace DeviceReg.WebApi.Models
{
    public class DeviceModel
    {
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public Boolean RegularMaintenance { get; set; }

        public bool IsValid 
        {
            get { return Validate(); }
        }

        private bool Validate()
        {
            return true;
        }

        public DeviceModel(Device device)
        {
            this.Id = device.Id;
            this.Description = device.Description;
            this.SerialNumber = device.Serialnumber;
            this.RegularMaintenance = device.RegularMaintenance;
            
        }

        public DeviceModel()
        {
        }
    }
}