using DocumentsManager.BusinessLogic;
using DocumentsManager.Exceptions;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class DocumentController : ApiController
    {
        private IUsersBusinessLogic usersBuisnessLogic { get; set; }
        private IDocumentBusinessLogic documentBusinessLogic { get; set; }
        public DocumentController(IUsersBusinessLogic logic,IDocumentBusinessLogic dLogic)
        {
            this.usersBuisnessLogic = logic;
            this.documentBusinessLogic = dLogic;
        }
        public DocumentController()
        {
            this.usersBuisnessLogic = new AdminBusinessLogic();
            this.documentBusinessLogic = new DocumentBusinessLogic();
        }
        // GET: api/Document
        public IHttpActionResult Get()
        {
            IEnumerable<Document> documents = documentBusinessLogic.GetAllDocuments();
            if (documents == null)
            {
                return NotFound();
            }
            return Ok(documents);
        }

        // GET: api/Document/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                Document document = documentBusinessLogic.GetById(id);
                if (document == null)
                {
                    return NotFound();
                }
                return Ok(document);
            }
            
            catch (ObjectDoesNotExists doesNotExistsException)
            {
                return BadRequest(doesNotExistsException.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Document
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Document/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Document/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Document documentToDelete=documentBusinessLogic.GetById(id);
                bool updateResult = true /*usersBuisnessLogic.DeleteDocument(documentToDelete)*/;
                return Request.CreateResponse(HttpStatusCode.Accepted, updateResult);
            }
            catch (ObjectDoesNotExists doesNotExists)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, doesNotExists.Message);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
