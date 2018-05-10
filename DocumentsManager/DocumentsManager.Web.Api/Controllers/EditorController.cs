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
    public class EditorController : ApiController
    {
        private IEditorsBusinessLogic editorsBuisnessLogic { get; set; }

        public EditorController(IEditorsBusinessLogic logic)
        {
            this.editorsBuisnessLogic = logic;
        }
        public EditorController()
        {
            this.editorsBuisnessLogic = new EditorBusinessLogic();
        }
        // GET: api/Editor
        public IHttpActionResult Get()
        {
            IEnumerable<EditorUser> editors = editorsBuisnessLogic.GetAllEditors();
            if (editors == null)
            {
                return NotFound();
            }
            return Ok(editors);
        }

        // GET: api/Editor/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                EditorUser editor = editorsBuisnessLogic.GetByID(id);
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
        public IHttpActionResult Post([FromBody]EditorModel editor)
        {
            try
            {
                if (editor == null)
                {
                    throw new ArgumentNullException();
                }
                EditorUser editorToAdd = GetEntityEditor(editor);
                Guid id = editorsBuisnessLogic.Add(editorToAdd);
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
        }


        // PUT: api/Editor/5
        public IHttpActionResult Put(Guid id, [FromBody]EditorModel editor)
        {
            try
            {
                if (editor == null)
                {
                    throw new ArgumentNullException();
                }
                EditorUser adminToUpdate = GetEntityEditor(editor);
                bool updateResult = editorsBuisnessLogic.Update(id, adminToUpdate);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, adminToUpdate);
            }
            catch (ObjectDoesNotExists doesNotExists)
            {
                return BadRequest(doesNotExists.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Editor/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                bool updateResult = editorsBuisnessLogic.Delete(id);
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