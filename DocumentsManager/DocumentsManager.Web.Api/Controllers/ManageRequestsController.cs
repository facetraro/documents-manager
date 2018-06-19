using DocumentsManager.ProxyAcces;
using DocumentsManager.Web.Api.Dtos;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class ManageRequestsController : ApiController
    {
        private Proxy proxyAccess;
        public ManageRequestsController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public ManageRequestsController()
        {
            this.proxyAccess = new Proxy();
        }
        // GET: api/ManageRequests
        public IHttpActionResult Get(Guid token)
        {
            try
            {
                List<User> requests = proxyAccess.GetRequests(token);
                List<UserDto> dtoRequests = new List<UserDto>();
                foreach (User useri in requests)
                {
                    dtoRequests.Add(new Dtos.UserDto(useri));
                }
                return Ok(dtoRequests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ManageRequests/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ManageRequests
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ManageRequests/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ManageRequests/5
        public void Delete(int id)
        {
        }
    }
}
