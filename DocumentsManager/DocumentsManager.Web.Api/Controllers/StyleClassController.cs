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
    public class StyleClassController : ApiController
    {
        private Proxy proxyAccess { get; set; }

        public StyleClassController(Proxy proxy)
        {
            proxyAccess = proxy;
        }
        public StyleClassController()
        {
            proxyAccess = new Proxy();
        }

        // GET: api/StyleClass
        [HttpGet]
        [Route("viewStyles")]
        public IHttpActionResult Get(Guid tokenId)
        {
            IEnumerable<StyleClass> realStyles = proxyAccess.GetAllStyleClasses(tokenId);
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
        public IHttpActionResult Get(Guid id, Guid tokenId)
        {
            try
            {
                StyleClass styleComplete = proxyAccess.GetStyleById(id, tokenId);
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
        public IHttpActionResult Post([FromBody] StyleClassModel style, Guid tokenId)
        {
            try
            {
                StyleClass styleToAdd = GetEntityStyleClass(style);
                Guid id = proxyAccess.AddStyle(styleToAdd, tokenId);
                return CreatedAtRoute("DefaultApi", new { id = styleToAdd.Id }, styleToAdd);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/StyleClass/5
        public IHttpActionResult Put(Guid id, [FromBody]StyleClassModel style, Guid tokenId)
        {
            try
            {
                StyleClass styleToAdd = GetEntityStyleClass(style);
                bool updateResult = proxyAccess.UpdateStyle(id, styleToAdd, tokenId);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, styleToAdd);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //  DELETE: api/StyleClass/5
        public HttpResponseMessage Delete(Guid id, Guid tokenId)
        {
            try
            {
                bool updateResult = proxyAccess.DeleteStyle(id, tokenId);
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
