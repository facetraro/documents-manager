using DocumentsManager.Exceptions;
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
    public class EditorController : ApiController
    {
        private Proxy proxyAccess { get; set; }

        public EditorController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public EditorController()
        {
            this.proxyAccess = new Proxy();
        }
        // GET: api/Editor
        public IHttpActionResult Get(Guid token)
        {
            IEnumerable<EditorUser> editors = proxyAccess.GetAllEditors(token);
            if (editors == null)
            {
                return NotFound();
            }
            return Ok(editors);
        }

        // GET: api/Editor/5
        public IHttpActionResult Get(Guid id, Guid token)
        {
            try
            {
                EditorUser editor = proxyAccess.GetEditorByID(id, token);
                if (editor == null)
                {
                    return NotFound();
                }
                return Ok(editor);
            }
            catch (WrongUserType wrongTypeException)
            {
                return BadRequest(wrongTypeException.Message);
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

        // POST: api/Editor
        public IHttpActionResult Post([FromBody]EditorModel editor, Guid token)
        {
            try
            {
                if (editor == null)
                {
                    throw new ArgumentNullException();
                }
                EditorUser editorToAdd = GetEntityEditor(editor);
                Guid id = proxyAccess.AddEditor(editorToAdd, token);
                return CreatedAtRoute("DefaultApi", new { id = editorToAdd.Id }, editorToAdd);
            }
            catch (ObjectAlreadyExistsException alreadyExistsException)
            {
                return BadRequest(alreadyExistsException.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserAttrException ex) {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserEmailException ex)
            {
                return BadRequest(ex.Message);
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


        // PUT: api/Editor/5
        public IHttpActionResult Put(Guid id, [FromBody]EditorModel editor, Guid token)
        {
            try
            {
                if (editor == null)
                {
                    throw new ArgumentNullException();
                }
                EditorUser editorToUpdate = GetEntityEditor(editor);
                bool updateResult = proxyAccess.UpdateEditor(id, editorToUpdate, token);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, editorToUpdate);
            }
            catch (ObjectDoesNotExists doesNotExists)
            {
                return BadRequest(doesNotExists.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserAttrException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserEmailException ex)
            {
                return BadRequest(ex.Message);
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

        // DELETE: api/Editor/5
        public HttpResponseMessage Delete(Guid id, Guid token)
        {
            try
            {
                bool updateResult = proxyAccess.DeleteEditor(id, token);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
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

        private EditorUser GetEntityEditor(EditorModel editor)
        {
            return editor.GetEntityModel();
        }
    }
}