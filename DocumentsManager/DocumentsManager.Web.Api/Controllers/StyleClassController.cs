using DocumentsManager.BusinessLogic;
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
    public class StyleClassController : ApiController
    {
        private IStyleClassBusinessLogic styleClassBusinessLogic { get; set; }

        public StyleClassController(IStyleClassBusinessLogic logic)
        {
            styleClassBusinessLogic = logic;
        }
        public StyleClassController()
        {
            styleClassBusinessLogic = new StyleClassBusinessLogic();
        }

        // GET: api/StyleClass
        [HttpGet]
        [Route("viewStyles")]
        public IHttpActionResult Get()
        {
            IEnumerable<StyleClass> realStyles = styleClassBusinessLogic.GetAllStyleClasses();
            List<StyleClassDto> styles = new List<StyleClassDto>();
            foreach (var item in realStyles)
            {
                styles.Add(new StyleClassDto(item));
            }
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
                StyleClass styleComplete = styleClassBusinessLogic.GetById(id);
                StyleClassDto style = new StyleClassDto(styleComplete);
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
        public IHttpActionResult Post([FromBody] StyleClassModel style)
        {
            try
            {
                StyleClass styleToAdd = GetEntityStyleClass(style);
                Guid id = styleClassBusinessLogic.Add(styleToAdd);
                return CreatedAtRoute("DefaultApi", new { id = styleToAdd.Id }, styleToAdd);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/StyleClass/5
        public IHttpActionResult Put(Guid id, [FromBody]StyleClassModel style)
        {
            try
            {
                StyleClass styleToAdd = GetEntityStyleClass(style);
                bool updateResult = styleClassBusinessLogic.Update(id, styleToAdd);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, styleToAdd);
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
        public StyleClass GetEntityStyleClass(StyleClassModel model)
        {
            return model.GetEntityModel();
        }
    }
}
