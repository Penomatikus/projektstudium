﻿using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DeviceReg.WebApi.Controllers
{

  //  [RoutePrefix("api/Devices")]
    public class DeviceController : ApiControllerBase
    {
        private DeviceService Service;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            Service = new DeviceService(UnitOfWork);
        }

        [Authorize]
        public string Get()
        {
            //var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
            var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return user.ToString();
        }
       
        public HttpResponseMessage Post([FromBody]DeviceModel deviceModel)
        {
            var returncode = HttpStatusCode.BadRequest;

            if (deviceModel != null && deviceModel.IsValid())
            {
                var device = new Device();

                device.Description = deviceModel.Description;
                device.Serialnumber = deviceModel.SerialNumber;
                device.RegularMaintenance = deviceModel.RegularMaintenance;

                Service.AddDevice(device);

                returncode = HttpStatusCode.Accepted;
            }

            return new HttpResponseMessage(returncode);
        }

        public HttpResponseMessage Delete(string id)
        {
            var returncode = HttpStatusCode.BadRequest;
            var isDeleted = Service.Delete(Convert.ToInt32(id));

            if (isDeleted)
            {
                returncode = HttpStatusCode.Accepted;
            }

            return new HttpResponseMessage(returncode);
        }

    }
}