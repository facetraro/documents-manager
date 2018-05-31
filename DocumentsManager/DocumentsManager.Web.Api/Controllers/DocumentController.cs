using DocumentsManager.BusinessLogic;
using DocumentsManager.Exceptions;
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
    public class DocumentController : ApiController
    {
        private IUsersBusinessLogic usersBuisnessLogic { get; set; }
        private IDocumentBusinessLogic documentBusinessLogic { get; set; }
        public DocumentController(IUsersBusinessLogic logic, IDocumentBusinessLogic dLogic)
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
        [HttpGet]
        [Route("Documents")]
        public IHttpActionResult Get()
        {
            IEnumerable<Document> documentsComplete = documentBusinessLogic.GetAllDocuments();
            List<DocumentDto> documents = new List<DocumentDto>();
            foreach (var item in documentsComplete)
            {
                Document doc = documentBusinessLogic.GetFullDocument(item.Id);
                documents.Add(new DocumentDto(doc));
            }
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
                
                DocumentDto document = new DocumentDto(documentBusinessLogic.GetFullDocument(id));
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
        public IHttpActionResult Post([FromBody]DocumentModel model)
        {
            try
            {
                Document documentToAdd = GetEntityDocument(model);
                Guid id = usersBuisnessLogic.AddDocument(documentToAdd);
                return CreatedAtRoute("DefaultApi", new { id = documentToAdd.Id }, documentToAdd);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectAlreadyExistsException alreadyExistsException)
            {
                return BadRequest(alreadyExistsException.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Document/5
        public IHttpActionResult Put(Guid id, [FromBody]DocumentModel model)
        {
            try
            {
                Document documentToModify = GetEntityDocument(model);
                bool updateResult = usersBuisnessLogic.UpdateDocument(id, documentToModify);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, documentToModify);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
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

        // DELETE: api/Document/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Document documentToDelete = documentBusinessLogic.GetById(id);
                bool updateResult = usersBuisnessLogic.DeleteDocument(documentToDelete);
                return Request.CreateResponse(HttpStatusCode.Accepted, updateResult);
            }
            catch (ObjectDoesNotExists doesNotExists)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, doesNotExists.Message);
            }
            catch (DocumentAlreadyDeleted doesNotExists)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, doesNotExists.Message);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        private Document GetEntityDocument(DocumentModel model)
        {
            return model.GetEntityModel();
        }

    }
}
