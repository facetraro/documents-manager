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
    public class AdminController : ApiController
    {
        private IAdminsBusinessLogic editorsBuisnessLogic { get; set; }

        public AdminController(IAdminsBusinessLogic logic)
        {
            this.editorsBuisnessLogic = logic;
        }

        // GET: api/Admin
        public IHttpActionResult Get()
        {
            IEnumerable<AdminUser> editors = editorsBuisnessLogic.GetAllAdmins();
            if (editors == null)
            {
                return NotFound();
            }
            return Ok(editors);
        }

        // GET: api/Admin/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                AdminUser editor = editorsBuisnessLogic.GetByID(id);
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

        // POST: api/Admin
        public IHttpActionResult Post([FromBody]AdminUser editor)
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

        // PUT: api/Admin/5
        public IHttpActionResult Put(Guid id, [FromBody]AdminUser editor)
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

        // DELETE: api/Admin/5
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