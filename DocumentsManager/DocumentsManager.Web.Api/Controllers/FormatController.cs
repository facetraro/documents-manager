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
    public class FormatController : ApiController
    {
        private IFormatsBusinessLogic editorsBuisnessLogic { get; set; }

        public FormatController(IFormatsBusinessLogic logic)
        {
            this.editorsBuisnessLogic = logic;
        }
        public FormatController()
        {
            this.editorsBuisnessLogic = new FormatBusinessLogic(); ;
        }

        // GET: api/Format
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<Format> formatsComplete = editorsBuisnessLogic.GetAllFormats();
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
            catch (NoUserLoggedException ex) {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/Format/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                Format editor = editorsBuisnessLogic.GetByID(id);
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
        public IHttpActionResult Post([FromBody]FormatModel model)
        {
            try
            {
                Format formatToAdd = GetEntityFormat(model);
                Guid id = editorsBuisnessLogic.Add(formatToAdd);
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
        public IHttpActionResult Put(Guid id, [FromBody]FormatModel format)
        {
            try
            {
                Format formatToAdd = GetEntityFormat(format);
                bool updateResult = editorsBuisnessLogic.Update(id, formatToAdd);
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
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                bool updateResult = editorsBuisnessLogic.Delete(id);
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