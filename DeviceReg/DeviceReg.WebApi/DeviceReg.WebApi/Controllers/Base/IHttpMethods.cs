using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace DeviceReg.WebApi.Controllers.Base
{
    internal interface IHttpMethods<T>
    {
        IEnumerable<T> Get();
        T Get(string id);
        HttpResponseMessage Post([FromBody]T model);
        HttpResponseMessage Put([FromBody]T model);
        HttpResponseMessage Delete(string id);

    }
}