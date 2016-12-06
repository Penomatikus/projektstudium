﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity.EntityFramework;
using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;

namespace DeviceReg.Common.Data.Models
{
    public class AspNetUser
    {
        public AspNetUser()
        {
            Devices = new List<Device>();
            Roles = new List<AspNetRole>();
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public ICollection<Device> Devices { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }


    }
}
