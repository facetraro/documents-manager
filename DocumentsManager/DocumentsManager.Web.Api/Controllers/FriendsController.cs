using DocumentsManager.Exceptions;
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
    public class FriendsController : ApiController
    {
        private Proxy proxyAccess;
        public FriendsController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public FriendsController()
        {
            this.proxyAccess = new Proxy();
        }
        // GET: api/Friends
        public IHttpActionResult Get(Guid token)
        {
            try
            {
                List<User> friends = proxyAccess.GetFriends(token);
                List<UserDto> dtoFriends = new List<UserDto>();
                foreach (User useri in friends)
                {
                    dtoFriends.Add(new Dtos.UserDto(useri));
                }
                return Ok(dtoFriends);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Friends/5
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/Friends
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

        // PUT: api/Friends/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/Friends/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
