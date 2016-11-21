using DeviceReg.Common.Data.DeviceRegDB;
using DeviceReg.Repositories;
using DeviceReg.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DeviceReg.WebApi.Controllers.Base
{
    public class ApiControllerBase : ApiController
    {
        private UnitOfWork _UnitOfWork;

        protected UnitOfWork UnitOfWork
        {
            get { return _UnitOfWork; }
        }
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            var dbContext = new DeviceRegDBContext();

            _UnitOfWork = new UnitOfWork(dbContext);

        }

    }

}