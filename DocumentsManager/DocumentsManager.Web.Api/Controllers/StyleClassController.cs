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
    public class StyleClassController : ApiController
    {
        private IStyleClassBusinessLogic styleClassBusinessLogic { get; set; }

        public StyleClassController(IStyleClassBusinessLogic logic)
        {
            styleClassBusinessLogic = logic;
        }

        // GET: api/StyleClass
        public IHttpActionResult Get()
        {
            IEnumerable<StyleClass> styles = styleClassBusinessLogic.GetAllStyleClasses();
            if (styles == null)
            {
                return NotFound();
            }
            return Ok(styles);
        }

        // GET: api/StyleClass/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                StyleClass style = styleClassBusinessLogic.GetByID(id);
                if (style == null)
                {
                    return NotFound();
                }
                return Ok(style);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/StyleClass
        public IHttpActionResult Post([FromBody] StyleClass style)
        {
            try
            {
                Guid id = styleClassBusinessLogic.Add(style);
                return CreatedAtRoute("DefaultApi", new { id = id }, style);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/StyleClass/5
        public IHttpActionResult Put(Guid id, [FromBody]StyleClass style)
        {
            try
            {
                bool updateResult = styleClassBusinessLogic.Update(id, style);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, style);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //  DELETE: api/StyleClass/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                bool updateResult = styleClassBusinessLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
