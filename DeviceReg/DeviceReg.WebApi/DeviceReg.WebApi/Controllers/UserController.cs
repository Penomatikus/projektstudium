using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using DeviceReg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DeviceReg.WebApi.Controllers
{
    public class UserController : ApiControllerBase, IHttpMethods<UserModel>
    {
        private const string BASE_ROUTE = "api/user";
        private const string BASE_ROUTE_WITH_ID = "api/user/{userID}";
        private const string NESTED_DEVICE_ROUTE = "api/user/{userId}/device";
        private const string NESTED_DEVICE_ROUTE_WITH_ID = "api/user/{userId}/device/{deviceId}";

        private const string NESTED_TAG_ROUTE = "api/user/{userId}/tags";
        private const string NESTED_TAG_ROUTE_WITH_NAME = "api/user/{userId}/tag/{tagName}";

        private const string NESTED_DEVICES_WITH_TAG = "api/user/{userId}/tag/{tagName}/devices";

        private UserService Service;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            Service = new UserService(UnitOfWork);
        }
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE_WITH_ID)]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all User
        /// </summary>
        /// <returns></returns>
        [Route(BASE_ROUTE + "s")]
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE_WITH_ID)]
        [HttpGet]
        public UserModel Get(string id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE + "s")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] UserModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(BASE_ROUTE_WITH_ID)]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] UserModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get All Devices of User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route(NESTED_DEVICE_ROUTE + "s")]
        [HttpGet]
        public IEnumerable<DeviceModel> GetDevices(string userId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get device of User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [Route(NESTED_DEVICE_ROUTE_WITH_ID)]
        [HttpGet]
        public DeviceModel GetDevice(string userId, string deviceId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create Device of User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(NESTED_DEVICE_ROUTE + "s")]
        [HttpPost]
        public HttpResponseMessage PostDevice(string userId, [FromBody]DeviceModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update device of User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(NESTED_DEVICE_ROUTE_WITH_ID)]
        [HttpPut]
        public HttpResponseMessage PutDevice(string userId, [FromBody]DeviceModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Device of User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [Route(NESTED_DEVICE_ROUTE_WITH_ID)]
        [HttpDelete]
        public HttpResponseMessage DeleteDevice(string userId, string deviceId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Tags
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route(NESTED_TAG_ROUTE)]
        [HttpGet]
        public IEnumerable<TagModel> GetTags(string userId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route(NESTED_TAG_ROUTE_WITH_NAME)]
        [HttpGet]
        public TagModel GetTag(string userId, string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(NESTED_TAG_ROUTE)]
        [HttpPost]
        public HttpResponseMessage PostTag(string userId, TagModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route(NESTED_TAG_ROUTE_WITH_NAME)]
        [HttpDelete]
        public HttpResponseMessage DeleteTag(string userId, string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route(NESTED_TAG_ROUTE_WITH_NAME)]
        [HttpPut]
        public HttpResponseMessage PutTag(string userId, TagModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Devices of User with tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagName"></param>
        /// <returns></returns>
        [Route(NESTED_DEVICES_WITH_TAG)]
        [HttpGet]
        public IEnumerable<DeviceModel> GetTagDevices(string userId, string tagName)
        {
            throw new NotImplementedException();
        }
    }
}
