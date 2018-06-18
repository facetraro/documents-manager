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
    public class AdminController : ApiController
    {
        private Proxy proxyAccess { get; set; }

        public AdminController(Proxy proxy)
        {
            this.proxyAccess = proxy;
        }
        public AdminController()
        {
            this.proxyAccess = new Proxy();
        }
        [HttpGet]
        [Route("Admins")]
        // GET: api/Admin
        public IHttpActionResult Get(Guid token)
        {
            try
            {
                IEnumerable<AdminUser> admins = proxyAccess.GetAllAdmins(token);
                if (admins == null)
                {
                    return NotFound();
                }
                return Ok(admins);
            }
            catch (SessionExpiredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: api/Admin/5
        public IHttpActionResult Get(Guid id, Guid token)
        {
            try
            {
                AdminUser admin = proxyAccess.GetAdminByID(id, token);
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
            catch (SessionExpiredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Admins
        
        public IHttpActionResult Post([FromBody]AdminModel admin,Guid token)
        {
            try
            {
                if (admin == null)
                {
                    throw new ArgumentNullException();
                }
                AdminUser adminToAdd = GetEntityAdmin(admin);
                Guid id = proxyAccess.AddAdmin(adminToAdd, token);
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
            catch (InvalidUserAttrException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserEmailException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SessionExpiredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Admin/5
        public IHttpActionResult Put(Guid id, [FromBody]AdminModel admin, Guid token)
        {
            try
            {
                if (admin == null)
                {
                    throw new ArgumentNullException();
                }
                AdminUser adminToUpdate = GetEntityAdmin(admin);
                bool updateResult = proxyAccess.UpdateAdmin(id, adminToUpdate, token);
                return CreatedAtRoute("DefaultApi", new { updated = updateResult }, adminToUpdate);
            }
            catch (ObjectDoesNotExists doesNotExists)
            {
                return BadRequest(doesNotExists.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserAttrException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserEmailException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SessionExpiredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoUserLoggedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserNotAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Admin/5
        public HttpResponseMessage Delete(Guid id, Guid token)
        {
            try
            {
                bool updateResult = proxyAccess.DeleteAdmin(id, token);
                return Request.CreateResponse(HttpStatusCode.Accepted, updateResult);
            }
            catch (ObjectDoesNotExists doesNotExists)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, doesNotExists.Message);
            }
            catch (CantDeleteLoggedUserException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
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