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
            return BadRequest();
        }

        // POST: api/Editor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Editor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Editor/5
        public void Delete(int id)
        {
        }
    }
}