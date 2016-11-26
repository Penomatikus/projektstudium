using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Services;
using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
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
    public class DeviceController : ApiControllerBase, IHttpMethods<DeviceModel>
    {
        private const string BASE_ROUTE = "api/device";
        private const string BASE_ROUTE_WITH_ID ="api/device/{deviceId}";
        private const string BASE_ROUTE_WITH_ID_AND_TAG = "api/device/{deviceId}/tags";

        private DeviceService Service;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            Service = new DeviceService(UnitOfWork);
        }

        /// <summary>
        /// Get All Devices
        /// </summary>
        /// <returns></returns>
        [Route(BASE_ROUTE+"s")]
        [HttpGet]
        public IEnumerable<DeviceModel> Get()
        {
            var devices = Service.GetAllDevices();
            var deviceModels = devices.ConvertAll(x => new DeviceModel()
            {
                Id = x.Id,
                Description = x.Description,
                RegularMaintenance = x.RegularMaintenance,
                SerialNumber = x.Serialnumber
            });
            return deviceModels.AsEnumerable();
        }

        /// <summary>
        /// Get Device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE_WITH_ID)]
        [HttpGet]
        public DeviceModel Get(string id)
        {
            var device = Service.GetDevice(Convert.ToInt32(id));
            DeviceModel deviceModel = (device != null) ? new DeviceModel(){
                Id = device.Id,
                Description = device?.Description,
                RegularMaintenance = device.RegularMaintenance,
                SerialNumber = device.Serialnumber
            } : null ;
            if (deviceModel != null)
                return deviceModel;
            else throw new HttpResponseException(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Device not Found")
            });
        }


        /// <summary>
        /// Create new Device
        /// </summary>
        /// <param name="deviceModel"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE)]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]DeviceModel deviceModel)
        {
            var device = new Device()
            {
                Description = deviceModel.Description,
                Serialnumber = deviceModel.SerialNumber,
                RegularMaintenance = deviceModel.RegularMaintenance
            };

            Service.AddDevice(device);

            var response = Request.CreateResponse(HttpStatusCode.Created, deviceModel);
            string uri = Url.Route(null, new { id = deviceModel.Id });
            response.Headers.Location = new Uri(Request.RequestUri,uri) ;

            return response;
            
            
        }

        /// <summary>
        /// Update Device
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE_WITH_ID)]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]DeviceModel model)
        {
            var device = new Device();
            var status = HttpStatusCode.BadRequest;
            if (model != null && model.IsValid)
            {
                device.Description = model.Description;
                device.Serialnumber = model.SerialNumber;
                device.RegularMaintenance = model.RegularMaintenance;

                var success = Service.UpdateDevice(device) != null;
                status = (success) ? HttpStatusCode.OK : HttpStatusCode.NotFound;
            }
            var response = Request.CreateResponse(HttpStatusCode.Created, model);
            return response;
        }

        /// <summary>
        /// Delete Device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE_WITH_ID)]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            var returncode = HttpStatusCode.NoContent;
            var isDeleted = Service.Delete(Convert.ToInt32(id));

            return new HttpResponseMessage(returncode);
        }
        [Route(BASE_ROUTE_WITH_ID_AND_TAG)]
        [HttpGet]
        public IEnumerable<TagModel> GetTags(string deviceId)
        {
            throw new NotImplementedException();
        }
    }
}