using DocumentsManager.FormatImportation;
using DocumentsManager.ImportedItemsParser;
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
        public IHttpActionResult Get(Guid token)
        {
            IEnumerable<StyleClass> realStyles = proxyAccess.GetAllStyleClasses(token);
            List<ImportedStyleClass> styles = new List<ImportedStyleClass>();
            foreach (var item in realStyles)
            {
                styles.Add(StyleClassParser.Parse(item));
            }
            if (styles == null)
            {
                return NotFound();
            }
            return Ok(styles);
        }

        // GET: api/StyleClass/5
        public IHttpActionResult Get(Guid id, Guid token)
        {
            try
            {
                StyleClass styleComplete = proxyAccess.GetStyleById(id, token);
                ImportedStyleClass style = StyleClassParser.Parse(styleComplete);
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
        public IHttpActionResult Post([FromBody] ImportedStyleClass style, Guid token)
        {
            try
            {
                StyleClass styleToAdd = StyleClassParser.Parse(style);
                Guid id = proxyAccess.AddStyle(styleToAdd, token);
                return Ok(id);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/StyleClass/5
        public IHttpActionResult Put(Guid id, [FromBody]ImportedStyleClass style, Guid token)
        {
            try
            {
                StyleClass styleToAdd = StyleClassParser.Parse(style);
                styleToAdd.Id = id;
                bool updateResult = proxyAccess.UpdateStyle(id, styleToAdd, token);
                return Ok(200);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //  DELETE: api/StyleClass/5
        public HttpResponseMessage Delete(Guid id, Guid token)
        {
            try
            {
                bool updateResult = proxyAccess.DeleteStyle(id, token);
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
