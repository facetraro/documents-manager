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
    public class FormatController : ApiController
    {
        private Proxy proxyAccess { get; set; }

        public FormatController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public FormatController()
        {
            this.proxyAccess = new Proxy(); ;
        }

        // GET: api/Format
        public IHttpActionResult Get(Guid token)
        {
            try
            {
                IEnumerable<Format> formatsComplete = proxyAccess.GetAllFormats(token);
                List<FormatDto> formats = new List<FormatDto>();
                for (int i = 0; i < formatsComplete.Count(); i++)
                {
                    Format fi = formatsComplete.ElementAt(i);
                    formats.Add(new FormatDto(fi));
                    for (int j = 0; j < fi.StyleClasses.Count; j++)
                    {
                        StyleClass sj = fi.StyleClasses.ElementAt(j);
                        formats.ElementAt(i).StyleClasses.Add(new StyleClassDto(sj));
                    }

                }
                if (formats == null)
                {
                    return NotFound();
                }
                return Ok(formats);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/Format/5
        public IHttpActionResult Get(Guid id, Guid token)
        {
            try
            {
                Format editor = proxyAccess.GetFormatByID(id, token);
                FormatDto format = new FormatDto(editor);
                foreach (var item in editor.StyleClasses)
                {
                    format.StyleClasses.Add(new StyleClassDto(item));
                }
                if (format == null)
                {
                    return NotFound();
                }
                return Ok(format);
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
                return BadRequest();
            }
        }

        // POST: api/Format
        public IHttpActionResult Post([FromBody]FormatModel model, Guid token)
        {
            try
            {
                Format formatToAdd = GetEntityFormat(model);
                Guid id = proxyAccess.AddFormat(formatToAdd, token);
                return CreatedAtRoute("DefaultApi", new { id = formatToAdd.Id }, formatToAdd);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
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

        // PUT: api/Format/5
        public IHttpActionResult Put(Guid id, [FromBody]FormatModel format, Guid token)
        {
            try
            {
                Format formatToAdd = GetEntityFormat(format);
                bool updateResult = proxyAccess.UpdateFormat(id, formatToAdd, token);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, formatToAdd);
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

        // DELETE: api/Format/5
        public HttpResponseMessage Delete(Guid id, Guid token)
        {
            try
            {
                bool updateResult = proxyAccess.DeleteFormat(id, token);
                return Request.CreateResponse(HttpStatusCode.NoContent, updateResult);
            }
            catch (NoUserLoggedException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (ObjectDoesNotExists ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        private Format GetEntityFormat(FormatModel model)
        {
            return model.GetEntityModel();
        }

    }
}