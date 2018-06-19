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
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/ManageRequests
        public IHttpActionResult Post(Guid userId, Guid token)
        {
            try
            {
                return Ok(proxyAccess.AddFriend(userId, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/ManageRequests/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/ManageRequests/5
        public IHttpActionResult Delete(Guid userId, Guid token)
        {
            try
            {
                proxyAccess.RejectRequest(userId, token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
