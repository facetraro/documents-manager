using DocumentsManager.Exceptions;
using DocumentsManager.ProxyAcces;
using DocumentsManager.ProxyInterfaces;
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
        private Proxy proxyAccess;
        public DocumentController(Proxy proxy)
        {
            proxyAccess = proxy;
        }
        public DocumentController()
        {
            proxyAccess = new Proxy();
        }
        // GET: api/Document
        [HttpGet]
        [Route("Documents")]
        public IHttpActionResult Get(Guid tokenId)
        {
            IEnumerable<Document> documentsComplete = proxyAccess.GetAllDocuments(tokenId);
            List<DocumentDto> documents = new List<DocumentDto>();
            foreach (var item in documentsComplete)
            {
                Document doc = proxyAccess.GetFullDocument(item.Id, tokenId);
                documents.Add(new DocumentDto(doc));
            }
            if (documents == null)
            {
                return NotFound();
            }
            return Ok(documents);
        }

        // GET: api/Document/5
        public IHttpActionResult Get(Guid id, Guid tokenId)
        {
            try
            {

                DocumentDto document = new DocumentDto(proxyAccess.GetFullDocument(id, tokenId));
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
        public IHttpActionResult Post([FromBody]DocumentModel model, Guid tokenId)
        {
            try
            {
                Document documentToAdd = GetEntityDocument(model);
                Guid id = proxyAccess.CreateADocument(documentToAdd, tokenId);
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

        }

        // PUT: api/Document/5
        public IHttpActionResult Put(Guid id, [FromBody]DocumentModel model, Guid tokenId)
        {
            try
            {
                Document documentToModify = GetEntityDocument(model);
                bool updateResult = proxyAccess.UpdateADocument(id, documentToModify, tokenId);
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
        public HttpResponseMessage Delete(Guid id, Guid tokenId)
        {
            try
            {
                Document documentToDelete = proxyAccess.GetDocumentById(id,tokenId);
                bool updateResult = proxyAccess.DeleteADocument(documentToDelete, tokenId);
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
