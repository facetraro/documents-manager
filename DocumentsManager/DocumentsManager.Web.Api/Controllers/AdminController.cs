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
    public class AdminController : ApiController
    {
        private IAdminsBusinessLogic adminsBuisnessLogic { get; set; }

        public AdminController(IAdminsBusinessLogic logic)
        {
            this.adminsBuisnessLogic = logic;
        }
        public AdminController()
        {
            this.adminsBuisnessLogic = new AdminBusinessLogic();
        }
        // GET: api/Admin
        public IHttpActionResult Get()
        {
            IEnumerable<AdminUser> admins = adminsBuisnessLogic.GetAllAdmins();
            if (admins == null)
            {
                return NotFound();
            }
            return Ok(admins);
        }

        // GET: api/Admin/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                AdminUser admin = adminsBuisnessLogic.GetByID(id);
                if (admin == null)
                {
                    return NotFound();
                }
                return Ok(admin);
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

        // POST: api/Admin
        public IHttpActionResult Post([FromBody]AdminModel admin)
        {
            try
            {
                if (admin == null)
                {
                    throw new ArgumentNullException();
                }
                AdminUser adminToAdd = GetEntityAdmin(admin);
                Guid id = adminsBuisnessLogic.Add(adminToAdd);
                return CreatedAtRoute("DefaultApi", new { id = adminToAdd.Id }, adminToAdd);
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

        // PUT: api/Admin/5
        public IHttpActionResult Put(Guid id, [FromBody]AdminUser admin)
        {
            try
            {
                bool updateResult = adminsBuisnessLogic.Update(id, admin);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, admin);
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

        // DELETE: api/Admin/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                bool updateResult = adminsBuisnessLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.Accepted, updateResult);
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
        public AdminUser GetEntityAdmin(AdminModel model)
        {
            return model.GetEntityModel();
        }
    }
}