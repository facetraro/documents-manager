using DocumentsManager.ProxyAcces;
using DocumentsManager.Web.Api.Models;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class RankDocumentsController : ApiController
    {
        private Proxy proxyAccess;
        public RankDocumentsController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public RankDocumentsController()
        {
            this.proxyAccess = new Proxy();
        }
        // GET: api/RankDocuments
        public IHttpActionResult Get(Guid token)
        {
            try
            {
                return Ok(proxyAccess.GetTopRankedDocuments(token));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/RankDocuments/5
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/RankDocuments
        public IHttpActionResult Post([FromBody]string value)
        {
            return NotFound();
        }

        // PUT: api/RankDocuments/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/RankDocuments/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
