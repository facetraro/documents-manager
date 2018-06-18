﻿using DocumentsManager.Exceptions;
using DocumentsManager.ProxyAcces;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class UserDocumentsController : ApiController
    {
        private Proxy proxyAccess;
        public UserDocumentsController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public UserDocumentsController()
        {
            this.proxyAccess = new Proxy();
        }

        // GET: api/UserDocuments
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        // GET: api/UserDocuments/5
        public IHttpActionResult Get(Guid userId, Guid token)
        {
            try {
                User user = proxyAccess.GetUserById(userId);
                return Ok(proxyAccess.GetDocumentsFromUser(user, token));
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
        }

        // POST: api/UserDocuments
        public IHttpActionResult Post([FromBody]string value)
        {
            return NotFound();
        }

        // PUT: api/UserDocuments/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/UserDocuments/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
