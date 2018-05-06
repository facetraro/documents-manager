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
    public class EditorController : ApiController
    {
        private IEditorsBusinessLogic editorsBuisnessLogic { get; set; }

        public EditorController(IEditorsBusinessLogic logic)
        {
            this.editorsBuisnessLogic = logic;
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
            catch (ArgumentNullException ex)
            {
                return BadRequest();
            }
        }

        // POST: api/Editor
        public IHttpActionResult Post([FromBody]EditorUser editor)
        {
            try
            {
                Guid id = editorsBuisnessLogic.Add(editor);
                return CreatedAtRoute("DefaultApi", new { id = id }, editor);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Editor/5
        public IHttpActionResult Put(Guid id, [FromBody]EditorUser editor)
        {
            try
            {
                bool updateResult = editorsBuisnessLogic.Update(id, editor);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, editor);
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
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}