using DocumentsManager.Exceptions;
using DocumentsManager.ProxyAcces;
using DocumentsManager.ProxyInterfaces;
using DocumentsManager.Web.Api.Models;
using DocumentsMangerEntities;
using DocumentsManager.Dtos;
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
        public IHttpActionResult Get(Guid token)
        {
            IEnumerable<Document> documentsComplete = proxyAccess.GetAllDocuments(token);
            List<DocumentDto> documents = new List<DocumentDto>();
            foreach (var item in documentsComplete)
            {
                 documents.Add(new DocumentDto(item));
            }
            if (documents == null)
            {
                return NotFound();
            }
            return Ok(documents);
        }

        // GET: api/Document/5
        public IHttpActionResult Get(Guid id, Guid token)
        {
            try
            {

                DocumentDto document = new DocumentDto(proxyAccess.GetFullDocument(id, token));
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
        public IHttpActionResult Post([FromBody]DocumentModel model, Guid token)
        {
            try
            {
                model.Id = Guid.Empty;
                Document documentToAdd = GetEntityDocument(model);
                Guid id = proxyAccess.CreateADocument(documentToAdd, token);
                return Ok(id);
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
        public IHttpActionResult Put(Guid id, [FromBody]DocumentModel model, Guid token)
        {
            try
            {
                Document documentToModify = GetEntityDocument(model);
                bool updateResult = proxyAccess.UpdateADocument(id, documentToModify, token);
                return Ok(id);
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
        public HttpResponseMessage Delete(Guid id, Guid token)
        {
            try
            {
                Document documentToDelete = proxyAccess.GetDocumentById(id,token);
                bool updateResult = proxyAccess.DeleteADocument(documentToDelete, token);
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
