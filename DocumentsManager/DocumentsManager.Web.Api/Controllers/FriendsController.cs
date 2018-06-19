using DocumentsManager.Exceptions;
using DocumentsManager.ProxyAcces;
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
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        // GET: api/Friends/5
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/Friends
        public IHttpActionResult Post(Guid userID, Guid token)
        {
            try
            {

                return Ok();
            }
            catch (SessionExpiredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AlreadyFriendsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AlreadySentRequestException ex)
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
