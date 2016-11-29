using DeviceReg.WebApi.Controllers.Base;
using DeviceReg.WebApi.Models;
using DeviceReg.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DeviceReg.WebApi.Controllers
{
    ///  <summary>
    /// Controller for User Manipulation 
    /// </summary>
    [RoutePrefix("api/users")]
    public class UserController : ApiControllerBase, IHttpMethods<UserModel>
    {
        private UserService Service;
        /// <summary>
        /// From ApiControllerBase
        /// </summary>
        /// <param name="controllerContext"></param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            Service = new UserService(UnitOfWork);
        }
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("{userID}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string userID)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all User
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("{userID}")]
        [HttpGet]
        public UserModel Get(string userID)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("")]
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
        [Route("{userID}")]
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
        [Route("{userID}/devices")]
        [HttpGet]
        public IEnumerable<DeviceModel> GetDevices(string userId)
        {
            //Only Device IDs and names?
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get device of User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [Route("{userID}/devices/{deviceId}")]
        [HttpGet]
        public DeviceModel GetDevice(string userId, string deviceId)
        {
            //Needed? DeviceController can be used
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create Device of User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("{userID}/devices")]
        [HttpPost]
        public HttpResponseMessage PostDevice(string userId, [FromBody]DeviceModel model)
        {
            // Post only deviceId? Use DeviceController for Creation? only Link Device to User here?
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Device of User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [Route("{userID}/devices/{deviceId}")]
        [HttpDelete]
        public HttpResponseMessage DeleteDevice(string userId, string deviceId)
        {
            // complete or just Relation?
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Tags
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("{userID}/tags")]
        [HttpGet]
        public IEnumerable<TagModel> GetTags(string userId)
        {
            // only IDs? Create Tag Contoller?
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagname"></param>
        /// <returns></returns>
        [Route("{userId}/tags/{tagname}")]
        [HttpGet]
        public TagModel GetTag(string userId, string tagname)
        {
            // What is there to get?
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("{userId}/tags")]
        [HttpPost]
        public HttpResponseMessage PostTag(string userId, TagModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete Tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagname"></param>
        /// <returns></returns>
        [Route("{userID}/tags/{tagname}")]
        [HttpDelete]
        public HttpResponseMessage DeleteTag(string userId, string tagname)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update Tag
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("{userId}/tags/{tagname}")]
        [HttpPut]
        public HttpResponseMessage PutTag(TagModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Devices of User with tag
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tagname"></param>
        /// <returns></returns>
        [Route("{userId}/tags/{tagname}/devices")]
        [HttpGet]
        public IEnumerable<DeviceModel> GetTagDevices(string userId, string tagname)
        {
            //again, only IDs?
            throw new NotImplementedException();
        }
    }
}
