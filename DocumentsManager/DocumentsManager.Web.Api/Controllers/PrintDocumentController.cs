using DocumentsManager.BusinessLogic;
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
        private IDocumentBusinessLogic documentBusinessLogic { get; set; }
        public PrintDocumentController( IDocumentBusinessLogic dLogic)
        {
            this.documentBusinessLogic = dLogic;
        }
        public PrintDocumentController()
        {
            this.documentBusinessLogic = new DocumentBusinessLogic();
        }
        // GET: api/PrintDocument
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PrintDocument/5
        public string Get(Guid id)
        {
            Document toPrint = documentBusinessLogic.GetById(id);
            return documentBusinessLogic.PrintDocument(toPrint);
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
