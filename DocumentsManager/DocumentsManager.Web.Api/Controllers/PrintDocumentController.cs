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
    public class PrintDocumentController : ApiController
    {
        private Proxy proxyAccess { get; set; }
        public PrintDocumentController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public PrintDocumentController()
        {
            this.proxyAccess = new Proxy();
        }
        // GET: api/PrintDocument
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PrintDocument/5
        public string Get(Guid id, Guid token)
        {
            Document toPrint = proxyAccess.GetDocumentById(id,token);
            return proxyAccess.PrintDocument(toPrint,token);
        }

        // POST: api/PrintDocument
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PrintDocument/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PrintDocument/5
        public void Delete(int id)
        {
        }
    }
}
